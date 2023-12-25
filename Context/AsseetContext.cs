using System.Numerics;
using Raylib_cs;
public struct AssetsContext
{
    public Texture2D player;
    public Texture2D map;
    public Texture2D bullet;
    public Texture2D hpFood;
    public Texture2D bulFood;
    public Texture2D fenemybul;
    public Texture2D senemybul;
    public Texture2D fenemy;
    public Texture2D senemy;
    public AssetsContext()
    {
        player = Raylib.LoadTexture("Assets/plane.png");
        map = Raylib.LoadTexture("Assets/map.png");
        bullet = Raylib.LoadTexture("Assets/bullet.png");
        hpFood = Raylib.LoadTexture("Assets/hpFood.png");
        bulFood = Raylib.LoadTexture("Assets/bulFood.png");
        fenemybul = Raylib.LoadTexture("Assets/fenemybul.png");
        senemybul = Raylib.LoadTexture("Assets/senemybul.png");
        fenemy = Raylib.LoadTexture("Assets/fenemy.png");
        senemy = Raylib.LoadTexture("Assets/senemy.png");
        
    }
    public void UnloadTexture(){
        Raylib.UnloadTexture(player);
        Raylib.UnloadTexture(map);
        Raylib.UnloadTexture(bullet);
        Raylib.UnloadTexture(hpFood);
        Raylib.UnloadTexture(bulFood);
        Raylib.UnloadTexture(fenemybul);
        Raylib.UnloadTexture(senemybul);
        Raylib.UnloadTexture(fenemy);
        Raylib.UnloadTexture(senemy);

    }



}