using System.Numerics;
using Raylib_cs;

public static class BulletDomain
{
    enum Ally { none, playerTwoBul, playerThreeBulles,fEnemyBul,sEnemyBul}
    public static void Spawn(ref Context con, float dt, float scale)
    {

        ref BulletEntity[] Bullets = ref con.Bullets;
        ref int BulletCount = ref con.BulletCount;
        ref InputEntity input = ref con.input;
        ref PlaneEntity plane = ref con.plane;

        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;

        // =====生成======
        // 我机子弹 生成
        ref float planeBultimer = ref con.spawnTimer.planeBultimer;
        ref float planeBulInterval = ref con.spawnTimer.planeBulInterval;
        planeBultimer -= dt;
        if (planeBultimer <= 0)
        {
            if (input.isSpacePressed)
            {
                planeBultimer = planeBulInterval;
                if (plane.bulType == (int)Ally.playerTwoBul)
                {
                    BulletEntity newBullet = Factory.CreatePlayerBullet2(plane.pos, BulletCount, new(0, -1), scale);
                    Bullets[BulletCount] = newBullet;
                }
                if (plane.bulType ==(int)Ally.playerThreeBulles)
                {
                    BulletEntity newBullet = Factory.CreatePlayerBullet3(plane.pos, BulletCount, new(0, -1), scale);
                    Bullets[BulletCount] = newBullet;
                }
                BulletCount++;
                input.isSpacePressed = false;

            }
        }
        // 每个飞行敌人每2s秒生成一颗子弹
        ref float fEBultimer = ref con.spawnTimer.fEBulTimer;
        ref float fEBulInterval = ref con.spawnTimer.fEBulInterval;
        fEBultimer -= dt;
        if (fEBultimer <= 0)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                fEBultimer = fEBulInterval;
                var enemy = Enemies[i];
                BulletEntity newBullet = Factory.CreateFEnemyBullet(enemy.pos, i, new(0, 1), scale);
                Bullets[BulletCount] = newBullet;
                BulletCount++;
            }
        }
        // 每个固定敌人 每3s 生成一个子弹
        ref float sEBulTimer = ref con.spawnTimer.sEBulTimer;
        ref float sEBulInterval = ref con.spawnTimer.sEBulInterval;
        sEBulTimer -= dt;
        if (sEBulTimer <= 0)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                sEBulTimer = sEBulInterval;
                var enemy = Enemies[i];
                Vector2 firstDir = plane.pos - enemy.pos;
                BulletEntity newBullet = Factory.CreateSEnemyBullet(enemy.pos, i, firstDir, scale);
                Bullets[BulletCount] = newBullet;
                BulletCount++;
            }
        }
    }
    public static void Move(ref Context con, float dt)
    {
        ref BulletEntity[] Bullets = ref con.Bullets;
        ref int BulletCount = ref con.BulletCount;
        ref InputEntity input = ref con.input;
        ref PlaneEntity plane = ref con.plane;

        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;
        // 我机子弹 移动
        for (int i = 0; i < BulletCount; i++)
        {
            ref var bul = ref Bullets[i];
            if (bul.typeID ==(int)Ally.playerTwoBul)
            {

                bul.PlayerBulMove2(dt);
                // 找子弹的最近敌人
                // 碰撞检测1.碰到子弹isDead =true；敌人hp-10；如果敌人hp<=0 则敌人isDead=true；
                //        2.没碰到不做任何动作；
                PlaneEntity nearlyEnemy = FindUtil.FindEnemy(bul, Enemies, EnemyCount, out float distance, out int index);
                // 最近存在敌人
                if (index != -1)
                {
                    // 碰撞检测
                    if (IntersectUtil.IsCircleIntersect(nearlyEnemy, bul))
                    {
                        bul.isDead = true;
                        Enemies[index].hp -= 10;
                        if (Enemies[index].hp == 0)
                        {
                            Enemies[index].isDead = true;
                        }
                    }
                }
            }
            if (bul.typeID ==(int)Ally.playerThreeBulles)
            {
                bul.PlayerBulMove3(dt);
                // 找子弹的最近敌人
                // 碰撞检测1.碰到子弹isDead =true；敌人hp-10；如果敌人hp<=0 则敌人isDead=true；
                //        2.没碰到不做任何动作；
                PlaneEntity nearlyEnemy = FindUtil.FindEnemy(bul, Enemies, EnemyCount, out float distance, out int index);
                // 最近存在敌人
                if (index != -1)
                {
                    // 碰撞检测
                    if (IntersectUtil.IsCircleIntersect(nearlyEnemy, bul))
                    {
                        bul.isDead = true;
                        Enemies[index].hp -= 10;
                        if (Enemies[index].hp == 0)
                        {
                            Enemies[index].isDead = true;
                        }
                    }
                }
            }
            if (bul.typeID == (int)Ally.fEnemyBul)
            {
                // 飞行敌人 子弹移动
                // 从上垂直向下
                bul.FEnemyBulMove(bul.firstDir, dt);
                // 飞行子弹检测
                if (IntersectUtil.IsCircleIntersect(plane, bul))
                {
                    bul.isDead = true;
                    plane.hp -= 10;
                    plane.bulType = 1;
                    if (plane.hp <= 0)
                    {
                        plane.isDead = true;
                    }
                }
            }

            // 固定敌人 子弹移动
            if (bul.typeID ==(int)Ally.sEnemyBul)
            {
                bul.SEnemyBulMove(bul.firstDir, dt);
                if (IntersectUtil.IsCircleIntersect(plane, bul))
                {
                    bul.isDead = true;
                    plane.hp -= 10;
                    plane.bulType = 1;
                    if (plane.hp <= 0)
                    {
                        plane.isDead = true;
                    }
                }
            }
        }
    }
    public static void Remove(ref Context con)
    {
        ref BulletEntity[] Bullets = ref con.Bullets;
        ref int BulletCount = ref con.BulletCount;

        // 遍历敌人子弹 消除isDead的
        for (int i = BulletCount - 1; i >= 0; i--)
        {
            ref var bul = ref Bullets[i];
            if (Bullets[i].isDead)
            {
                RemoveUtil.RemoveBul(bul, i, BulletCount, Bullets);
                BulletCount -= 1;
            }
        }

        // 遍历所有的 我机子弹 消除isDead的子弹
        for (int i = BulletCount - 1; i >= 0; i--)
        {
            ref var bul = ref Bullets[i];
            if (Bullets[i].isDead)
            {
                RemoveUtil.RemoveBul(bul, i, BulletCount, Bullets);
                BulletCount -= 1;
            }
        }
    }
}
