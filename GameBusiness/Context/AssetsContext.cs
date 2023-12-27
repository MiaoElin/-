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
    public PlaneTM[] planeTMs;
    public FoodTM[] foodTMs;
    public BulleTM[] bulleTMs;

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
        // 飞机 模版
        planeTMs = new PlaneTM[3];
        PlaneTM p1 = new PlaneTM();
        p1.typeID = 1;
        p1.color = Color.BLUE;
        p1.radius = scale * 30 / 6;
        p1.moveSpeed = 300;
        p1.hp = 100;
        p1.bulType = 1;
        p1.texture2D=player;
        planeTMs[0] = p1;

        PlaneTM p2 = new PlaneTM();
        p2.typeID = 2;
        p2.color = Color.GRAY;
        p2.radius = scale * 20 / 6;
        p2.moveSpeed = 60;
        p2.hp = 20;
        p2.bulType = 3;
        p2.texture2D=fenemy;
        planeTMs[1] = p2;

        PlaneTM p3 = new PlaneTM();
        p3.typeID = 3;
        p3.color = Color.DARKGREEN;
        p3.radius = scale * 30 / 6;
        p3.moveSpeed = 0;
        p3.hp = 20;
        p3.bulType = 4;
        p3.texture2D=senemy;
        planeTMs[2] = p3;

        // 食物 模版
        foodTMs = new FoodTM[2];
        FoodTM f1 = new FoodTM();
        f1.color = Color.BROWN;
        f1.typeID = 1;
        foodTMs[0] = f1;

        FoodTM f2 = new FoodTM();
        f2.color = Color.RED;
        f2.typeID = 2;
        foodTMs[1] = f2;

        //子弹 模板
        bulleTMs = new BulleTM[3];
        
        //玩家2子弹 3子弹模式用的是这个
        BulleTM b1 = new BulleTM();
        b1.texture2D= bullet;
        b1.radius = scale * 5 / 6;
        b1.moveSpeed = 800;
        b1.typeID = 1;
        b1.ppu=2;
        bulleTMs[0] = b1;

        // 飞行敌人用的这个
        BulleTM b2 = new BulleTM();
        b2.radius = scale * 5 / 6;
        b2.moveSpeed = 300;
        b2.texture2D=fenemybul;
        b2.typeID = 2;
        b2.ppu=2;
        bulleTMs[1] = b2;

        // 固定的敌人 用的这个
        BulleTM b3 = new BulleTM();
        b3.radius = scale * 7/ 6;
        b3.moveSpeed = 200;
        b3.texture2D=senemybul;
        b3.typeID = 3;
        b3.ppu=2;
        bulleTMs[2] = b3;





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