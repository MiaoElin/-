using System.Numerics;
using Raylib_cs;

public struct InputEntity
{
    public Vector2 moveAxis;
    public bool isMousePressed;
    public Vector2 mousePos;
    public bool isSpacePressed;
    public void Process()
    {
        float x = 0;
        float y = 0;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            y =-1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            y = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            x = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            x = 1;
        }

        moveAxis.X = x;
        moveAxis.Y = y;

        isMousePressed = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
        mousePos = Raylib.GetMousePosition();
        isSpacePressed = Raylib.IsKeyDown(KeyboardKey.KEY_SPACE);
    }

}