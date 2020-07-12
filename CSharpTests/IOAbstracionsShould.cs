using CSharpGeneral;
using System.IO.Abstractions.TestingHelpers;
using Xunit;

namespace CSharpTests
{
    public class IOAbstracionsShould
    {
        [Fact]
        public void CreateNewFileWithUppercaseText()
        {
            var line1 = "This is the first line";
            var mockInputFile = new MockFileData(line1+ "\nThis is the 2nd line\nLast line.");

            var mockFileSystem = new MockFileSystem();
            string inputFilePath = @"c:\in\file1.xt";
            string outputFilePath = @"c:\out\file1.txt";
            mockFileSystem.AddFile(inputFilePath, mockInputFile);
            mockFileSystem.AddDirectory(@"c:\out");

            var sut = new IOAbstractions(mockFileSystem, inputFilePath, outputFilePath);

            sut.ToUpperCaseFile();

            Assert.True(mockFileSystem.FileExists(outputFilePath));

            MockFileData processedfile = mockFileSystem.GetFile(outputFilePath);
            string[] lines = processedfile.TextContents.SplitLines();

            Assert.Equal(line1.ToUpperInvariant(), lines[0]);
        }
    }
}
