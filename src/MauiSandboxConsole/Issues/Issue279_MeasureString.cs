using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace MauiSandboxConsole.Issues;

public static class Issue279_MeasureString
{
    public static void Run()
    {
        // setup a canvas with a blue background
        using BitmapExportContext bmp = new SkiaBitmapExportContext(450, 150, 1.0f);

        ICanvas canvas = bmp.Canvas;
        canvas.FillColor = Colors.Navy;
        canvas.FillRectangle(0, 0, bmp.Width, bmp.Height);

        // define and measure a string
        PointF stringLocation = new(50, 50);
        string stringText = "Hello, Maui.Graphics!";
        Font font = new("Consolas");
        float fontSize = 32;
        SizeF stringSize = canvas.GetStringSize(stringText, font, fontSize);
        Rectangle stringRect = new(stringLocation, stringSize);

        // draw the string and its outline
        canvas.StrokeColor = Colors.White;
        canvas.DrawRectangle(stringRect);
        canvas.FontColor = Colors.Yellow;
        canvas.FontSize = fontSize;
        canvas.Font = font;
        canvas.DrawString(
            value: stringText,
            x: stringLocation.X,
            y: stringLocation.Y,
            width: stringSize.Width,
            height: stringSize.Height,
            horizontalAlignment: HorizontalAlignment.Left,
            verticalAlignment: VerticalAlignment.Top,
            textFlow: TextFlow.OverflowBounds,
            lineSpacingAdjustment: 0);

        // save the result
        string filePath = Path.GetFullPath("Issue279.png");
        using FileStream fs = new(filePath, FileMode.Create);
        bmp.WriteToStream(fs);
        Console.WriteLine(filePath);
    }
}