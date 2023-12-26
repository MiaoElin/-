using System.Numerics;
using Raylib_cs;

public struct Context
{
    public InputEntity input;
    public PlaneEntity plane;
    // 敌人
    public PlaneEntity[] Enemies;
    public int EnemyCount;

    // 子弹
    public BulletEntity[] Bullets;
    public int BulletCount;

    // 食物
    public FoodEntity[] food;
    public int foodCount;


    // 0：登入页 1：游戏中 2：结束页
    public byte gameStatus;
    public float width;
    public float heigth;
    public LoginPanel loginPanel;
    public LogoutPanel logoutPanel;
    public GUIHP guiHP;
    public RandomService randomService;
    public AssetsContext assetsContext;
    public SpawnEntity spawnTimer;
    public IDService iDService;


    public void Initialize(float scale)
    {
        input = new InputEntity();
        assetsContext =new AssetsContext(scale);
        // plane = Factory.CreatePlane(1,1,new Vector2(scale*360/6, scale*1000/6), Color.BLUE, scale*30/6, 300, 100, 0);
         bool hasPlane = Factory.CreatePlane(1,assetsContext,iDService,new Vector2(scale*360/6, scale*1000/6),out PlaneEntity p);
        if(hasPlane){
            plane=p;
        }
        Enemies = new PlaneEntity[20000];
        EnemyCount = 0;
        Bullets = new BulletEntity[2000000];
        BulletCount = 0;


        food = new FoodEntity[2000];
        foodCount = 0;
  

        width = 320;
        heigth = 180;//360 1080
        randomService =new RandomService();
        spawnTimer =new SpawnEntity ();
        

        loginPanel.startBtn = new GUIButton(new(scale * 310 / 6, scale * 440 / 6), new(scale * 100 / 6, scale * 30 / 6), "START GAME", Color.BLACK, Color.WHITE);
        loginPanel.exitBtn = new GUIButton(new(scale * 310 / 6, scale * 640 / 6), new(scale * 100 / 6, scale * 30 / 6), " EXIT GAME", Color.BLACK, Color.WHITE);

        logoutPanel.reStaBtn = new GUIButton(new(scale * 310 / 6, scale * 440 / 6), new(scale * 100 / 6, scale * 30 / 6), "  RESTART", Color.BLUE, Color.WHITE);
        logoutPanel.exitBtn = new GUIButton(new(scale * 310 / 6, scale * 640 / 6), new(scale * 100 / 6, scale * 30 / 6), " EXIT GAME", Color.BLUE, Color.WHITE);

        guiHP = new GUIHP(new(2 * scale, 2 * scale), new(scale * 200 / 6, scale * 30 / 6), plane.hp, Color.RED, Color.GREEN);




    }
}