using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace build_raster_map
{
    public class TileCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Zoom { get; set; }

    }

    public class Tile
    {
        public TileCoordinates Coordinates;
        public Image Image;
    }
}
