using System.Numerics;
using Raylib_cs;

public static class PlayerController
{

    public static void LogicTick(ref Context con, float dt)
    {
        ref PlaneEntity plane = ref con.plane;
        ref InputEntity input = ref con.input;
        // 飞机移动
        plane.Move(input.moveAxis, dt);



    }

    public static void DrawAll(ref Context con)
    {
        ref PlaneEntity plane = ref con.plane;
        if (!plane.isDead)
        {
            Raylib.DrawCircleV(plane.pos, plane.radius, plane.color);
            int planeHpInScreen = plane.hp*2;
            string text =plane.hp.ToString();
            con.guiHP.Draw(text, planeHpInScreen);
        }else{
            con.gameStatus=2;
        }


    }
}