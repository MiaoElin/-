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
    public PlaneTM[] planeTM;

    public AssetsContext(float scale)
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
        planeTM = new PlaneTM[3];
        PlaneTM p1 = new PlaneTM();
        p1.typeID = 1;
        p1.color = Color.BLUE;
        p1.radius = scale * 30 / 6;
        planeTM[0] = p1;
        // 
        PlaneTM p2 = new PlaneTM();
        p2.typeID = 2;
        p2.color = Color.GRAY;
        p2.radius = scale * 20 / 6;
        planeTM[1] = p2;

        PlaneTM p3 = new PlaneTM();
        p3.typeID = 3;
        p3.color = Color.DARKGREEN;
        p3.radius = scale * 30 / 6;
        planeTM[2] = p3;

    }
    public void UnloadTexture()
    {
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