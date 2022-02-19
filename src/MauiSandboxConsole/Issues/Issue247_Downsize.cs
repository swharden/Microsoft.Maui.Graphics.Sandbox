
using Microsoft.Maui.Graphics;

namespace MauiSandboxConsole.Issues;

public class Issue247_Downsize
{
    public static void Run()
    {
        using var bmp = new Microsoft.Maui.Graphics.Skia.SkiaBitmapExportContext(300, 200, 1.0f);

        ICanvas canvas = bmp.Canvas;

        IImage original = LoadImageWithSkia("../../../images/bird.jpg");
        Console.WriteLine($"original: {original.Width}x{original.Height}");

        IImage thumb = original.Downsize(200);
        //Console.WriteLine($"thumb: {thumb.Width}x{thumb.Height}");
        FileStream fs = new("Issue247.jpg", FileMode.Create);
        thumb.Save(fs, ImageFormat.Jpeg);
    }

    public static IImage LoadImageWithSkia(string filePath)
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        MemoryStream memstr = new(bytes);
        //var img = new Microsoft.Maui.Graphics.Skia.SkiaImageLoadingService;
        IImage img = new Microsoft.Maui.Graphics.Skia.SkiaImage(SkiaSharp.SKBitmap.Decode(memstr));
        return img;
    }
}