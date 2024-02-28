using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace build_raster_map
{
    public class ImageFetcher
    {
        HttpClient client = new HttpClient();
        public ImageFetcher()
        {
            client.BaseAddress = new Uri("https://mt1.google.com/vt/");
            
            client.DefaultRequestHeaders.Add("authority", "mt1.google.com");
            client.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            client.DefaultRequestHeaders.Add("accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("cache-control", "max-age=0");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Chromium\";v=\"122\", \"Not(A,Brand\";v=\"24\", \"Microsoft Edge\";v=\"122\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-arch", "\"x86\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-bitness", "\"64\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-full-version-list", "\"Chromium\";v=\"122.0.6261.70\", \"Not(A,Brand\";v=\"24.0.0.0\", \"Microsoft Edge\";v=\"122.0.2365.52\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-model", "\"\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform-version", "\"15.0.0\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-wow64", "?0");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "document");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "navigate");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "none");
            client.DefaultRequestHeaders.Add("sec-fetch-user", "?1");
            client.DefaultRequestHeaders.Add("upgrade-insecure-requests", "1");
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0");
        }
        public async Task<Image> FetchImage(MapType mapType, TileCoordinates c)
        {
            Thread.Sleep(100);
            var queryString = $"lyrs={mapType.GetMapType()}&x={c.X}&y={c.Y}&z={c.Zoom}";
            try
            {
                var response = await client.GetAsync(queryString);
                using (var s = response.Content.ReadAsStream())
                {

                    Image image = Image.Load(s);
                    return image;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
