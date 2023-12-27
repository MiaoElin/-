using System.Numerics;
using Raylib_cs;

public static class Factory
{
    public static bool CreatePlane(int typeID, AssetsContext assetsContext, IDService iDService, Vector2 pos, out PlaneEntity plane)
    {
        for (int i = 0; i < assetsContext.planeTMs.Length; i++)
        {
            var tm = assetsContext.planeTMs[i];
            if (tm.typeID == typeID)
            {
                PlaneEntity p = new PlaneEntity();
                p.typeID = tm.typeID;
                p.color = tm.color;
                p.radius = tm.radius;
                p.texture2D =tm.texture2D;
                p.id = iDService.planeIDService++;
                p.pos = pos;
                p.moveSpeed = tm.moveSpeed;
                p.bulType = tm.bulType;
                p.hp = tm.hp;
                p.isDead = false;
                plane = p;
                return true;
            }
        }
        System.Console.WriteLine("plane找不到typeID为" + typeID);
        plane = default;
        return false;
    }
    public static bool CreateBullet(int typeID,sbyte ally, Vector2 pos,Vector2 firstDir, AssetsContext assetsContext, IDService iDService, out BulletEntity bullet)
    {
        for(int i = 0; i<assetsContext.bulleTMs.Length;i++){
            var tm =assetsContext.bulleTMs[i];
            if(tm.typeID==typeID){
                BulletEntity b= new BulletEntity ();
                b.moveSpeed=tm.moveSpeed;
                b.texture2D=tm.texture2D;
                b.radius=tm.radius;
                b.ppu=tm.ppu;
                b.typeID=typeID;
                b.pos=pos;
                b.firstDir=firstDir;
                b.ally=ally;
                b.isDead=false;
                b.id=iDService.bulletIDService++;
                bullet=b;
                return true;
            }
        }
        System.Console.WriteLine("子弹找不到typeID为"+typeID);
        bullet =default;
        return false;
    }
    public static bool CreateFood(int typeID, Rectangle rect, AssetsContext assetsContext, IDService iDService, out FoodEntity food)
    {
        for (int i = 0; i < assetsContext.foodTMs.Length; i++)
        {
            var tm = assetsContext.foodTMs[i];
            if (tm.typeID == typeID)
            {
                FoodEntity f;
                f.color = tm.color;
                f.typeID = tm.typeID;
                f.rect = rect;
                f.isDead = false;
                f.id = iDService.foodIDService++;
                food = f;
                return true;
            }

        }
        System.Console.WriteLine("food找不到typeID为:" + typeID);
        food = default;
        return false;

    }
    // public static bool CreateBullet(AssetsContext assetsContext,IDService iDService, int typeID,)

    // public static PlaneEntity CreatePlane(int typeID, int bulType, Vector2 pos, Color color, float radius, float moveSpeed, int hp, int id)
    // {
    //     PlaneEntity plane;
    //     plane.color = color;
    //     plane.pos = pos;
    //     plane.radius = radius;
    //     plane.moveSpeed = moveSpeed;
    //     plane.hp = hp;
    //     plane.isDead = false;
    //     plane.id = id;
    //     plane.bulType = bulType;
    //     plane.typeID=typeID;
    //     return plane;
    // }

    // public static BulletEntity CreatePlayerBullet2(Vector2 planePos, int id, Vector2 firstDir, float scale)
    // {
    //     BulletEntity bullet;
    //     bullet.radius = scale * 5 / 6;
    //     bullet.moveSpeed = 800;
    //     bullet.pos1 = new Vector2(planePos.X + -1.5f * bullet.radius, planePos.Y);
    //     bullet.pos2 = new Vector2(planePos.X + 1.5f * bullet.radius, planePos.Y);
    //     bullet.pos3 = Vector2.Zero;
    //     bullet.color = Color.BLACK;
    //     bullet.isDead = false;
    //     bullet.id = id;
    //     bullet.firstDir = firstDir;
    //     bullet.typeID = 1;
    //     return bullet;
    // }
    // public static BulletEntity CreatePlayerBullet3(Vector2 planePos, int id, Vector2 firstDir, float scale)
    // {
    //     BulletEntity bullet;
    //     bullet.radius = scale * 5 / 6;
    //     bullet.moveSpeed = 800;
    //     bullet.pos1 = new Vector2(planePos.X, planePos.Y);
    //     bullet.pos2 = new Vector2(planePos.X, planePos.Y);
    //     bullet.pos3 = new Vector2(planePos.X, planePos.Y);
    //     bullet.color = Color.BLACK;
    //     bullet.isDead = false;
    //     bullet.id = id;
    //     bullet.firstDir = firstDir;
    //     bullet.typeID = 2;
    //     return bullet;
    // }
    // public static BulletEntity CreateFEnemyBullet(Vector2 enemyPos, int id, Vector2 firstDir, float scale)
    // {
    //     BulletEntity bullet;
    //     bullet.radius = scale * 5 / 6;
    //     bullet.color = Color.GRAY;
    //     bullet.moveSpeed = 300;
    //     bullet.pos1 = new Vector2(enemyPos.X - 1.5f * bullet.radius, enemyPos.Y);
    //     bullet.pos2 = new Vector2(enemyPos.X + 1.5f * bullet.radius, enemyPos.Y);
    //     bullet.pos3 = Vector2.Zero;
    //     bullet.isDead = false;
    //     bullet.id = id;
    //     bullet.firstDir = firstDir;
    //     bullet.typeID = 3;
    //     return bullet;
    // }
    // public static BulletEntity CreateSEnemyBullet(Vector2 enemyPos, int id, Vector2 firstDir, float scale)
    // {
    //     BulletEntity bullet;
    //     bullet.pos1 = new Vector2(enemyPos.X, enemyPos.Y);
    //     bullet.pos2 = default;
    //     bullet.pos3 = default;
    //     bullet.radius = scale * 7 / 6;
    //     bullet.color = Color.GREEN;
    //     bullet.moveSpeed = 200;
    //     bullet.isDead = false;
    //     bullet.id = id;
    //     bullet.firstDir = firstDir;
    //     bullet.typeID = 4;
    //     return bullet;
    // }

}