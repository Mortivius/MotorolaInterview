using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MarsRover {
    class Program {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args) {
            var lines = ReadLinesFromFile(@"dates.txt");

            foreach (var line in lines) {
                Console.WriteLine(line);
                await GetMarsRoverPhotosOnDate(ParseDateTimeFromString(line).ToString("yyyy-MM-dd"));
            }
        }

        public static async Task GetMarsRoverPhotosOnDate(string date) {
            //normally API key would be external and outside the source control tree
            var streamTask = client.GetStreamAsync($"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={date}&api_key=h2GGxDkhyN0MYuoKKGpvRqZPDoVVoC8kAFJFlDgC");
            var roverphotos = await JsonSerializer.DeserializeAsync<RoverPhotos>(await streamTask);
            
            foreach (var roverphoto in roverphotos.Photos) {
                var imageURL = roverphoto.ImageURL;
                var imageId = roverphoto.Id;
                Console.WriteLine($"{imageId}");

                DownloadFileFromUri(new Uri(imageURL), $"{date}_image{imageId}.jpeg");
                OpenUrl(imageURL);
            }
        }

        public static List<String> ReadLinesFromFile(string filename) {
            var lines = new List<String>();
            string line;

            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null) {
                lines.Add(line);
            }

            return lines;
        }

        public static DateTime ParseDateTimeFromString(string date) {
            try {
                return DateTime.Parse(date);
            }
            catch (FormatException e) {
                Console.WriteLine(e.ToString());
                return new DateTime();
            }
        }

        public static void DownloadFileFromUri(Uri uri, string filename) {
            using (WebClient wclient = new WebClient()) {
                wclient.DownloadFile(uri, filename);
            }
        }

        public static void OpenUrl(string url) {
            try {
                Process.Start(url);
            }
            catch {
                // because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    //Process.Start("xdg-open", url);
                    //https://stackoverflow.com/questions/54437534/docker-open-a-url-in-the-host-browser
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", url);
                }
                else {
                    throw;
                }
            }
        }
    }
}