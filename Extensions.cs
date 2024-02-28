using Microsoft.VisualBasic;
using SixLabors.ImageSharp.ColorSpaces.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace build_raster_map
{
    public enum MapType
    {
        Map,
        Satalite,
        Hybrid
    }

    public static class Extensions
    {
        public static Dictionary<MapType, string> mapTypes = new Dictionary<MapType, string>()
        {
            { MapType.Map, "m" },
            { MapType.Satalite, "s" },
            { MapType.Hybrid, "y" }
        };

        public static string GetMapType(this MapType mapType)
        {
            return mapTypes[mapType];
        }


        public static TileCoordinates ConvertCoordinates(double longitude, double latitude, int zoom)
        {
            var n = (int)Math.Pow(2, zoom);
            var x = (int)Math.Floor(n * ((longitude + 180) / 360));
            var latitude_rad = latitude * (Math.PI / 180);
            var y = (int)Math.Floor(n * (1 - (Math.Log(Math.Tan(latitude_rad) + (1 / Math.Cos(latitude_rad))) / Math.PI)) / 2);
            return new TileCoordinates { X = x, Y = y , Zoom = zoom };
        }
    }
}
