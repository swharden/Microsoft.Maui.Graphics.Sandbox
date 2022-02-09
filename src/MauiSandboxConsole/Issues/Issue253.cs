
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace MauiSandboxConsole.Issues;

public class Issue253
{
    public static void Run()
    {
        Random rand = new(0);
        using BitmapExportContext bmp = new SkiaBitmapExportContext(300, 200, 1.0f);
        ICanvas canvas = bmp.Canvas;

        // draw a test pattern in the background
        canvas.FillColor = Colors.DarkGray;
        canvas.FillRectangle(0, 0, bmp.Width, bmp.Height);
        canvas.StrokeSize = 3;
        canvas.StrokeColor = Colors.Black;
        for (int i = 0; i < bmp.Width * 2; i += 50)
            canvas.DrawLine(0, i, i, 0);

        PointF pt1 = new(100, 100);
        PointF pt2 = new(200, 100);
        float radius = 75;

        // fill a circle with a random color using a fluent method
        canvas.FillColor = Color.FromRgba(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), rand.Next(100, 200));
        canvas.FillCircle(pt1, radius);

        // fill a circle with a random color using a constructor
        canvas.FillColor = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), rand.Next(100, 200));
        canvas.FillCircle(pt2, radius);

        string filePath = Path.GetFullPath("Issue253.png");
        using FileStream fs = new(filePath, FileMode.Create);
        bmp.WriteToStream(fs);
        Console.WriteLine(filePath);
    }
}