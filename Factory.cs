using System.Numerics;
using Raylib_cs;

public static class Factory
{
    public static PlaneEntity CreatePlane(Vector2 pos, Color color, float radius, float moveSpeed, int hp, int id)
    {
        PlaneEntity plane;
        plane.color = color;
        plane.pos = pos;
        plane.radius = radius;
        plane.moveSpeed = moveSpeed;
        plane.hp = hp;
        plane.isDead = false;
        plane.id = id;
        plane.bulletType=2;
        return plane;
    }

    public static BulletEntity CreatePlayerBullet2(Vector2 planePos, int id, Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.radius = 5;
        bullet.moveSpeed = 800;
        bullet.pos1 = new Vector2(planePos.X - 1.5f * bullet.radius, planePos.Y);
        bullet.pos2 = new Vector2(planePos.X + 1.5f * bullet.radius, planePos.Y);
        bullet.pos3 = Vector2.Zero;
        bullet.color = Color.BLACK;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.ally = 1;
        return bullet;
    }
        public static BulletEntity CreatePlayerBullet3(Vector2 planePos, int id, Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.radius = 5;
        bullet.moveSpeed = 800;
        bullet.pos1 = new Vector2(planePos.X, planePos.Y);
        bullet.pos2 = new Vector2(planePos.X, planePos.Y);
        bullet.pos3 = new Vector2(planePos.X, planePos.Y);
        bullet.color = Color.BLACK;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.ally = 2;
        return bullet;
    }
    public static BulletEntity CreateFEnemyBullet(Vector2 enemyPos, int id, Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.radius = 5;
        bullet.color = Color.GRAY;
        bullet.moveSpeed = 300;
        bullet.pos1 = new Vector2(enemyPos.X - 1.5f * bullet.radius, enemyPos.Y);
        bullet.pos2 = new Vector2(enemyPos.X + 1.5f * bullet.radius, enemyPos.Y);
        bullet.pos3 = Vector2.Zero;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.ally = 3;
        return bullet;
    }
    public static BulletEntity CreateSEnemyBullet(Vector2 enemyPos, int id, Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.pos1 = new Vector2(enemyPos.X, enemyPos.Y);
        bullet.pos2 = Vector2.Zero;
        bullet.pos3 = Vector2.Zero;
        bullet.radius = 7;
        bullet.color = Color.GREEN;
        bullet.moveSpeed = 200;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir = firstDir;
        bullet.ally =4;
        return bullet;
    }
    public static FoodEntity CreateFood(Rectangle rect,Color color, sbyte ally){
        FoodEntity food;
        food.color =color;
        food.rect=  rect;
        food.isDead=false;
        food.ally=ally;
        return  food;
    }

}