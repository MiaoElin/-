using System.Numerics;
using Raylib_cs;
public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 1200, "PLANE GAME");
        Raylib.SetTargetFPS(60);

        // 初始化
        Context con = new Context();
        con.Initialize();

        // 循环体 游戏界面
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            float dt = Raylib.GetFrameTime();

            // 全局 输入
            con.input.Process();

            // ===行为===
            // 登入页
            if (con.gameStatus == 0)
            {
                Raylib.ClearBackground(Color.GRAY);
                Login_Tick(ref con);
            }
            // 游戏中
            if (con.gameStatus == 1)
            {
                Raylib.ClearBackground(Color.LIGHTGRAY);
                Game_Tick(ref con, dt);
            }
            // 结束页
            if (con.gameStatus == 2)
            {   
                Raylib.ClearBackground(Color.GRAY);
                Logout_Tick(ref con);
            }

            // ===绘制===
            // 登入页
            if (con.gameStatus == 0)
            {
                Login_Draw(ref con);
            }
            // 游戏中
            if (con.gameStatus == 1)
            {
                Game_Draw(ref con);
            }
            // 结束页
            if (con.gameStatus == 2)
            {
                Logout_Draw(ref con);
            }

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();

    }
    // 登入页
    static void Login_Tick(ref Context con)
    {
        Login_Out_PanelController.LoginTick(ref con);
    }
    static void Login_Draw(ref Context con)
    {
        Login_Out_PanelController.LoginDraw(ref con);
    }
    // 游戏中
    static void Game_Tick(ref Context con, float dt)
    {
        // 我机 行为
        PlayerController.LogicTick(ref con, dt);
        // 子弹 行为
        BulletController.LogicTick(ref con,dt);
        // 敌人 行为
        EnemyController.LogicTick(ref con,dt);
        // 食物 行为
        FoodController.LogicTick(ref con,dt);
    }
    static void Game_Draw(ref Context con)
    {
        // 我机 绘制
        PlayerController.DrawAll(ref con);
        // 子弹 绘制
        BulletController.DrawAll(ref con);
        // 敌人 绘制
        EnemyController.DrawAll(ref con);
        // 食物绘制
        FoodController.Draw(ref con);
    }
    // 结束页
    static void Logout_Tick(ref Context con)
    {
        Login_Out_PanelController.LogoutTick(ref con);
    }
    static void Logout_Draw(ref Context con)
    {
        Login_Out_PanelController.LogoutDraw(ref con);

    }
}
