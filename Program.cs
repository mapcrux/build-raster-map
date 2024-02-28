
using SixLabors.ImageSharp;

namespace build_raster_map;
public static class Program
{

    public async static Task Main(string[] args)
    {
        var image = await ImageBuilder.BuildImageFromCoordinates(-73.017027, 42.002839, 11, 3, 3, MapType.Hybrid);
        image.SaveAsPng("output.png");
    }
}