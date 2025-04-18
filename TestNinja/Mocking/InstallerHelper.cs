﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly string _setupDestinationFile;
        private IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader webClientRepository = null)
        {
            _fileDownloader = webClientRepository ?? new FileDownloader();

        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName
                    ),
                    _setupDestinationFile
                );

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}