using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Minesweeper__gui_
{
    public partial class GameWindow : Window
    {
        private FlagCounter flagCounter;
        private Minefield minefield;
        private GameState gameState;
        private PanelGrid panel;
        private TimeCounter timeCounter;
        private GameContainer gameContainer;
        private ConsoleContainer consoleContainer;

        public GameWindow ()
        {
            InitializeComponent ();

            GameSettings settings = new GameSettings ( 9, 9, 10 );

            flagCounter = new FlagCounter 
            ( 
                settings 
            );
            minefield = new Minefield 
            ( 
                settings, 
                this, 
                (IFlagCount) flagCounter 
            );
            timeCounter = new TimeCounter ();
            gameState = new GameState 
            ( 
                this, 
                (IRestartGame) minefield, 
                (IRestartGame) flagCounter,
                (IRestartGame) timeCounter
            );
            panel = new PanelGrid (this);
            panel.Add ( flagCounter.StackPanel, 0 );
            panel.Add ( gameState.ButtonInstance, 1 );
            panel.Add ( timeCounter.StackPanel, 2 );


            gameContainer = new GameContainer 
            ( 
                this, 
                minefield.Grid
            );

            consoleContainer = new ConsoleContainer
            (
                this,
                gameContainer.Height,
                gameContainer.Width,
                panel.Height,
                panel.Width
            );

            SizeToContent = SizeToContent.WidthAndHeight;

            panel.Draw ();
            gameContainer.Draw (  );
            //consoleContainer.Draw ( );
            
        }

        public void CellClickHandler ( Object? sender, RoutedEventArgs args )
        {
            // Checks both if cell is flagged and if cell is already revealed
            // Then it sets revealed to true, 
            // If it's a mine the override LeftClick method will be called

            if ( sender is Button button )
                if ( button.Tag is IClickable cell )
                    cell.LeftClick ( button, gameState );
        }

        public void CellRightClickHandler ( Object? sender, RoutedEventArgs args )
        {
            if ( sender is Button button )
                if ( button.Tag is IClickable cell )
                    cell.RightClick ( button );
        }

        public void CellLeftAndRightClickHandler ( Object? sender, RoutedEventArgs args )
        {
            if ( sender is Button button )
                if ( button.Tag is Cell cell )
                    cell.LeftAndRightClick ( button );
        }

        public void RestartClickHandler ( Object? sender, RoutedEventArgs args )
        {
            if ( sender is Button button )
                if ( button.Tag is IClickable restartbutton )
                    restartbutton.LeftClick ( button, null );
        }
    }
}