using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IFileDownloader> _fileDownloader;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }



        [Test]
        public void DownloadInsTaller_FileIsDownloaded_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
        
        [Test]
        public void DownloadInsTaller_FileIsNotDownloaded_ReturnFalse()
        {
            _fileDownloader.Setup(wc => 
                    wc.DownloadFile(It.IsAny<string>(), It.IsAny<string>())
                )
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
    }
}
