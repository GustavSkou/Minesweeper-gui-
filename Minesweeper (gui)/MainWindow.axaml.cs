using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Minesweeper__gui_
{
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();
            Minefield.Instance.Draw ( this );
        }

        public void CellClickHandler ( object? sender, RoutedEventArgs args )
        {
            // Checks both if cell is flagged and if cell is already revealed
            // Then it sets revealed to true, 
            // If it's a mine the override LeftClick method will be called

            if ( sender is Button button)
                if ( button.Tag is Cell cell)
                    cell.LeftClick (button);
        }

        public void CellRightClickHandler ( object? sender, RoutedEventArgs args )
        {
            if ( sender is Button button )
                if ( button.Tag is Cell cell )
                    cell.RightClick ( button );
        }

        public void CellLeftAndRightClickHandler (object? sender, RoutedEventArgs args)
        {
            if ( sender is Button button )
                if ( button.Tag is Cell cell )
                    cell.LeftAndRightClick ( button );
        }
    }
}