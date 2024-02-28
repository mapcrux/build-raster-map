using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace build_raster_map
{
    public static class ImageBuilder
    {
        private static ImageFetcher imageFetcher = new ImageFetcher();

        public static async Task<Image> BuildImageFromCoordinates(double longitude, double latitude, int zoom, int tileWidth, int tileHeight, MapType mapType)
        {
            Raster raster = new Raster(tileWidth, tileHeight);
            var originTile = Extensions.ConvertCoordinates(longitude, latitude, zoom);
            var raster_x = 0;
            var raster_y = 0;
            for (var y = originTile.Y; y < originTile.Y + tileHeight; y++)
            {
                for (var x = originTile.X; x < originTile.X + tileWidth; x++)
                {
                    var tileCoordinates = new TileCoordinates { X = x, Y = y, Zoom = zoom };
                    var image = await imageFetcher.FetchImage(MapType.Hybrid, tileCoordinates);
                    raster.Tiles[raster_x, raster_y] = new Tile { Coordinates = tileCoordinates, Image = image };
                    raster_x++;
                }
                raster_y++;
                raster_x = 0;
            }
            return raster.Combine();
        }
    }
}
