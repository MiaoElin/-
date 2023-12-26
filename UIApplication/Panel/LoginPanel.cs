using System.Numerics;
using Raylib_cs;

public struct LoginPanel
{
    public GUIButton startBtn;
    public GUIButton exitBtn;

    public string ver;

    public bool IsStaBtnDown(Vector2 mouPos, bool isMousePressed)
    {
        if (startBtn.IsBtnDown(mouPos, isMousePressed))
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
    public void Draw(float scale){
        ver = "V1.0";
        startBtn.Draw(scale);
        exitBtn.Draw(scale);
        Raylib.DrawText(ver,10,10,12,Color.WHITE);

    }
}