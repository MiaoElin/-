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
    public float fEBulTimer;
    public float fEBulInterval;
    // 子弹
    public BulletEntity[] Bullets;
    public int BulletCount;
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
    public LoginPanel loginPanel;
    public LogoutPanel logoutPanel;
    public GUIHP guiHP;


    public void Initialize()
    {
        input = new InputEntity();
        plane = Factory.CreatePlane(new Vector2(400, 1200), Color.BLUE, 20, 300, 100, 0);

        Enemies = new PlaneEntity[20000];
        EnemyCount = 0;
        Bullets = new BulletEntity[2000000];
        BulletCount = 0;
        fEnemySpawntimer = 1f;
        fEnemySpawnInterval = 4f;

        sEnemySpawntimer = 1f;
        sEnemySpawnInterval = 8f;

        fEBulInterval = 4f;
        fEBulTimer = 0.5f;

        sEBulTimer = 0.5f;
        sEBulInterval = 3f;

        food = new FoodEntity[2000];
        foodCount = 0;
        hpFoodTimer =10f;
        hpFoodInterval=10f;
        bulFoodTimer=8f;
        bulFoodInterval=8f;


        loginPanel.startBtn = new GUIButton(new(350, 500), new(100, 30), "START GAME", Color.BLACK, Color.WHITE);
        loginPanel.exitBtn = new GUIButton(new(350, 700), new(100, 30), "EXIT GAME", Color.BLACK, Color.WHITE);

        logoutPanel.reStaBtn = new GUIButton(new(350, 500), new(100, 30), "RESTART", Color.BLUE, Color.WHITE);
        logoutPanel.exitBtn = new GUIButton(new(350, 700), new(100, 30), "EXIT GAME", Color.BLUE, Color.WHITE);

        guiHP = new GUIHP(new(10, 10), new(200, 30), plane.hp, Color.RED, Color.GREEN);




    }
}