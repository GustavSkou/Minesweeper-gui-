using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Minesweeper__gui_;

public class GameStateButton : IRestart
{
	private bool _state;
	private static readonly string _contentPath = "content/";
	Image image;
	Button buttonInstance;

	static private GameStateButton _instance = new GameStateButton();

	static public GameStateButton Instance { get { return _instance; } }

	public Button ButtonInstance
	{
		get { return buttonInstance; }
	}

	private GameStateButton ()
	{
		_state = true;
	}

	public void AliveState()
	{
		_state = true;
		SetImage ( _state );
		buttonInstance.Content = image;
	}
	public void DeadState ()
	{
		_state = false;
		SetImage ( _state );
		buttonInstance.Content = image;
	}

	public void RestartGame(MainWindow window)
	{
		Minefield.Instance.ResetMinefield ( window );
		AliveState ();
	}

	public void Draw(MainWindow window)
	{
		var panel = window.FindControl<StackPanel>("TopPanel");
		panel.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;

		SetImage ( _state );
		SetButton ( window );

		panel.Children.Add ( buttonInstance );
	}

	private void SetButton(MainWindow window)
	{
		buttonInstance = new Button ()
		{
			Content = image,
			Height = Cell.Height,
			Width = Cell.Width,
			Margin = new Avalonia.Thickness ( 0 ),
			Tag = this,
			HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
		};
		buttonInstance.Click += window.RestartClickHandler;
	}

	private void SetImage ( bool state )
	{
		Bitmap bitmap;
		if ( state )
		{
			bitmap = new Bitmap(_contentPath + "smiley.png");
		}
		else
		{
			bitmap = new Bitmap(_contentPath + "dead_smiley.png");
		}
		image = new Image ()
		{
			Source = bitmap,
			Height = Cell.Height,
			Width = Cell.Width
		};
	}
}