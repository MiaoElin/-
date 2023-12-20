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
            Console.WriteLine("kkkk");
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
            Console.WriteLine("llll");
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Draw(){
        ver = "V1.0";
        startBtn.Draw();
        exitBtn.Draw();
        Raylib.DrawText(ver,10,10,12,Color.WHITE);

    }
}