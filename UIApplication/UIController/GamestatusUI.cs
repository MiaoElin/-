using System.Numerics;
using Raylib_cs;
public static class GamestatusUI{
    public static void Draw(ref Context con, float scale)
    {
        ref PlaneEntity plane = ref con.plane;
        if (!plane.isDead)
        {
            //画guiHP
            int planeHpInScreen = plane.hp * 2;
            string text = "100/" + plane.hp.ToString();
            con.guiHP.Draw(text, planeHpInScreen, scale);
        }
        else
        {
            con.gameStatus = 2;
        }


    }
}
