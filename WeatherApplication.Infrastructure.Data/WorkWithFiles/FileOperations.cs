using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces.ResponseModels.Weather;

namespace WeatherApplication.Infrastructure.Data.WorkWithFiles
{
    public static class FileOperations
    {
        //Creates CityName.json file in webRootPath/Files
        public static async Task CreateAndFillFileAsync(string webRootPath, string cityName, IEnumerable<GetWeatherHistoryResponse> response)
        {
            string folderPath = webRootPath + "/Files";
            string filePath = folderPath + $"/{cityName}.json";

            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                foreach (var r in response)
                {
                    await JsonSerializer.SerializeAsync(fs, r);
                }
            }
        }

        //Updates compressed file in webRootPath
        public static void CompressFile(string webRootPath)
        {
            string sourceDirectory = webRootPath + "/Files";
            string filePath = webRootPath + "/ArchivedData.zip";

            File.Delete(filePath);

            ZipFile.CreateFromDirectory(sourceDirectory, filePath, CompressionLevel.Optimal, false);
        }

        //Deletes CityName.json file
        public static void DeleteArchivedDataOfCity(string webRootPath, string cityName)
        {
            string folderPath = webRootPath + "/Files";
            string filePath = folderPath + $"/{cityName}.json";

            File.Delete(filePath);
            CompressFile(webRootPath);
        }
    }
}
