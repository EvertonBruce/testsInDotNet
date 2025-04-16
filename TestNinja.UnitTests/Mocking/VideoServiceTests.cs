using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class VideoServiceTests
	{
		private VideoService _videoService;
		private Mock<IVideoRepository> _videoRepository;
		private Mock<IFileReader> _fileReader;

		[SetUp]
        public void SetUp()
		{
			_fileReader = new Mock<IFileReader>();
			_videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
		}

		[Test]
		public void ReadVideoTitle_EmptyFile_ReturnsError()
		{
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

			var result = _videoService.ReadVideoTitle();

			Assert.That(result, Does.Contain("error").IgnoreCase);
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AreThereUnprocessedVideos_ReturnsTheRightIds()
		{
			_videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>()
			{
				new Video{Id = 1},
				new Video{Id = 2},
				new Video{Id = 3},
				new Video{Id = 4}
			});

			var result = _videoService.GetUnprocessedVideosAsCsv();

			Assert.That(result, Is.EqualTo("1,2,3,4"));
		}

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnsEmptyString()
        {
			_videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
    }
}
