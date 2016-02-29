using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdu.Data.Helpers
{
    public static class ConfigHelper
    {
        /// <summary>
        /// attempts to get an app setting, returning a default if not found or not castable.
        /// </summary>
        /// <typeparam name="T">Type of the value you want</typeparam>
        /// <param name="key">Key Name e.g. "TimeoutValue" </param>
        /// <param name="defaultValue">if not found or wrong type, what should we use?</param>
        /// <param name="errorOnWrongType">blow up if it won't cast cleanly</param>
        /// <returns></returns>
        public static T GetAppSetting<T>(string key, T defaultValue, bool errorOnWrongType = false)
        {
            var result = ConfigurationManager.AppSettings.Get(key);
            if (string.IsNullOrEmpty(result))
            {
                return defaultValue;
            }

            if (result is T)
            {
                return (T)Convert.ChangeType(result, typeof(T));
            }
            //try casting anyway...
            try
            {
               return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception)
            {
                if (errorOnWrongType)
                {
                    throw new ConfigurationErrorsException(string.Format("Problem fetching {0} as {1}.  It's a {2}",key,typeof (T).Name, result.GetType().Name));
                }

                return defaultValue;
            }
            
        }
    }
}
