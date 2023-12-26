using System.Numerics;
using Raylib_cs;
public static class Login_Out_PanelController
{
    public static void LoginTick(ref Context con)
    {
        ref InputEntity input = ref con.input;
        if (con.loginPanel.IsStaBtnDown(input.mousePos, input.isMousePressed))
        {
            con.gameStatus = 1;
        }
        if (con.loginPanel.IsExitBtnDown(input.mousePos, input.isMousePressed))
        {
            Raylib.CloseWindow();
        }
    }
    public static void LoginDraw(ref Context con,float scale)
    {
        con.loginPanel.Draw(scale);
    }
    public static void LogoutTick(ref Context con,float scale)
    {
        ref InputEntity input = ref con.input;
        if (con.logoutPanel.IsStaBtnDown(input.mousePos, input.isMousePressed))
        {   
            con.Initialize(scale);
            con.gameStatus = 1;
        }
        if (con.logoutPanel.IsExitBtnDown(input.mousePos, input.isMousePressed))
        {
            Raylib.CloseWindow();
        }
    }
    public static void LogoutDraw(ref Context con,float scale)
    {
        con.logoutPanel.Draw(scale);
    }
}