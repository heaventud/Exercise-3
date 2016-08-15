using System;
using System.Configuration;

namespace AutoTests.Common
{
    /// <summary>
    /// The settings.
    /// </summary>
    public static class Settings
    {
        #region Static and Readonly Fields

        /// <summary>
        /// The default time span.
        /// </summary>
        private static readonly TimeSpan defaultTimeSpan = new TimeSpan(0, 0, 30);

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets the browser url.
        /// </summary>
        public static string BrowserUrl
        {
            get { return ConfigurationManager.AppSettings["BrowserUrl"]; }
        }

        /// <summary>
        /// Gets the default timeout.
        /// </summary>
        public static TimeSpan DefaultTimeout
        {
            get { return defaultTimeSpan; }
        }

        /// <summary>
        /// Gets or sets the web browser.
        /// </summary>
        public static string WebBrowser { get; set; }

        #endregion
    }
}
