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

    public static void DrawAll(ref Context con, float scale)
    {
        ref PlaneEntity plane = ref con.plane;
        ref AssetsContext asset = ref con.assetsContext;
        if (!plane.isDead)
        {
            // 画飞机
            plane.Draw(scale);
        }
        else
        {
            con.gameStatus = 2;
        }


    }
}