// Copyright (c) 2004, 2020 Oracle and/or its affiliates.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License, version 2.0, as
// published by the Free Software Foundation.
//
// This program is also distributed with certain software (including
// but not limited to OpenSSL) that is licensed under separate terms,
// as designated in a particular file or component or in included license
// documentation.  The authors of MySQL hereby grant you an
// additional permission to link the program and your derivative works
// with the separately licensed software that they have included with
// MySQL.
//
// Without limiting anything contained in the foregoing, this file,
// which is part of MySQL Connector/NET, is also subject to the
// Universal FOSS Exception, version 1.0, a copy of which can be found at
// http://oss.oracle.com/licenses/universal-foss-exception.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License, version 2.0, for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Beta.Data.MyCatSqlClient
{
  internal class ProcedureCacheEntry
  {
    public MySqlSchemaCollection procedure;
    public MySqlSchemaCollection parameters;
  }

  internal class ProcedureCache
  {
    private readonly Dictionary<int, ProcedureCacheEntry> _procHash;
    private readonly Queue<int> _hashQueue;
    private readonly int _maxSize;

    public ProcedureCache(int size)
    {
      _maxSize = size;
      _hashQueue = new Queue<int>(_maxSize);
      _procHash = new Dictionary<int, ProcedureCacheEntry>(_maxSize);
    }

    public ProcedureCacheEntry GetProcedure(MyCatSqlConnection conn, string spName, string cacheKey)
    {
      ProcedureCacheEntry proc = null;

      if (cacheKey != null)
      {
        int hash = cacheKey.GetHashCode();

        lock (_procHash)
        {
          _procHash.TryGetValue(hash, out proc);
        }
      }
      if (proc == null)
      {
        proc = AddNew(conn, spName);
        conn.PerfMonitor.AddHardProcedureQuery();
        if (conn.Settings.Logging)
          MyCatSqlTrace.LogInformation(conn.ServerThread,
            String.Format(Resources.HardProcQuery, spName));
      }
      else
      {
        conn.PerfMonitor.AddSoftProcedureQuery();
        if (conn.Settings.Logging)
          MyCatSqlTrace.LogInformation(conn.ServerThread,
            String.Format(Resources.SoftProcQuery, spName));
      }
      return proc;
    }

    internal string GetCacheKey(string spName, ProcedureCacheEntry proc)
    {
      string retValue = String.Empty;
      StringBuilder key = new StringBuilder(spName);
      key.Append("(");
      string delimiter = "";
      if (proc.parameters != null)
      {
        foreach (MySqlSchemaRow row in proc.parameters.Rows)
        {
          if (row["ORDINAL_POSITION"].Equals(0))
            retValue = "?=";
          else
          {
            key.AppendFormat(CultureInfo.InvariantCulture, "{0}?", delimiter);
            delimiter = ",";
          }
        }
      }
      key.Append(")");
      return retValue + key.ToString();
    }

    private ProcedureCacheEntry AddNew(MyCatSqlConnection connection, string spName)
    {
      ProcedureCacheEntry procData = GetProcData(connection, spName);

      if (_maxSize <= 0) return procData;

      string cacheKey = GetCacheKey(spName, procData);
      int hash = cacheKey.GetHashCode();
      lock (_procHash)
      {
        if (_procHash.Keys.Count >= _maxSize)
          TrimHash();
        if (!_procHash.ContainsKey(hash))
        {
          _procHash[hash] = procData;
          _hashQueue.Enqueue(hash);
        }
      }
      return procData;
    }

    private void TrimHash()
    {
      int oldestHash = _hashQueue.Dequeue();
      _procHash.Remove(oldestHash);
    }

    private static ProcedureCacheEntry GetProcData(MyCatSqlConnection connection, string spName)
    {
      string schema = string.Empty;
      string name = spName;

      int dotIndex = spName.IndexOf("`.`");
      if (dotIndex != -1)
      {
        schema = spName.Substring(1, dotIndex - 1);
        name = spName.Substring(dotIndex + 3, spName.Length - dotIndex - 4);
      }

      string[] restrictions = new string[4];
      restrictions[1] = schema.Length > 0 ? schema : connection.CurrentDatabase();
      restrictions[2] = name;
      MySqlSchemaCollection proc = connection.GetSchemaCollection("procedures", restrictions);
      if (proc.Rows.Count > 1)
        throw new MySqlException(Resources.ProcAndFuncSameName);
      if (proc.Rows.Count == 0)
      {
        string msg = string.Format(Resources.InvalidProcName, name, schema) + " " +
        string.Format(Resources.ExecuteProcedureUnauthorized, connection.Settings.UserID, connection.Settings.Server);
        throw new MySqlException(msg);
      }

      ProcedureCacheEntry entry = new ProcedureCacheEntry();
      entry.procedure = proc;

      // we don't use GetSchema here because that would cause another
      // query of procedures and we don't need that since we already
      // know the procedure we care about.
      ISSchemaProvider isp = new ISSchemaProvider(connection);
      string[] rest = isp.CleanRestrictions(restrictions);
      MySqlSchemaCollection parameters = isp.GetProcedureParameters(rest, proc);
      entry.parameters = parameters;

      return entry;
    }
  }
}