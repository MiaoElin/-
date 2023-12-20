using System.Numerics;
using Raylib_cs;

public static class RandomHelper{
    public static Vector2 GetRandomPosOnTop(){
        Random r = new Random();
        float x= r.Next(0,800);
        Vector2 flyEnemyPos= new Vector2 (x,0);
        return flyEnemyPos;

    }
    public static Vector2 GetRandomPosOn_HalfTop(){
        Random r = new Random();
        float x=r.Next(0,800);
        float y= r.Next(0,600);
        Vector2 stayEnemyPos = new Vector2 (x,y);
        return stayEnemyPos;
        
    }
}