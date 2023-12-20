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
        return plane;
    }

    public static BulletEntity CreatePlayerBullet1(Vector2 planePos, float radius, Color color, float moveSpeed, int id,Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.pos1 = new Vector2(planePos.X - 1.5f * radius, planePos.Y);
        bullet.pos2 = new Vector2(planePos.X + 1.5f * radius, planePos.Y);
        bullet.pos3 = Vector2.Zero;
        bullet.radius = radius;
        bullet.color = color;
        bullet.moveSpeed = moveSpeed;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir=firstDir;
        return bullet;
    }
    public static BulletEntity CreateFEnemyBullet(Vector2 enemyPos, float radius, Color color, float moveSpeed, int id,Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.pos1 = new Vector2(enemyPos.X - 1.5f * radius, enemyPos.Y);
        bullet.pos2 = new Vector2(enemyPos.X + 1.5f * radius, enemyPos.Y);
        bullet.pos3 = Vector2.Zero;
        bullet.radius = radius;
        bullet.color = color;
        bullet.moveSpeed = moveSpeed;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir=firstDir;
        return bullet;
    }
    public static BulletEntity CreateSEnemyBullet(Vector2 enemyPos, float radius, Color color, float moveSpeed, int id,Vector2 firstDir)
    {
        BulletEntity bullet;
        bullet.pos1 = new Vector2(enemyPos.X, enemyPos.Y);
        bullet.pos2 = Vector2.Zero;
        bullet.pos3 = Vector2.Zero;
        bullet.radius = radius;
        bullet.color = color;
        bullet.moveSpeed = moveSpeed;
        bullet.isDead = false;
        bullet.id = id;
        bullet.firstDir=firstDir;
        return bullet;
    }

}