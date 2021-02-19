// Copyright (c) 2004, 2020, Oracle and/or its affiliates.
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
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Versioning;

namespace Beta.Data.MyCatSqlClient
{
  /// <summary>
  /// Summary description for ClientParam.
  /// </summary>
  [Flags]
  internal enum ClientFlags : ulong
  {
    LONG_PASSWORD = 1, // new more secure passwords
    FOUND_ROWS = 2, // found instead of affected rows
    LONG_FLAG = 4, // Get all column flags
    CONNECT_WITH_DB = 8, // One can specify db on connect
    NO_SCHEMA = 16, // Don't allow db.table.column
    COMPRESS = 32, // Client can use compression protocol
    ODBC = 64, // ODBC client
    LOCAL_FILES = 128, // Can use LOAD DATA LOCAL
    IGNORE_SPACE = 256, // Ignore spaces before '('
    PROTOCOL_41 = 512, // Support new 4.1 protocol
    INTERACTIVE = 1024, // This is an interactive client
    SSL = 2048, // Switch to SSL after handshake
    IGNORE_SIGPIPE = 4096, // IGNORE sigpipes
    TRANSACTIONS = 8192, // Client knows about transactions
    RESERVED = 16384,               // old 4.1 protocol flag
    SECURE_CONNECTION = 32768,      // new 4.1 authentication
    MULTI_STATEMENTS = 65536,       // Allow multi-stmt support
    MULTI_RESULTS = 131072,         // Allow multiple resultsets
    PS_MULTI_RESULTS = 1UL << 18,    // allow multi results using PS protocol
    PLUGIN_AUTH = (1UL << 19), //Client supports plugin authentication
    CONNECT_ATTRS = (1UL << 20),    // Allows client connection attributes
    CAN_HANDLE_EXPIRED_PASSWORD = (1UL << 22),   // Support for password expiration > 5.6.6
    CLIENT_SSL_VERIFY_SERVER_CERT = (1UL << 30),
    CLIENT_REMEMBER_OPTIONS = (1UL << 31)
  }

  [Flags]
  internal enum ServerStatusFlags
  {
    InTransaction = 1, // Transaction has started
    AutoCommitMode = 2, // Server in auto_commit mode 
    MoreResults = 4, // More results on server
    AnotherQuery = 8, // Multi query - next query exists
    BadIndex = 16,
    NoIndex = 32,
    CursorExists = 64,
    LastRowSent = 128,
    OutputParameters = 4096
  }

  /// <summary>
  /// DB Operations Code
  /// </summary>
  internal enum DBCmd : byte
  {
    SLEEP = 0,
    QUIT = 1,
    INIT_DB = 2,
    QUERY = 3,
    FIELD_LIST = 4,
    CREATE_DB = 5,
    DROP_DB = 6,
    RELOAD = 7,
    SHUTDOWN = 8,
    STATISTICS = 9,
    PROCESS_INFO = 10,
    CONNECT = 11,
    PROCESS_KILL = 12,
    DEBUG = 13,
    PING = 14,
    TIME = 15,
    DELAYED_INSERT = 16,
    CHANGE_USER = 17,
    BINLOG_DUMP = 18,
    TABLE_DUMP = 19,
    CONNECT_OUT = 20,
    REGISTER_SLAVE = 21,
    PREPARE = 22,
    EXECUTE = 23,
    LONG_DATA = 24,
    CLOSE_STMT = 25,
    RESET_STMT = 26,
    SET_OPTION = 27,
    FETCH = 28
  }

