using Avalonia.Controls;

public interface IClickable
{
    void LeftClick ( Button button, ISetDeadState obj );
    void RightClick ( Button button );
}