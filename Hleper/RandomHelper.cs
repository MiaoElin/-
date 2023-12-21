using System.Numerics;
using Raylib_cs;

public static class RandomHelper
{
    public static Vector2 GetRandomPosOnTop()
    {
        Random r = new Random();
        float x = r.Next(0, 800);
        Vector2 flyEnemyPos = new Vector2(x, 0);
        return flyEnemyPos;

    }
    public static Vector2 GetRandomPosOn_HalfTop()
    {
        Random r = new Random();
        int x = r.Next(0,10);
        int y = r.Next(0,7);
        Vector2 pos =new Vector2(80*x,+80*y);
        return pos;
    }
    public static Vector2 GetRandomPosOn_HalfBottom()
    {
        Random r = new Random();
        int x = r.Next(0,15);
        int y = r.Next(12,23);
        Vector2 pos =new Vector2(50*x,+50*y);
        return pos;


    }
}