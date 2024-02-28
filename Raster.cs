using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace build_raster_map
{
    public class Raster
    {
        public Tile[,] Tiles;
        private int tileWidth;
        private int tileHeight;
        public Raster(int tileWidth, int tileHeight)
        {
            Tiles = new Tile[tileWidth,tileHeight];
            this.tileHeight = tileHeight;
            this.tileWidth = tileWidth;
        }

        public Image Combine()
        {

            if (Tiles[0,0].Image != null)
            {
                var imageWidth = Tiles[0,0].Image.Width;
                var imageHeight = Tiles[0,0].Image.Height;
                Image<Rgb24> outputImage = new Image<Rgb24>(imageWidth * tileWidth, imageHeight * tileHeight);
                for (int x = 0; x < tileWidth; x++)
                {
                    for (int y = 0; y < tileHeight; y++)
                    {
                        var tile = Tiles[x,y];
                        outputImage.Mutate(o => o.DrawImage(tile.Image, new Point(x * imageWidth, y * imageHeight), 1f));
                    }
                }
                return outputImage;
            }
            else return new Image<Rgba32>(0,0);
        }
    }
}