  /// <summary>
  /// Specifies MySQL specific data type of a field, property, for use in a <see cref="MySqlParameter"/>.
  /// </summary>
  public enum MySqlDbType
  {
    /// <summary>
    /// <see cref="Decimal"/>
    /// <para>A fixed precision and scale numeric value between -1038 
    /// -1 and 10 38 -1.</para>
    /// </summary>
    Decimal = 0,
    /// <summary>
    /// <see cref="Byte"/><para>The signed range is -128 to 127. The unsigned 
    /// range is 0 to 255.</para>
    /// </summary>
    Byte = 1,
    /// <summary>
    /// <see cref="Int16"/><para>A 16-bit signed integer. The signed range is 
    /// -32768 to 32767. The unsigned range is 0 to 65535</para>
    /// </summary>
    Int16 = 2,
    /// <summary>
    /// Specifies a 24 (3 byte) signed or unsigned value.
    /// </summary>
    Int24 = 9,
    /// <summary>
    /// <see cref="Int32"/><para>A 32-bit signed integer</para>
    /// </summary>
    Int32 = 3,
    /// <summary>
    /// <see cref="Int64"/><para>A 64-bit signed integer.</para>
    /// </summary>
    Int64 = 8,
    /// <summary>
    /// <see cref="Single"/><para>A small (single-precision) floating-point 
    /// number. Allowable values are -3.402823466E+38 to -1.175494351E-38, 
    /// 0, and 1.175494351E-38 to 3.402823466E+38.</para>
    /// </summary>
    Float = 4,
    /// <summary>
    /// <see cref="Double"/><para>A normal-size (double-precision) 
    /// floating-point number. Allowable values are -1.7976931348623157E+308 
    /// to -2.2250738585072014E-308, 0, and 2.2250738585072014E-308 to 
    /// 1.7976931348623157E+308.</para>
    /// </summary>
    Double = 5,
    /// <summary>
    /// A timestamp. The range is '1970-01-01 00:00:00' to sometime in the 
    /// year 2037
    /// </summary>
    Timestamp = 7,
    ///<summary>
    ///Date The supported range is '1000-01-01' to '9999-12-31'.
    ///</summary>
    Date = 10,
    /// <summary>
    /// Time <para>The range is '-838:59:59' to '838:59:59'.</para>
    /// </summary>
    Time = 11,
    ///<summary>
    ///DateTime The supported range is '1000-01-01 00:00:00' to 
    ///'9999-12-31 23:59:59'.
    ///</summary>
    DateTime = 12,
    ///<summary>
    ///Datetime The supported range is '1000-01-01 00:00:00' to 
    ///'9999-12-31 23:59:59'.
    ///</summary>
    [Obsolete("The Datetime enum value is obsolete.  Please use DateTime.")]
    Datetime = 12,
    /// <summary>
    /// A year in 2- or 4-digit format (default is 4-digit). The 
    /// allowable values are 1901 to 2155, 0000 in the 4-digit year 
    /// format, and 1970-2069 if you use the 2-digit format (70-69).
    /// </summary>
    Year = 13,
    /// <summary>
    /// <b>Obsolete</b>  Use Datetime or Date type
    /// </summary>
    Newdate = 14,
    /// <summary>
    /// A variable-length string containing 0 to 65535 characters
    /// </summary>
    VarString = 15,
    /// <summary>
    /// Bit-field data type
    /// </summary>
    Bit = 16,
    /// <summary>
    /// JSON
    /// </summary>
    JSON = 245,
    /// <summary>
    /// New Decimal
    /// </summary>
    NewDecimal = 246,
    /// <summary>
    /// An enumeration. A string object that can have only one value, 
    /// chosen from the list of values 'value1', 'value2', ..., NULL 
    /// or the special "" error value. An ENUM can have a maximum of 
    /// 65535 distinct values
    /// </summary>
    Enum = 247,
    /// <summary>
    /// A set. A string object that can have zero or more values, each 
    /// of which must be chosen from the list of values 'value1', 'value2', 
    /// ... A SET can have a maximum of 64 members.
    /// </summary>
    Set = 248,
    /// <summary>
    /// A binary column with a maximum length of 255 (2^8 - 1) 
    /// characters
    /// </summary>
    TinyBlob = 249,
    /// <summary>
    /// A binary column with a maximum length of 16777215 (2^24 - 1) bytes.
    /// </summary>
    MediumBlob = 250,
    /// <summary>
    /// A binary column with a maximum length of 4294967295 or 
    /// 4G (2^32 - 1) bytes.
    /// </summary>
    LongBlob = 251,
    /// <summary>
    /// A binary column with a maximum length of 65535 (2^16 - 1) bytes.
    /// </summary>
    Blob = 252,
    /// <summary>
    /// A variable-length string containing 0 to 255 bytes.
    /// </summary>
    VarChar = 253,
    /// <summary>
    /// A fixed-length string.
    /// </summary>
    String = 254,
    /// <summary>
    /// Geometric (GIS) data type.
    /// </summary>
    Geometry = 255,
    /// <summary>
    /// Unsigned 8-bit value.
    /// </summary>
    UByte = 501,
    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    UInt16 = 502,
    /// <summary>
    /// Unsigned 24-bit value.
    /// </summary>
    UInt24 = 509,
    /// <summary>
    /// Unsigned 32-bit value.
    /// </summary>
    UInt32 = 503,
    /// <summary>
    /// Unsigned 64-bit value.
    /// </summary>
    UInt64 = 508,
    /// <summary>
    /// Fixed length binary string.
    /// </summary>
    Binary = 754,
    /// <summary>
    /// Variable length binary string.
    /// </summary>
    VarBinary = 753,
    /// <summary>
    /// A text column with a maximum length of 255 (2^8 - 1) characters.
    /// </summary>
    TinyText = 749,
    /// <summary>
    /// A text column with a maximum length of 16777215 (2^24 - 1) characters.
    /// </summary>
    MediumText = 750,
    /// <summary>
    /// A text column with a maximum length of 4294967295 or 
    /// 4G (2^32 - 1) characters.
    /// </summary>
    LongText = 751,
    /// <summary>
    /// A text column with a maximum length of 65535 (2^16 - 1) characters.
    /// </summary>
    Text = 752,
    /// <summary>
    /// A guid column.
    /// </summary>
    Guid = 854
  };

