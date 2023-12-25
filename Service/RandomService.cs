using System.Numerics;
using Raylib_cs;

public struct RandomService
{   
    public Random r;
    public RandomService(){
        r=new Random();
    }
    public  Vector2 GetRandomPosOnTop(float scale)
    {
        float x = r.Next(0, (int)scale*120);
        Vector2 flyEnemyPos = new Vector2(x, 0);
        return flyEnemyPos;

    }
    public  Vector2 GetRandomPosOn_HalfTop(float scale)
    {
        int x = r.Next(0,8);
        int y = r.Next(0,6);
        Vector2 pos =new Vector2(x*scale*80/6,y*scale*80/6);
        return pos;
    }
    public  Vector2 GetRandomPosOn_HalfBottom(float scale)
    {
        int x = r.Next(0,14);
        int y = r.Next(11,21);
        Vector2 pos =new Vector2(x*scale*50/6,y*scale*50/6);
        return pos;


    }
}