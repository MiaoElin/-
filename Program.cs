using System.Numerics;
using Raylib_cs;
public class Program
{
    public static void Main()
    {
        float scale = 6;
        Raylib.InitWindow((int)scale * 120, (int)scale * 180, "PLANE GAME");
        Raylib.SetTargetFPS(60);

        // 初始化
        Context con = new Context();
        con.Initialize(scale);
        // 从文件加载图片
        // Texture2D plane = Raylib.LoadTexture("Assets/plane.png");

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
                // 

                Login_Tick(ref con);
            }
            // 游戏中
            if (con.gameStatus == 1)
            {
                Raylib.ClearBackground(Color.LIGHTGRAY);
                // Vector2 planePos = new Vector2(55 * scale, 175 * scale);
                // Raylib.DrawTexture(player, (int)(scale*planePos.X/6), (int)(scale*planePos.Y/6), Color.WHITE);
                
                Game_Tick(ref con, dt, scale);
            }
            // 结束页
            if (con.gameStatus == 2)
            {
                Raylib.ClearBackground(Color.GRAY);
                Logout_Tick(ref con, scale);
            }

            // ===绘制===
            // 登入页
            if (con.gameStatus == 0)
            {
                Login_Draw(ref con, scale);
            }
            // 游戏中
            if (con.gameStatus == 1)
            {
                Game_Draw(ref con, scale);
            }
            // 结束页
            if (con.gameStatus == 2)
            {
                Logout_Draw(ref con, scale);
            }
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
        con.asset.UnloadTexture();


    }
    // 登入页
    static void Login_Tick(ref Context con)
    {
        Login_Out_PanelController.LoginTick(ref con);
    }
    static void Login_Draw(ref Context con, float scale)
    {
        Login_Out_PanelController.LoginDraw(ref con, scale);
    }
    // 游戏中
    static void Game_Tick(ref Context con, float dt, float scale)
    {
        // 我机 行为
        PlayerController.LogicTick(ref con, dt);
        // 子弹 行为
        BulletController.LogicTick(ref con, dt, scale);
        // 敌人 行为
        EnemyController.LogicTick(ref con, dt, scale);
        // 食物 行为
        FoodController.LogicTick(ref con, dt, scale);
    }
    static void Game_Draw(ref Context con, float scale)
    {
        // 我机 绘制
        PlayerController.DrawAll(ref con, scale);
        // 子弹 绘制
        BulletController.DrawAll(ref con,scale);
        // 敌人 绘制
        EnemyController.DrawAll(ref con);
        // 食物绘制
        FoodController.Draw(ref con);
    }
    // 结束页
    static void Logout_Tick(ref Context con, float scale)
    {
        Login_Out_PanelController.LogoutTick(ref con, scale);
    }
    static void Logout_Draw(ref Context con, float scale)
    {
        Login_Out_PanelController.LogoutDraw(ref con, scale);

    }
}
