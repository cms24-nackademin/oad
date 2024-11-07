using Moq;
using ProductProvider.Data.Interfaces;

namespace ProductProvider.Tests.Data;

public class FileService_Tests
{
    private readonly Mock<IFileService> _mockFileService;
	private readonly IFileService _fileService;

	public FileService_Tests()
	{
		_mockFileService = new Mock<IFileService>();
		_fileService = _mockFileService.Object;
	}

	[Fact]
	public void SaveToFile_ShouldReturnTrue_WhenContentIsSaved()
	{
		// Arrange
		_mockFileService.Setup(x => x.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

		// Act
		var result = _fileService.SaveToFile(It.IsAny<string>(), "Hello World!");

		// Assert
		Assert.True(result);
	}

	[Fact]
	public void GetContentFromFile_ShouldReturnStringContent()
	{
        // Arrange
        _mockFileService.Setup(x => x.GetContentFromFile(It.IsAny<string>())).Returns("Hello World!");

		// Act
		var result = _fileService.GetContentFromFile(It.IsAny<string>());

		// Assert
		Assert.Equal("Hello World!", result);
    }
}