  internal enum Field_Type : byte
  {
    DECIMAL = 0,
    BYTE = 1,
    SHORT = 2,
    LONG = 3,
    FLOAT = 4,
    DOUBLE = 5,
    NULL = 6,
    TIMESTAMP = 7,
    LONGLONG = 8,
    INT24 = 9,
    DATE = 10,
    TIME = 11,
    DATETIME = 12,
    YEAR = 13,
    NEWDATE = 14,
    ENUM = 247,
    SET = 248,
    TINY_BLOB = 249,
    MEDIUM_BLOB = 250,
    LONG_BLOB = 251,
    BLOB = 252,
    VAR_STRING = 253,
    STRING = 254,
  }

  /// <summary>
  /// Allows the user to specify the type of connection that should
  /// be used.
  /// </summary>
  public enum MyCatSqlConnectionProtocol
  {
    /// <summary>
    /// TCP/IP style connection. Works everywhere.
    /// </summary>
    Sockets = 1,
    /// <summary>
    /// TCP/IP style connection. Works everywhere.
    /// </summary>
    Socket = 1,
    /// <summary>
    /// TCP/IP style connection. Works everywhere.
    /// </summary>
    Tcp = 1,
    /// <summary>
    /// Named pipe connection. Works only on Windows systems.
    /// </summary>
    Pipe = 2,
    /// <summary>
    /// Named pipe connection. Works only on Windows systems.
    /// </summary>
    NamedPipe = 2,
    /// <summary>
    /// Unix domain socket connection. Works only with Unix systems.
    /// </summary>
    UnixSocket = 3,
    /// <summary>
    /// Unix domain socket connection. Works only with Unix systems.
    /// </summary>
    Unix = 3,
    /// <summary>
    /// Shared memory connection. Currently works only with Windows systems.
    /// </summary>
    SharedMemory = 4,
    /// <summary>
    /// Shared memory connection. Currently works only with Windows systems.
    /// </summary>
    Memory = 4
  }

