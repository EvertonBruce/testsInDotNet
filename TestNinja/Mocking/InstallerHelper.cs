﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly string _setupDestinationFile;

        public InstallerHelper(string setupDestinationFile)
        {
            _setupDestinationFile = setupDestinationFile;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            var client = new WebClient();
            try
            {
                client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}