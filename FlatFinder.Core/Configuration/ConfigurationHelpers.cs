using System;
using System.Collections.Specialized;
using System.Globalization;

namespace FlatFinder.Core.Configuration
{
    public static class ConfigurationHelpers
    {
        #region Extension methods

        public static int ReadParamAsInt(this NameValueCollection appSettings, string paramName)
        {
            return ParseParam(appSettings, paramName, int.Parse);
        }

        public static string ReadParamAsString(this NameValueCollection appSettings, string paramName)
        {
            return ParseParam(appSettings, paramName, x => x);
        }

        public static bool ReadParamAsBoolean(this NameValueCollection appSettings, string paramName)
        {
            return ParseParam(appSettings, paramName, bool.Parse);
        }

        public static int ReadRequiredParamAsInt(this NameValueCollection appSettings, string paramName)
        {
            return ParseRequiredParam(appSettings, paramName, int.Parse);
        }

        public static string ReadRequiredParamAsString(this NameValueCollection appSettings, string paramName)
        {
            return ParseRequiredParam(appSettings, paramName, x => x);
        }

        public static bool ReadRequiredParamAsBoolean(this NameValueCollection appSettings, string paramName)
        {
            return ParseRequiredParam(appSettings, paramName, bool.Parse);
        }

        public static double ReadRequiredParamAsDouble(this NameValueCollection appSettings, string paramName)
        {
            return ParseRequiredParam(appSettings, paramName, x => double.Parse(x, NumberFormatInfo.InvariantInfo));
        }

        #endregion

        #region Helper methods

        private static string ReadParam(NameValueCollection appSettings, string paramName)
        {
            return appSettings[paramName];
        }

        private static void CheckNull(string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                throw new Exception(string.Format("Required configuration param {0} is missing.", paramName));
            }
        }

        private static T ParseParam<T>(NameValueCollection appSettings, string paramName, Func<string, T> parser)
        {
            var value = ReadParam(appSettings, paramName);

            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }

            try
            {
                return parser(value);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Parameter {0} can not be parsed as {1}", paramName, typeof(T)), e);
            }
        }

        private static T ParseRequiredParam<T>(NameValueCollection appSettings, string paramName, Func<string, T> parser)
        {
            var value = ReadParam(appSettings, paramName);

            CheckNull(paramName, value);

            try
            {
                return parser(value);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Parameter {0} can not be parsed as {1}", paramName, typeof(T)), e);
            }
        }

        #endregion
    }
}