  /// <summary>
  /// SSL options for connection.
  /// </summary>
  public enum MySqlSslMode
  {
    /// <summary>
    /// Do not use SSL.
    /// </summary>
    None,
    /// <summary>
    /// Use SSL, if server supports it. This option is only available for the classic protocol.
    /// </summary>
    Preferred,
    Prefered = Preferred,
    /// <summary>
    /// Always use SSL. Deny connection if server does not support SSL.
    /// Do not perform server certificate validation.
    /// This is the default SSL mode when the same isn't specified as part of the connection string.
    /// </summary>
    Required,
    /// <summary>
    /// Always use SSL. Validate server SSL certificate, but different host name mismatch.
    /// </summary>
    VerifyCA,
    /// <summary>
    /// Always use SSL and perform full certificate validation.
    /// </summary>
    VerifyFull
  }

  /// <summary>
  /// Specifies the connection types supported
  /// </summary>
  public enum MySqlDriverType
  {
    /// <summary>
    /// Use TCP/IP sockets.
    /// </summary>
    Native,
    /// <summary>
    /// Use client library.
    /// </summary>
    Client,
    /// <summary>
    /// Use MySQL embedded server.
    /// </summary>
    Embedded
  }

  /// <summary>
  /// Defines the location of the certificate store.
  /// </summary>
  public enum MySqlCertificateStoreLocation
  {
    /// <summary>
    /// Do not use certificate store.
    /// </summary>
    None,
    /// <summary>
    /// Use certificate store for the current user.
    /// </summary>
    CurrentUser,
    /// <summary>
    /// User certificate store for the machine.
    /// </summary>
    LocalMachine
  }

  /// <summary>
  /// Specifies the authentication mechanism that should be used.
  /// </summary>
  public enum MySqlAuthenticationMode
  {
    /// <summary>
    /// If SSL is enabled or Unix sockets are being used, sets PLAIN as the authentication mechanism;
    /// otherwise, it tries to use MYSQL41 and then SHA256_MEMORY.
    /// </summary>
    Default = 0,
    AUTO = 0,
    /// <summary>
    /// Authenticate using PLAIN.
    /// </summary>
    PLAIN = 1,
    /// <summary>
    /// Authenticate using MYSQL41.
    /// </summary>
    MYSQL41 = 2,
    /// <summary>
    /// Authenticate using EXTERNAL.
    /// </summary>
    EXTERNAL = 3,
    /// <summary>
    /// Authenticate using SHA256_MEMORY.
    /// </summary>
    SHA256_MEMORY = 4
  }

  /// <summary>
  /// Defines waiting options that may be used with row locking options.
  /// </summary>
  public enum LockContention
  {
    /// <summary>
    /// Waits until the blocking transaction releases the row lock.
    /// </summary>
    Default = 0,
    /// <summary>
    /// Never waits to acquire a row lock. The query executes immediately, 
    /// failing with an error if a requested row is locked.
    /// </summary>
    NoWait = 1,
    /// <summary>
    /// Never waits to acquire a row lock. The query executes immediately, 
    /// removing locked rows from the result set.
    /// </summary>
    SkipLocked = 2
  }

  /// <summary>
  /// Defines the type of compression used when data is exchanged between client and server.
  /// </summary>
  public enum CompressionType
  {
    /// <summary>
    /// Uses compression if client and server are able to reach a concensus. Otherwise, compression
    /// is not used.
    /// </summary>
    Preferred,
    /// <summary>
    /// Enforces the use of compression. If no concensus is reached, an error is raised.
    /// </summary>
    Required,
    /// <summary>
    /// Disables compression.
    /// </summary>
    Disabled
  }

  /// <summary>
  /// Defines the compression algorithms that can be used.
  /// </summary>
  public enum CompressionAlgorithms
  {
    zstd_stream,
    lz4_message,
    // deflate_stream is not supported in .NET Framework.
#if !NET452
    deflate_stream
#endif
  }

  internal class MySqlConnectAttrs
  {
    static string _version;
    static string _os;
    static string _platform;
    static string _osName;
    static string _framework;
#if NET452
    static string _osDetails;
#endif

