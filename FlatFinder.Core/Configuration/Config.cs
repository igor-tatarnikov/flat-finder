using System.Collections.Specialized;
using System.Configuration;

namespace FlatFinder.Core.Configuration
{
    public static class Config
    {
        #region Constants

        private const string SmtpServerParamName = "smtpServer";
        private const string SmtpServerportParamName = "smtpServerPort";
        private const string SmtpUserParamName = "smtpUser";
        private const string SmtpUserDisplayParamName = "smtpUserDisplayName";
        private const string SmtpPasswordParamName = "smtpPassword";
        private const string SmtpEnableSslParamName = "smtpEnableSsl";

        private const string DatabaseConnectionStringName = "default";

        private const string MaxInvalidPasswordAttemptsParamName = "MaxInvalidPasswordAttempts";

        private const string CurrentEnvironmentParamName = "Environment";

        private const string SystemUserIdParamName = "systemUserId";

        #endregion

        #region Settings

        public static string EncryptionKey
        {
            get
            {
                return @"QD0kyjKkzNMf6SHG";
            }
        }

        public static string DatabaseConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DatabaseConnectionStringName].ConnectionString;
            }
        }

        public static string CurrentEnvironmentString
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadRequiredParamAsString(CurrentEnvironmentParamName);
            }
        }

        public static string SmtpServer
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadRequiredParamAsString(SmtpServerParamName);
            }
        }

        public static int SmtpServerPort
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadParamAsInt(SmtpServerportParamName);
            }
        }

        public static string SmtpUser
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadRequiredParamAsString(SmtpUserParamName);
            }
        }

        public static string SmtpUserDisplayName
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadParamAsString(SmtpUserDisplayParamName);
            }
        }

        public static string SmtpPassword
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadRequiredParamAsString(SmtpPasswordParamName);
            }
        }

        public static bool SmtpEnableSsl
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadRequiredParamAsBoolean(SmtpEnableSslParamName);
            }
        }

        public static int MaxInvalidPasswordAttempts
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadParamAsInt(MaxInvalidPasswordAttemptsParamName);
            }
        }

        public static int SystemUserId
        {
            get
            {
                return ConfigurationManager.AppSettings.ReadParamAsInt(SystemUserIdParamName);
            }
        }

        #endregion

        #region Helpers

        public static NameValueCollection GetConfigSection(string key)
        {
            return ConfigurationManager.GetSection(key) as NameValueCollection;
        }

        #endregion
    }
}
