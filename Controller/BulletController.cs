using System.Numerics;
using Raylib_cs;

public static class BulletController
{
    public static void LogicTick(ref Context con, float dt)
    {
        ref BulletEntity[] PlayerBullets = ref con.PlayerBullets;
        ref int PlayerBulsCount = ref con.playerBulsCount;
        ref InputEntity input = ref con.input;
        ref PlaneEntity plane = ref con.plane;

        ref PlaneEntity[] flyEnemies = ref con.flyEnemies;
        ref PlaneEntity[] stayEnemies = ref con.stayEnemies;
        ref int flyEnemyCount = ref con.flyEnemyCount;
        ref int stayEnemyCount = ref con.stayEnemyCount;

        // 我机子弹 生成
        if (input.isSpacePressed)
        {
            BulletEntity newBullet = Factory.CreatePlayerBullet1(plane.pos, 5, Color.BLACK, 800, PlayerBulsCount,new(0,-1));
            PlayerBullets[PlayerBulsCount] = newBullet;
            PlayerBulsCount++;
            input.isSpacePressed = false;
        }
        // 我机子弹 移动
        for (int i = 0; i < PlayerBulsCount; i++)
        {
            ref var bul = ref PlayerBullets[i];
            bul.PlayerBulMove1(dt);

            // 找子弹的最近敌人
            // 碰撞检测1.碰到子弹isDead =true；敌人hp-10；如果敌人hp<=0 则敌人isDead=true；
            //        2.没碰到不做任何动作；
            PlaneEntity enemy1 = FindUtil.FindEnemy(bul, flyEnemies, flyEnemyCount, out float distance1, out int idnex1);
            PlaneEntity enemy2 = FindUtil.FindEnemy(bul, stayEnemies, stayEnemyCount, out float distance2, out int index2);
            // // 飞行敌人 和 固定敌人都存在
            if (idnex1 != -1 && index2 != -1)
            {
                if (distance1 < distance2)
                {
                    // 1近 检测飞行敌人
                    if (IntersectUtil.IsCircleIntersect(enemy1, PlayerBullets[i]))
                    {
                        PlayerBullets[i].isDead = true;
                        flyEnemies[idnex1].hp -= 10;
                        if (flyEnemies[idnex1].hp <= 0)
                        {
                            flyEnemies[idnex1].isDead = true;
                        }
                    }
                }
                if (distance1 == distance2)
                {
                    // 一样近 都要检测
                    if (IntersectUtil.IsCircleIntersect(enemy1, PlayerBullets[i]))
                    {
                        PlayerBullets[i].isDead = true;
                        flyEnemies[idnex1].hp -= 10;
                        if (flyEnemies[idnex1].hp <= 0)
                        {
                            flyEnemies[idnex1].isDead = true;
                        }
                    }
                    if (IntersectUtil.IsCircleIntersect(enemy2, PlayerBullets[i]))
                    {
                        PlayerBullets[i].isDead = true;
                        stayEnemies[index2].hp -= 10;
                        if (stayEnemies[index2].hp <= 0)
                        {
                            stayEnemies[index2].isDead = true;
                        }
                    }
                }
                if (distance1 > distance2)
                {  // 2近 只检测固定敌人
                    if (IntersectUtil.IsCircleIntersect(enemy2, PlayerBullets[i]))
                    {
                        PlayerBullets[i].isDead = true;
                        stayEnemies[index2].hp -= 10;
                        if (stayEnemies[index2].hp <= 0)
                        {
                            stayEnemies[index2].isDead = true;
                        }
                    }
                }
            }
            else if (idnex1 != -1)
            {
                // 只有1 只检测飞行敌人
                if (IntersectUtil.IsCircleIntersect(enemy1, PlayerBullets[i]))
                {
                    PlayerBullets[i].isDead = true;
                    flyEnemies[idnex1].hp -= 10;
                    if (flyEnemies[idnex1].hp <= 0)
                    {
                        flyEnemies[idnex1].isDead = true;
                    }
                }
            }
            else if (index2 != -1)
            {
                // 只有2 只检测固定敌人
                if (IntersectUtil.IsCircleIntersect(enemy2, PlayerBullets[i]))
                {
                    PlayerBullets[i].isDead = true;
                    stayEnemies[index2].hp -= 10;
                    if (stayEnemies[index2].hp <= 0)
                    {
                        stayEnemies[index2].isDead = true;
                    }
                }
            }
            else
            {// index1 和 index2 都为-1，没有找到任何敌人
            }

        }
        // 每个飞行敌人每2s秒生成一颗子弹
        ref float fEBultimer = ref con.fEBulTimer;
        ref float fEBulInterval = ref con.fEBulInterval;
        ref BulletEntity[] EnemyBullets = ref con.EnemyBullets;
        ref int EnemyBulletCount = ref con.EnemyBulletCount;
        fEBultimer -= dt;
        if (fEBultimer <= 0)
        {
            for (int i = 0; i < flyEnemyCount; i++)
            {
                fEBultimer = fEBulInterval;
                var enemy = flyEnemies[i];
                BulletEntity newBullet = Factory.CreateFEnemyBullet(enemy.pos, 5, Color.GRAY, 300, i,new(0,1));
                EnemyBullets[EnemyBulletCount] = newBullet;
                EnemyBulletCount++;
                Console.WriteLine(EnemyBulletCount);
            }
        }
        // 每个固定敌人 每3s 生成一个子弹
        ref float sEBulTimer = ref con.sEBulTimer;
        ref float sEBulInterval = ref con.sEBulInterval;
        sEBulTimer -= dt;
        if (sEBulTimer <= 0)
        {
            for (int i = 0; i < stayEnemyCount; i++)
            {
                sEBulTimer = sEBulInterval;
                var enemy = stayEnemies[i];
                Vector2 firstDir =plane.pos- enemy.pos;
                BulletEntity newBullet = Factory.CreateSEnemyBullet(enemy.pos, 7, Color.GREEN, 200, i,firstDir);
                EnemyBullets[EnemyBulletCount] = newBullet;
                EnemyBulletCount++;
            }
        }
        // 飞行敌人 子弹移动
        for (int i = 0; i < EnemyBulletCount; i++)
        {
            // 从上垂直向下
            ref var bul = ref EnemyBullets[i];
            if (bul.radius == 5)
            {
                bul.FEnemyBulMove(bul.firstDir, dt);
                // 飞行子弹检测
                if (IntersectUtil.IsCircleIntersect(plane, bul))
                {
                    bul.isDead = true;
                    plane.hp -= 10;
                    if (plane.hp <= 0)
                    {
                        Console.WriteLine(plane.hp);
                        plane.isDead = true;
                    }
                }
            }
            // 固定敌人 子弹移动
            if (bul.radius == 7)
            {
                bul.SEnemyBulMove(bul.firstDir, dt);
                if (IntersectUtil.IsCircleIntersect(plane, bul))
                {
                    bul.isDead = true;
                    plane.hp -= 10;
                    if (plane.hp <= 0)
                    {
                        Console.WriteLine(plane.hp);
                        plane.isDead = true;
                    }
                }
            }
        }


        // 遍历敌人子弹 消除isDead的
        for (int i = EnemyBulletCount - 1; i >= 0; i--)
        {
            ref var bul = ref EnemyBullets[i];
            if (EnemyBullets[i].isDead)
            {
                RemoveUtil.RemoveBul(bul, i, EnemyBulletCount, EnemyBullets);
                EnemyBulletCount -= 1;
            }
        }

        // 遍历所有的 我机子弹 消除isDead的子弹
        for (int i = PlayerBulsCount - 1; i >= 0; i--)
        {
            ref var bul = ref PlayerBullets[i];
            if (PlayerBullets[i].isDead)
            {
                RemoveUtil.RemoveBul(bul, i, PlayerBulsCount, PlayerBullets);
                PlayerBulsCount -= 1;
            }
        }

    }

    public static void DrawAll(ref Context con)
    {
        ref int bulletCount = ref con.playerBulsCount;
        ref int EnemyBulletCount = ref con.EnemyBulletCount;
        ref BulletEntity[] PlayerBullets = ref con.PlayerBullets;
        ref BulletEntity[] EnemyBullets = ref con.EnemyBullets;
        // 我机子弹 绘制
        for (int i = 0; i < bulletCount; i++)
        {
            var bul = PlayerBullets[i];
            PlayerBullets[i].PlayerBulDraw1();

        }
        // 敌人子弹 绘制
        for (int i = 0; i < EnemyBulletCount; i++)
        {
            var bul = EnemyBullets[i];
            if (bul.radius == 5)
            {
                EnemyBullets[i].FEnemyBulDraw();
            }
            if (bul.radius == 7)
            {
                EnemyBullets[i].SEnemyBulDraw();
            }
        }


    }
}