    static MySqlConnectAttrs()
    {
      InitVersion();
      InitOS();
      InitPlatform();
      InitOSName();
      InitFramework();
#if NET452
      InitOSDetails();
#endif
    }

    [DisplayName("_client_name")]
    public string ClientName => "mysql-connector-net";

    [DisplayName("_client_licence")]
    public string ClientLicence
    {
      get
      {
#if COMMERCIAL
        return "Commercial";
#endif
        return "GPL-2.0";
      }
    }

    [DisplayName("_pid")]
    public string PID
    {
      get
      {
        string pid = string.Empty;
        try
        {
          pid = System.Diagnostics.Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.WriteLine(ex.ToString());
        }

        return pid;
      }
    }

    [DisplayName("_client_version")]
    public string ClientVersion
    {
      get { return _version; }
    }

    [DisplayName("_os")]
    public string OS
    {
      get { return _os; }
    }

    [DisplayName("_thread")]
    public string Thread
    {
      get
      {
        string thread = string.Empty;
        try
        {
          thread = System.Diagnostics.Process.GetCurrentProcess().Threads[0].Id.ToString(CultureInfo.InvariantCulture);
        }
        catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }

        return thread;
      }
    }

    [DisplayName("_platform")]
    public string Platform
    {
      get { return _platform; }
    }

#if NET452
    [DisplayName("_os_details")]
    public string OSDetails
    {
      get { return _osDetails; }
    }
#endif

    [DisplayName("_os")]
    public string OSName
    {
      get { return _osName; }
    }

    [DisplayName("_framework")]
    public string Framework
    {
      get { return _framework; }
    }

    private static void InitVersion()
    {
      _version = string.Empty;
      try
      {
        _version = typeof(MySqlConnectAttrs).GetTypeInfo().Assembly.GetName().Version.ToString();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.ToString());
      }
    }

    private static void InitOS()
    {
      _os = string.Empty;
      try
      {
        _os = Environment.OSVersion.Platform.ToString();
        if (_os == "Win32NT")
        {
          _os = "Win";
          _os += Is64BitOS() ? "64" : "32";
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.ToString());
      }
    }

    private static void InitPlatform()
    {
      _platform = Is64BitOS() ? "x86_64" : "x86_32";
    }

#if NET452
    private static void InitOSDetails()
    {
      _osDetails = string.Empty;

      try
      {
        var searcher = new System.Management.ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
        var collection = searcher.Get();
        foreach (var mgtObj in collection)
        {
          _osDetails = mgtObj.GetPropertyValue("Caption").ToString();
          break;
        }
      }
      catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
    }
#endif


    private static bool Is64BitOS()
    {
#if CLR4
      return Environment.Is64BitOperatingSystem;
#else
      return Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "AMD64";
#endif
    }

    private static void InitOSName()
    {
      _osName = _os;

      var osInfo = Environment.OSVersion;
      var major = osInfo.Version.Major;
      var minor = osInfo.Version.Minor;

      if (osInfo.Platform.ToString().StartsWith("Win"))
      {
        switch (major)
        {
          case 5:
            _osName = "Windows-XP-" + major + "." + minor;
            break;
          case 6:
            switch (minor)
            {
              case 0:
                _osName = "Windows-2008-" + major + "." + minor;
                break;
              case 1:
                _osName = "Windows-7-" + major + "." + minor;
                break;
              case 2:
                _osName = "Windows-8-" + major + "." + minor;
                break;
              case 3:
                _osName = "Windows-8.1-" + major + "." + minor;
                break;
            }
            break;
          case 10:
            _osName = "Windows-10-" + major + "." + minor;
            break;
          default:
            _osName = "Windows";
            break;
        }
      }
      else
        _osName = _os + "-" + major + "." + minor;
    }

    private static void InitFramework()
    {
      _framework = string.Empty;
      try
      {
        _framework = Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName;
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.ToString());
      }
    }
  }
}
