using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.WorkWithFiles
{
    public static class FileOperations
    {
        public static async Task CreateAndFillFileAsync(string webRootPath, IQueryable<WeatherModel> weatherModels)
        {
            string path = webRootPath + "/ArchivedData.txt";

            using (TextWriter tr = new StreamWriter(path, false))
            {
                foreach (var model in weatherModels)
                {
                    await tr.WriteLineAsync("{");
                    await tr.WriteLineAsync($"Id: {model.Id}");
                    await tr.WriteLineAsync($"Temperature (with time): {model.TemperatureWithTimeStemp}");
                    await tr.WriteLineAsync($"CityId: {model.CityId}");
                    await tr.WriteLineAsync("},");
                }
            }
        }

        public static async Task CompressFileAsync(string webRootPath)
        {
            string filePath = webRootPath + "/ArchivedData.txt";
            string targetPath = webRootPath + "/ArchivedData.gz";

            using (FileStream sourceStream = new FileStream(filePath, FileMode.Open))
            {
                using (FileStream targetStream = File.Create(targetPath))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        await sourceStream.CopyToAsync(compressionStream);
                    }
                }
            }
        }
    }
}
