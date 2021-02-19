// Copyright © 2009, 2016, Oracle and/or its affiliates. All rights reserved.
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
using System.Diagnostics;
using System.Text;
using System.Threading;

using Beta.Data.Common;

namespace Beta.Data.MyCatSqlClient
{
  internal class TracingDriver : Driver
  {
    private static long driverCounter;
    private long driverId;
    private ResultSet activeResult;
    private int rowSizeInBytes;

    public TracingDriver(MyCatSqlConnectionStringBuilder settings)
      : base(settings)
    {
      driverId = Interlocked.Increment(ref driverCounter);
    }

    public override void Open()
    {
      base.Open();
      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.ConnectionOpened,
          Resources.TraceOpenConnection, driverId, Settings.ConnectionString, ThreadID);
    }

    public override void Close()
    {
      base.Close();
      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.ConnectionClosed,
          Resources.TraceCloseConnection, driverId);
    }

    public override void SendQuery(MyCatSqlPacket p)
    {
      rowSizeInBytes = 0;
      string cmdText = Encoding.GetString(p.Buffer, 5, p.Length - 5);
      string normalizedQuery = null;

      if (cmdText.Length > 300)
      {
        QueryNormalizer normalizer = new QueryNormalizer();
        normalizedQuery = normalizer.Normalize(cmdText);
        cmdText = cmdText.Substring(0, 300);
      }

      base.SendQuery(p);

      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.QueryOpened,
          Resources.TraceQueryOpened, driverId, ThreadID, cmdText);
      if (normalizedQuery != null)
        MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.QueryNormalized,
            Resources.TraceQueryNormalized, driverId, ThreadID, normalizedQuery);
    }

    protected override int GetResult(int statementId, ref int affectedRows, ref long insertedId)
    {
      try
      {
        int fieldCount = base.GetResult(statementId, ref affectedRows, ref insertedId);
        MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.ResultOpened,
            Resources.TraceResult, driverId, fieldCount, affectedRows, insertedId);

        return fieldCount;
      }
      catch (MySqlException ex)
      {
        // we got an error so we report it
        MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.Error,
            Resources.TraceOpenResultError, driverId, ex.Number, ex.Message);
        throw ex;
      }
    }

    public override ResultSet NextResult(int statementId, bool force)
    {
      // first let's see if we already have a resultset on this statementId
      if (activeResult != null)
      {
        //oldRS = activeResults[statementId];
        if (Settings.UseUsageAdvisor)
          ReportUsageAdvisorWarnings(statementId, activeResult);
        MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.ResultClosed,
            Resources.TraceResultClosed, driverId, activeResult.TotalRows, activeResult.SkippedRows,
            rowSizeInBytes);
        rowSizeInBytes = 0;
        activeResult = null;
      }

      activeResult = base.NextResult(statementId, force);
      return activeResult;
    }

    public override int PrepareStatement(string sql, ref MySqlField[] parameters)
    {
      int statementId = base.PrepareStatement(sql, ref parameters);
      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.StatementPrepared,
          Resources.TraceStatementPrepared, driverId, sql, statementId);
      return statementId;
    }

    public override void CloseStatement(int id)
    {
      base.CloseStatement(id);
      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.StatementClosed,
          Resources.TraceStatementClosed, driverId, id);
    }

    public override void SetDatabase(string dbName)
    {
      base.SetDatabase(dbName);
      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.NonQuery,
          Resources.TraceSetDatabase, driverId, dbName);
    }

    public override void ExecuteStatement(MyCatSqlPacket packetToExecute)
    {
      base.ExecuteStatement(packetToExecute);
      int pos = packetToExecute.Position;
      packetToExecute.Position = 1;
      int statementId = packetToExecute.ReadInteger(4);
      packetToExecute.Position = pos;

      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.StatementExecuted,
          Resources.TraceStatementExecuted, driverId, statementId, ThreadID);
    }

    public override bool FetchDataRow(int statementId, int columns)
    {
      try
      {
        bool b = base.FetchDataRow(statementId, columns);
        if (b)
          rowSizeInBytes += (handler as NativeDriver).Packet.Length;
        return b;
      }
      catch (MySqlException ex)
      {
        MyCatSqlTrace.TraceEvent(TraceEventType.Error, MySqlTraceEventType.Error,
            Resources.TraceFetchError, driverId, ex.Number, ex.Message);
        throw ex;
      }
    }

    public override void CloseQuery(MyCatSqlConnection connection, int statementId)
    {
      base.CloseQuery(connection, statementId);

      MyCatSqlTrace.TraceEvent(TraceEventType.Information, MySqlTraceEventType.QueryClosed,
          Resources.TraceQueryDone, driverId);
    }

    public override List<MyCatSqlError> ReportWarnings(MyCatSqlConnection connection)
    {
      List<MyCatSqlError> warnings = base.ReportWarnings(connection);
      foreach (MyCatSqlError warning in warnings)
        MyCatSqlTrace.TraceEvent(TraceEventType.Warning, MySqlTraceEventType.Warning,
            Resources.TraceWarning, driverId, warning.Level, warning.Code, warning.Message);
      return warnings;
    }

    private bool AllFieldsAccessed(ResultSet rs)
    {
      if (rs.Fields == null || rs.Fields.Length == 0) return true;

      for (int i = 0; i < rs.Fields.Length; i++)
        if (!rs.FieldRead(i)) return false;
      return true;
    }

    private void ReportUsageAdvisorWarnings(int statementId, ResultSet rs)
    {
      if (!Settings.UseUsageAdvisor) return;

      if (HasStatus(ServerStatusFlags.NoIndex))
        MyCatSqlTrace.TraceEvent(TraceEventType.Warning, MySqlTraceEventType.UsageAdvisorWarning,
            Resources.TraceUAWarningNoIndex, driverId, UsageAdvisorWarningFlags.NoIndex);
      else if (HasStatus(ServerStatusFlags.BadIndex))
        MyCatSqlTrace.TraceEvent(TraceEventType.Warning, MySqlTraceEventType.UsageAdvisorWarning,
            Resources.TraceUAWarningBadIndex, driverId, UsageAdvisorWarningFlags.BadIndex);

      // report abandoned rows
      if (rs.SkippedRows > 0)
        MyCatSqlTrace.TraceEvent(TraceEventType.Warning, MySqlTraceEventType.UsageAdvisorWarning,
            Resources.TraceUAWarningSkippedRows, driverId, UsageAdvisorWarningFlags.SkippedRows, rs.SkippedRows);

      // report not all fields accessed
      if (!AllFieldsAccessed(rs))
      {
        StringBuilder notAccessed = new StringBuilder("");
        string delimiter = "";
        for (int i = 0; i < rs.Size; i++)
          if (!rs.FieldRead(i))
          {
            notAccessed.AppendFormat("{0}{1}", delimiter, rs.Fields[i].ColumnName);
            delimiter = ",";
          }
        MyCatSqlTrace.TraceEvent(TraceEventType.Warning, MySqlTraceEventType.UsageAdvisorWarning,
            Resources.TraceUAWarningSkippedColumns, driverId, UsageAdvisorWarningFlags.SkippedColumns,
                notAccessed.ToString());
      }

      // report type conversions if any
      if (rs.Fields != null)
      {
        foreach (MySqlField f in rs.Fields)
        {
          StringBuilder s = new StringBuilder();
          string delimiter = "";
          foreach (Type t in f.TypeConversions)
          {
            s.AppendFormat("{0}{1}", delimiter, t.Name);
            delimiter = ",";
          }
          if (s.Length > 0)
            MyCatSqlTrace.TraceEvent(TraceEventType.Warning, MySqlTraceEventType.UsageAdvisorWarning,
                Resources.TraceUAWarningFieldConversion, driverId, UsageAdvisorWarningFlags.FieldConversion,
                f.ColumnName, s.ToString());
        }
      }
    }
  }
}
