using System.IO;
using System.IO.Abstractions;

namespace CSharpGeneral
{
    public class IOAbstractions
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;

        public IOAbstractions(IFileSystem fileSystem, string inputFilePath, string outputFilePath)
        {
            this._fileSystem = fileSystem;
            this._inputFilePath = inputFilePath;
            this._outputFilePath = outputFilePath;
        }

        public void ToUpperCaseFile()
        {
            using (StreamReader streamReader = _fileSystem.File.OpenText(_inputFilePath))
            using (StreamWriter streamWriter = _fileSystem.File.CreateText(_outputFilePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    streamWriter.WriteLine(line.ToUpperInvariant());
                }
            }
        }
    }
}
