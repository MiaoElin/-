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
        ref AssetsHelper asset = ref con.asset;
        if (!plane.isDead)
        {
            // 画飞机
            Rectangle src = new Rectangle(0, 0, scale*32/6, scale*32/6);
            Rectangle dest = new Rectangle(plane.pos.X, plane.pos.Y, 60,60);
            Vector2 center = new Vector2(60/2,60/2);
            Raylib.DrawTexturePro(asset.player, src, dest, center, 0, Color.WHITE);

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