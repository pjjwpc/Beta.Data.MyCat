﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beta.Data.MyCatSqlClient {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourcesX {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourcesX() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Beta.Data.MyCat.ResourcesX", typeof(ResourcesX).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 Appdata path is not defined. 的本地化字符串。
        /// </summary>
        public static string AppdataNotDefined {
            get {
                return ResourceManager.GetString("AppdataNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Authentication failed using MYSQL41 and SHA256_MEMORY. Check the user name and password or try using a secure connection. 的本地化字符串。
        /// </summary>
        public static string AuthenticationFailed {
            get {
                return ResourceManager.GetString("AuthenticationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You can&apos;t get more sessions because Client is closed. 的本地化字符串。
        /// </summary>
        public static string ClientIsClosed {
            get {
                return ResourceManager.GetString("ClientIsClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Client option &apos;{0}&apos; does not support value &apos;{1}&apos;. 的本地化字符串。
        /// </summary>
        public static string ClientOptionInvalidValue {
            get {
                return ResourceManager.GetString("ClientOptionInvalidValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Client option &apos;{0}&apos; is not recognized as valid. 的本地化字符串。
        /// </summary>
        public static string ClientOptionNotValid {
            get {
                return ResourceManager.GetString("ClientOptionNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} &apos;{1}&apos; does not exist in schema &apos;{2}&apos;. 的本地化字符串。
        /// </summary>
        public static string CollectionTableDoesNotExist {
            get {
                return ResourceManager.GetString("CollectionTableDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Compression requested but the compression algorithm negotiation failed. 的本地化字符串。
        /// </summary>
        public static string CompressionAlgorithmNegotiationFailed {
            get {
                return ResourceManager.GetString("CompressionAlgorithmNegotiationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Compression using {0} is not supported. 的本地化字符串。
        /// </summary>
        public static string CompressionAlgorithmNotSupported {
            get {
                return ResourceManager.GetString("CompressionAlgorithmNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Failed to load libzstd.dll. Removing zstd_stream from the client supported compression algorithms. 的本地化字符串。
        /// </summary>
        public static string CompressionFailedToLoadLibzstdAssembly {
            get {
                return ResourceManager.GetString("CompressionFailedToLoadLibzstdAssembly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Compression using {0} is not supported in .NET Framework. 的本地化字符串。
        /// </summary>
        public static string CompressionForSpecificAlgorithmNotSupportedInNetFramework {
            get {
                return ResourceManager.GetString("CompressionForSpecificAlgorithmNotSupportedInNetFramework", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The connection property &apos;compression&apos; acceptable values are: &apos;preferred&apos;, &apos;required&apos; or &apos;disabled&apos;. The value &apos;{0}&apos; is not acceptable. 的本地化字符串。
        /// </summary>
        public static string CompressionInvalidValue {
            get {
                return ResourceManager.GetString("CompressionInvalidValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Compression is not enabled. 的本地化字符串。
        /// </summary>
        public static string CompressionNotEnabled {
            get {
                return ResourceManager.GetString("CompressionNotEnabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Compression requested but the server does not support it. 的本地化字符串。
        /// </summary>
        public static string CompressionNotSupportedByServer {
            get {
                return ResourceManager.GetString("CompressionNotSupportedByServer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 There are still decompressed messages pending to be processed. 的本地化字符串。
        /// </summary>
        public static string CompressionPendingMessagesToProcess {
            get {
                return ResourceManager.GetString("CompressionPendingMessagesToProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &apos;{0}&apos; cannot be set to false with DNS SRV lookup enabled. 的本地化字符串。
        /// </summary>
        public static string DnsSrvConflictingOptions {
            get {
                return ResourceManager.GetString("DnsSrvConflictingOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Scheme &apos;{0}&apos; is not valid. 的本地化字符串。
        /// </summary>
        public static string DnsSrvInvalidScheme {
            get {
                return ResourceManager.GetString("DnsSrvInvalidScheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Duplicate key &apos;{0}&apos; used in &quot;connection-attributes&quot;. 的本地化字符串。
        /// </summary>
        public static string DuplicateUserDefinedAttribute {
            get {
                return ResourceManager.GetString("DuplicateUserDefinedAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Key name in connection attribute cannot be an empty string. 的本地化字符串。
        /// </summary>
        public static string EmptyKeyConnectionAttribute {
            get {
                return ResourceManager.GetString("EmptyKeyConnectionAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 At least one option must be specified. 的本地化字符串。
        /// </summary>
        public static string EmptyOptions {
            get {
                return ResourceManager.GetString("EmptyOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 This feature is currently not supported. 的本地化字符串。
        /// </summary>
        public static string FeatureNotSupported {
            get {
                return ResourceManager.GetString("FeatureNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 This functionality is only supported in MySQL {0} and higher. 的本地化字符串。
        /// </summary>
        public static string FunctionalityNotSupported {
            get {
                return ResourceManager.GetString("FunctionalityNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Collation with id &apos;{0}&apos; not found. 的本地化字符串。
        /// </summary>
        public static string InvalidCollationId {
            get {
                return ResourceManager.GetString("InvalidCollationId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The value of &quot;connection-attributes&quot; must be either a boolean or a list of key-value pairs. 的本地化字符串。
        /// </summary>
        public static string InvalidConnectionAttributes {
            get {
                return ResourceManager.GetString("InvalidConnectionAttributes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Connection Data is incorrect. 的本地化字符串。
        /// </summary>
        public static string InvalidConnectionData {
            get {
                return ResourceManager.GetString("InvalidConnectionData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The connection string is invalid. 的本地化字符串。
        /// </summary>
        public static string InvalidConnectionString {
            get {
                return ResourceManager.GetString("InvalidConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &apos;{0}&apos; is not a valid connection string attribute. 的本地化字符串。
        /// </summary>
        public static string InvalidConnectionStringAttribute {
            get {
                return ResourceManager.GetString("InvalidConnectionStringAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The connection timeout value must be a positive integer (including 0). 的本地化字符串。
        /// </summary>
        public static string InvalidConnectionTimeoutValue {
            get {
                return ResourceManager.GetString("InvalidConnectionTimeoutValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Decimal (BCD) format is invalid. 的本地化字符串。
        /// </summary>
        public static string InvalidDecimalFormat {
            get {
                return ResourceManager.GetString("InvalidDecimalFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Field type with name &apos;{0}&apos; not found. 的本地化字符串。
        /// </summary>
        public static string InvalidFieldType {
            get {
                return ResourceManager.GetString("InvalidFieldType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Index type with name &apos;{0}&apos; not found. 的本地化字符串。
        /// </summary>
        public static string InvalidIndexType {
            get {
                return ResourceManager.GetString("InvalidIndexType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The value provided is not a valid JSON document. {0} 的本地化字符串。
        /// </summary>
        public static string InvalidJsonDocument {
            get {
                return ResourceManager.GetString("InvalidJsonDocument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} is not a valid column name in the row. 的本地化字符串。
        /// </summary>
        public static string InvalidNameIndex {
            get {
                return ResourceManager.GetString("InvalidNameIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} is not a valid index for the row. 的本地化字符串。
        /// </summary>
        public static string InvalidRowIndex {
            get {
                return ResourceManager.GetString("InvalidRowIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Session state is not valid. 的本地化字符串。
        /// </summary>
        public static string InvalidSession {
            get {
                return ResourceManager.GetString("InvalidSession", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Invalid Uri  的本地化字符串。
        /// </summary>
        public static string InvalidUriData {
            get {
                return ResourceManager.GetString("InvalidUriData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Invalid uri query value 的本地化字符串。
        /// </summary>
        public static string InvalidUriQuery {
            get {
                return ResourceManager.GetString("InvalidUriQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Key names in &quot;connection-attributes&quot; cannot start with &quot;_&quot;. 的本地化字符串。
        /// </summary>
        public static string InvalidUserDefinedAttribute {
            get {
                return ResourceManager.GetString("InvalidUserDefinedAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Json configuration must contain &apos;uri&apos; or &apos;host&apos; but not both. 的本地化字符串。
        /// </summary>
        public static string JsonUriOrHost {
            get {
                return ResourceManager.GetString("JsonUriOrHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Keyword &apos;{0}&apos; not found. 的本地化字符串。
        /// </summary>
        public static string KeywordNotFound {
            get {
                return ResourceManager.GetString("KeywordNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Keyword not supported. 的本地化字符串。
        /// </summary>
        public static string KeywordNotSupported {
            get {
                return ResourceManager.GetString("KeywordNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Field &apos;{0}&apos; is mandatory. 的本地化字符串。
        /// </summary>
        public static string MandatoryFieldNotFound {
            get {
                return ResourceManager.GetString("MandatoryFieldNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Missed required schema option. 的本地化字符串。
        /// </summary>
        public static string MissingSchemaOption {
            get {
                return ResourceManager.GetString("MissingSchemaOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 More than one document id was generated.  Please use the DocumentIds property instead. 的本地化字符串。
        /// </summary>
        public static string MoreThanOneDocumentId {
            get {
                return ResourceManager.GetString("MoreThanOneDocumentId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 There is no data at index {0} 的本地化字符串。
        /// </summary>
        public static string NoDataAtIndex {
            get {
                return ResourceManager.GetString("NoDataAtIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 No &apos;host&apos; has been specified. 的本地化字符串。
        /// </summary>
        public static string NoHost {
            get {
                return ResourceManager.GetString("NoHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 No more data in resultset. 的本地化字符串。
        /// </summary>
        public static string NoMoreData {
            get {
                return ResourceManager.GetString("NoMoreData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Object &apos;{0}&apos; not found 的本地化字符串。
        /// </summary>
        public static string NoObjectFound {
            get {
                return ResourceManager.GetString("NoObjectFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 No placeholders. 的本地化字符串。
        /// </summary>
        public static string NoPlaceholders {
            get {
                return ResourceManager.GetString("NoPlaceholders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} must be a value greater than 0. 的本地化字符串。
        /// </summary>
        public static string NumberNotGreaterThanZero {
            get {
                return ResourceManager.GetString("NumberNotGreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Path not found &apos;{0}&apos;. 的本地化字符串。
        /// </summary>
        public static string PathNotFound {
            get {
                return ResourceManager.GetString("PathNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Queue timeout expired. The timeout period elapsed prior to getting a session from the pool. 的本地化字符串。
        /// </summary>
        public static string PoolingQueueTimeout {
            get {
                return ResourceManager.GetString("PoolingQueueTimeout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Providing a port number as part of the host address isn&apos;t supported when using connection strings in basic format or anonymous objects. Use URI format instead. 的本地化字符串。
        /// </summary>
        public static string PortNotSupported {
            get {
                return ResourceManager.GetString("PortNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You must either assign no priority to any of the hosts or give a priority for every host. 的本地化字符串。
        /// </summary>
        public static string PriorityForAllOrNoHosts {
            get {
                return ResourceManager.GetString("PriorityForAllOrNoHosts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The priority must be between 0 and 100. 的本地化字符串。
        /// </summary>
        public static string PriorityOutOfLimits {
            get {
                return ResourceManager.GetString("PriorityOutOfLimits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ProgramData path is not defined. 的本地化字符串。
        /// </summary>
        public static string ProgramDataNotDefined {
            get {
                return ResourceManager.GetString("ProgramDataNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The server doesn&apos;t support the requested operation. Please update the MySQL Server, client library, or both. 的本地化字符串。
        /// </summary>
        public static string SchemaCreateCollectionMsg {
            get {
                return ResourceManager.GetString("SchemaCreateCollectionMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The process of closing the resultset and resulted in results being lost. 的本地化字符串。
        /// </summary>
        public static string ThrowingAwayResults {
            get {
                return ResourceManager.GetString("ThrowingAwayResults", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 All server connection attempts were aborted. Timeout of {0} milliseconds was exceeded for each selected server. 的本地化字符串。
        /// </summary>
        public static string TimeOutMultipleHost {
            get {
                return ResourceManager.GetString("TimeOutMultipleHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 All server connection attempts were aborted. Timeout was exceeded for each selected server. 的本地化字符串。
        /// </summary>
        public static string TimeOutMultipleHost0ms {
            get {
                return ResourceManager.GetString("TimeOutMultipleHost0ms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Connection attempt to the server was aborted. Timeout of {0} milliseconds was exceeded. 的本地化字符串。
        /// </summary>
        public static string TimeOutSingleHost {
            get {
                return ResourceManager.GetString("TimeOutSingleHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Connection attempt to the server was aborted. Timeout was exceeded. 的本地化字符串。
        /// </summary>
        public static string TimeOutSingleHost0ms {
            get {
                return ResourceManager.GetString("TimeOutSingleHost0ms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unable to connect to any specified host. 的本地化字符串。
        /// </summary>
        public static string UnableToConnect {
            get {
                return ResourceManager.GetString("UnableToConnect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unable to read or decode data value. 的本地化字符串。
        /// </summary>
        public static string UnableToDecodeDataValue {
            get {
                return ResourceManager.GetString("UnableToDecodeDataValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unable to open a session. 的本地化字符串。
        /// </summary>
        public static string UnableToOpenSession {
            get {
                return ResourceManager.GetString("UnableToOpenSession", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unexpected end of packet found while reading data values 的本地化字符串。
        /// </summary>
        public static string UnexpectedEndOfPacketFound {
            get {
                return ResourceManager.GetString("UnexpectedEndOfPacketFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Field name &apos;{0}&apos; is not allowed. 的本地化字符串。
        /// </summary>
        public static string UnexpectedField {
            get {
                return ResourceManager.GetString("UnexpectedField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unknown placeholder :{0} 的本地化字符串。
        /// </summary>
        public static string UnknownPlaceholder {
            get {
                return ResourceManager.GetString("UnknownPlaceholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Value &apos;{0}&apos; is not of the correct type. 的本地化字符串。
        /// </summary>
        public static string ValueNotCorrectType {
            get {
                return ResourceManager.GetString("ValueNotCorrectType", resourceCulture);
            }
        }
    }
}
