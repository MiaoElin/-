using System.Numerics;
using Raylib_cs;
public struct AssetsHelper
{
    public Texture2D player;
    public Texture2D map;
    public Texture2D bullet;
    public AssetsHelper()
    {
        player = Raylib.LoadTexture("Assets/plane.png");
        map = Raylib.LoadTexture("Assets/map.png");
        bullet = Raylib.LoadTexture("Assets/bullet.png");

    }
    public void UnloadTexture(){
        Raylib.UnloadTexture(player);
        Raylib.UnloadTexture(map);
        Raylib.UnloadTexture(bullet);

    }



}