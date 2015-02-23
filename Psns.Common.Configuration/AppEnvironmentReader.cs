using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace Psns.Common.Configuration
{
    /// <summary>
    /// Represents each of the Application run environments
    /// </summary>
    public enum AppEnvironment
    {
        Local,
        Development,
        Test,
        Production
    }

    /// <summary>
    /// Determines the current Environment
    /// </summary>
    public interface IAppEnvironmentReader
    {
        /// <summary>
        /// The current runtime Environment
        /// </summary>
        AppEnvironment Current { get; }
    }

    /// <summary>
    /// Determines the current running Environment based on AppSetting key in .config file
    /// </summary>
    public class AppEnvironmentReader : IAppEnvironmentReader
    {
        /// <summary>
        /// The current running Evironment based on AppSetting key in .config file
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if Environment key is missing, or doesn't contain a valid AppEnvironemnt</exception>
        public AppEnvironment Current
        {
            get
            {
                var environmentString = ConfigurationManager.AppSettings["Environment"];
                if(string.IsNullOrEmpty(environmentString))
                    throw new InvalidOperationException("Environment AppSettings key is not set");

                var environment = AppEnvironment.Production;

                if(environmentString.Equals("Local"))
                    environment = AppEnvironment.Local;
                else if(environmentString.Equals("Development"))
                    environment = AppEnvironment.Development;
                else if(environmentString.Equals("Test"))
                    environment = AppEnvironment.Test;
                else if(!environmentString.Equals("Production"))
                    throw new InvalidOperationException("Environment AppSettings key value is not a valid AppEnvironment");

                return environment;
            }
        }
    }
}
