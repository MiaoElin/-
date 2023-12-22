using System.Numerics;
using Raylib_cs;

public struct Context
{
    public InputEntity input;
    public PlaneEntity plane;
    // 敌人
    public PlaneEntity[] Enemies;
    public int EnemyCount;
    public float fEnemySpawnInterval;
    public float fEnemySpawntimer;
    public float sEnemySpawnInterval;
    public float sEnemySpawntimer;
    // 子弹
    public BulletEntity[] Bullets;
    public int BulletCount;
    public float planeBultimer;
    public float planeBulInterval;
    public float fEBulTimer;
    public float fEBulInterval;
    public float sEBulTimer;
    public float sEBulInterval;
    // 食物
    public FoodEntity[] food;
    public int foodCount;
    public float hpFoodTimer;
    public float hpFoodInterval;
    public float bulFoodTimer;
    public float bulFoodInterval;

    // 0：登入页 1：游戏中 2：结束页
    public byte gameStatus;
    public float width;
    public float heigth;
    public LoginPanel loginPanel;
    public LogoutPanel logoutPanel;
    public GUIHP guiHP;
    public AssetsHelper asset;


    public void Initialize(float scale)
    {
        input = new InputEntity();
        asset =new AssetsHelper();
        plane = Factory.CreatePlane(new Vector2(scale*360/6, scale*1000/6), Color.BLUE, scale*30/6, 300, 100, 0);

        Enemies = new PlaneEntity[20000];
        EnemyCount = 0;
        Bullets = new BulletEntity[2000000];
        BulletCount = 0;
        fEnemySpawntimer = 1f;
        fEnemySpawnInterval = 4f;

        sEnemySpawntimer = 1f;
        sEnemySpawnInterval = 8f;

        planeBultimer=0;
        planeBulInterval=0.2f;

        fEBulInterval = 4f;
        fEBulTimer = 0.5f;

        sEBulTimer = 0.5f;
        sEBulInterval = 3f;

        food = new FoodEntity[2000];
        foodCount = 0;
        hpFoodTimer = 10f;       
        hpFoodInterval = 10f;
        bulFoodTimer = 10f;
        bulFoodInterval = 12f;

        width = 320;
        heigth = 180;//360 1080

        loginPanel.startBtn = new GUIButton(new(scale * 310 / 6, scale * 440 / 6), new(scale * 100 / 6, scale * 30 / 6), "START GAME", Color.BLACK, Color.WHITE);
        loginPanel.exitBtn = new GUIButton(new(scale * 310 / 6, scale * 640 / 6), new(scale * 100 / 6, scale * 30 / 6), " EXIT GAME", Color.BLACK, Color.WHITE);

        logoutPanel.reStaBtn = new GUIButton(new(scale * 310 / 6, scale * 440 / 6), new(scale * 100 / 6, scale * 30 / 6), "  RESTART", Color.BLUE, Color.WHITE);
        logoutPanel.exitBtn = new GUIButton(new(scale * 310 / 6, scale * 640 / 6), new(scale * 100 / 6, scale * 30 / 6), " EXIT GAME", Color.BLUE, Color.WHITE);

        guiHP = new GUIHP(new(2 * scale, 2 * scale), new(scale * 200 / 6, scale * 30 / 6), plane.hp, Color.RED, Color.GREEN);




    }
}