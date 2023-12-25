using System.Numerics;
using Raylib_cs;

public static class Factory
{
    // public static PlaneEntity CreatePlane(AssetsContext assetsContext, IDService iDService, int typeID, Vector2 pos, float moveSpeed, int hp, int bulType)
    // {
    //     for (int i = 0; i < assetsContext.planeTM.Length - 1; i++)
    //     {
    //         var tm = assetsContext.planeTM[i];
    //         if (tm.typeID == typeID)
    //         {
    //             PlaneEntity p = new PlaneEntity();
    //             p.typeID = tm.typeID;
    //             p.color = tm.color;
    //             p.radius = tm.radius;
    //             p.id = iDService.planeIDService++;
    //             p.pos = pos;
    //             p.moveSpeed = moveSpeed;
    //             p.isDead = false;
    //             p.hp = hp;
    //             p.bulType = bulType;
    //             return p;
    //         }
    //     }
    //     return default;
    // }
    public static PlaneEntity CreatePlane(int typeID, int bulType, Vector2 pos, Color color, float radius, float moveSpeed, int hp, int id)
    {
        PlaneEntity plane;
        plane.color = color;
        plane.pos = pos;
        plane.radius = radius;
        plane.moveSpeed = moveSpeed;
        plane.hp = hp;
        plane.isDead = false;
        plane.id = id;
        plane.bulType = bulType;
        plane.typeID=typeID;
        return plane;
    }

    public static BulletEntity CreatePlayerBullet2(Vector2 planePos, int id, Vector2 firstDir, float scale)
    {
        BulletEntity bullet;
        bullet.radius = scale * 5 / 6;
        bullet.moveSpeed = 800;
        bullet.pos1 = new Vector2(planePos.X + -1.5f * bullet.radius, planePos.Y);
        bullet.pos2 = new Vector2(planePos.X + 1.5f * bullet.radius, planePos.Y);
        bullet.pos3 = Vector2.Zero;
        bullet.color = Color.BLACK;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.typeID = 1;
        return bullet;
    }
    public static BulletEntity CreatePlayerBullet3(Vector2 planePos, int id, Vector2 firstDir, float scale)
    {
        BulletEntity bullet;
        bullet.radius = scale * 5 / 6;
        bullet.moveSpeed = 800;
        bullet.pos1 = new Vector2(planePos.X, planePos.Y);
        bullet.pos2 = new Vector2(planePos.X, planePos.Y);
        bullet.pos3 = new Vector2(planePos.X, planePos.Y);
        bullet.color = Color.BLACK;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.typeID = 2;
        return bullet;
    }
    public static BulletEntity CreateFEnemyBullet(Vector2 enemyPos, int id, Vector2 firstDir, float scale)
    {
        BulletEntity bullet;
        bullet.radius = scale * 5 / 6;
        bullet.color = Color.GRAY;
        bullet.moveSpeed = 300;
        bullet.pos1 = new Vector2(enemyPos.X - 1.5f * bullet.radius, enemyPos.Y);
        bullet.pos2 = new Vector2(enemyPos.X + 1.5f * bullet.radius, enemyPos.Y);
        bullet.pos3 = Vector2.Zero;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.typeID = 3;
        return bullet;
    }
    public static BulletEntity CreateSEnemyBullet(Vector2 enemyPos, int id, Vector2 firstDir, float scale)
    {
        BulletEntity bullet;
        bullet.pos1 = new Vector2(enemyPos.X, enemyPos.Y);
        bullet.pos2 = default;
        bullet.pos3 = default;
        bullet.radius = scale * 7 / 6;
        bullet.color = Color.GREEN;
        bullet.moveSpeed = 200;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.typeID = 4;
        return bullet;
    }
    public static FoodEntity CreateFood(Rectangle rect, Color color, sbyte ally)
    {
        FoodEntity food;
        food.color = color;
        food.rect = rect;
        food.isDead = false;
        food.ally = ally;
        return food;
    }
}