using ConsoleAppProject.Services;
using ConsoleAppProject.Tests.Interfaces;

namespace ConsoleApp.Tests;

    public class FileService_Tests
    {
    [Fact]

    public void ShouldSaveToFile_SaveContentToFile_ReturnTrue()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filepath = @"C:\Projects\CSharp\ConsoleAppProject\testing;";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filepath, content);

        // Assert
        Assert.True(result);
    }
}

