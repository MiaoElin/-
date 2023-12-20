using System.Numerics;
using Raylib_cs;

public struct Context
{
    public InputEntity input;
    public PlaneEntity plane;
    public BulletEntity[] PlayerBullets;
    public int playerBulsCount;
    // 飞行敌人
    public PlaneEntity[] flyEnemies;
    public int flyEnemyCount;
    public BulletEntity[] EnemyBullets;
    public int EnemyBulletCount;
    public float fEnemySqwanInterval;
    public float fEnemySqwantimer;
    public float fEBulTimer;
    public float fEBulInterval;
    // 固定敌人
    public PlaneEntity[] stayEnemies;
    public int stayEnemyCount;
    public float sEnemySqwanInterval;
    public float sEnemySqwantimer;
    public float sEBulTimer;
    public float sEBulInterval;

    // 0：登入页 1：游戏中 2：结束页
    public byte gameStatus;
    public LoginPanel loginPanel;
    public LogoutPanel logoutPanel;
    public GUIHP guiHP;


    public void Initialize()
    {
        input = new InputEntity();
        plane = Factory.CreatePlane(new Vector2(400, 1200), Color.BLUE, 20, 300,100, 0);
        PlayerBullets = new BulletEntity[20000];
        playerBulsCount = 0;

        flyEnemies = new PlaneEntity[20000];
        flyEnemyCount = 0;
        EnemyBullets = new BulletEntity[2000000];
        EnemyBulletCount = 0;
        fEnemySqwantimer = 1f;
        fEnemySqwanInterval = 4f;

        stayEnemies = new PlaneEntity[20000];
        stayEnemyCount = 0;
        sEnemySqwantimer = 1f;
        sEnemySqwanInterval = 8f;
        fEBulInterval = 3f;
        fEBulTimer = 0.5f;
        sEBulTimer=0.5f;
        sEBulInterval=3f;


        loginPanel.startBtn = new GUIButton(new(350, 500), new(100, 30), "START GAME", Color.BLACK, Color.WHITE);
        loginPanel.exitBtn = new GUIButton(new(350, 700), new(100, 30), "EXIT GAME", Color.BLACK, Color.WHITE);

        logoutPanel.reStaBtn = new GUIButton(new(350, 500), new(100, 30), "RESTART", Color.BLUE, Color.WHITE);
        logoutPanel.exitBtn = new GUIButton(new(350, 700), new(100, 30), "EXIT GAME", Color.BLUE, Color.WHITE);

        guiHP = new GUIHP(new(10, 10), new(200, 30), plane.hp, Color.RED, Color.GREEN);




    }
}