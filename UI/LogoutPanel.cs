using System.Numerics;
using Raylib_cs;

public struct LogoutPanel
{
    public GUIButton reStaBtn;
    public GUIButton exitBtn;
    public string ver;

    public bool IsStaBtnDown(Vector2 mouPos, bool isMousePressed)
    {
        if (reStaBtn.IsBtnDown(mouPos, isMousePressed))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsExitBtnDown(Vector2 mouPos, bool isMousePressed)
    {
        if (exitBtn.IsBtnDown(mouPos, isMousePressed))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Draw()
    {
        ver = "V1.0";
        reStaBtn.Draw();
        exitBtn.Draw();
        Raylib.DrawText(ver, 10, 10, 12, Color.WHITE);

    }
}