using System;
using Avalonia.Controls;

public class Mine : Cell
{
	public Mine(int x, int y) : base (x, y)
    {
        _symbol = '¤';
    }

	public override void Reveal ( Button button )
    {
        base.Reveal ( button );
        Console.WriteLine ( "Game Over" );
    }
}
