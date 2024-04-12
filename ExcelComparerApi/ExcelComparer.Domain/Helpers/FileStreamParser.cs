using Microsoft.AspNetCore.Http;
using System.Text;

namespace ExcelComparer.Domain.Helpers
{
    internal static class FileStreamParser
    {
        internal static async Task<FileStream> ParseFormFileAsync(IFormFile formFile, CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await formFile.CopyToAsync(ms, cancellationToken);
            ms.Seek(0, SeekOrigin.Begin);

            using var fileStream = new FileStream("tmpFile", FileMode.Create, System.IO.FileAccess.Write);
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, (int)ms.Length);
            fileStream.Write(bytes, 0, bytes.Length);
            ms.Close();

            return fileStream;
        }

        internal static FileStream ToCsv(string rawValues, string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.CreateNew);
            AddText(fileStream, rawValues);
            return fileStream;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
