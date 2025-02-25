using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;

public class GameStateImageHandler
{
    private static readonly string _contentPath = "content/game_state_image/";
    private static double _height = Cell.Height;
    private static double _width = Cell.Width;


    public static Image Alive
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "smiley.png" ),
                Height = _height,
                Width = _width
            };
        }
    }
    public static Image Dead
    {
        get
        {
            return new Image
            {
                Source = new Bitmap ( _contentPath + "dead_smiley.png" ),
                Height = _height,
                Width = _width
            };
        }
    }

    public static Image ImageState ( bool state )
    {
        if ( state )
            return Alive;
        else
            return Dead;
    }
}