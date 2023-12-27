using System.Numerics;
using Raylib_cs;

public static class BulletDomain {
    public static void Spawn(ref Context con, float dt, float scale) {

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
        ref AssetsContext assetsContext = ref con.assetsContext;
        ref IDService iDService = ref con.iDService;
        planeBultimer -= dt;
        if (planeBultimer <= 0) {
            if (input.isSpacePressed) {
                planeBultimer = planeBulInterval;
                if (plane.bulType == (int)BulType.playerTwoBul) {
                    bool hasBullet1 = Factory.CreateBullet(1, 1, plane.pos, new Vector2(0, -1), assetsContext, iDService, out BulletEntity newBul1);
                    if (hasBullet1) {
                        newBul1.pos.X -= 3* newBul1.radius;
                        Bullets[BulletCount] = newBul1;
                        BulletCount++;
                    }
                    bool hasBullet2 = Factory.CreateBullet(1, 1, plane.pos, new Vector2(0, -1), assetsContext, iDService, out BulletEntity newBul2);
                    if (hasBullet2) {
                        newBul1.pos.X += 3f * newBul1.radius;
                        Bullets[BulletCount] = newBul2;
                        BulletCount++;
                    }
                }
                if (plane.bulType == (int)BulType.playerThreeBulles) {
                    Vector2 dir1 = new Vector2(MathF.Sin(MathF.PI / -45), -1 * MathF.Cos(MathF.PI / -45)); //Vector2(-1, -1)
                    Vector2 dir3 = new Vector2(MathF.Sin(MathF.PI / 45), -1 * MathF.Cos(MathF.PI / 45));
                    bool hasBullet1 = Factory.CreateBullet(1, 1, plane.pos, dir1, assetsContext, iDService, out BulletEntity newBul1);
                    if (hasBullet1) {
                        Bullets[BulletCount] = newBul1;
                        BulletCount++;
                    }
                    bool hasBullet2 = Factory.CreateBullet(1, 1, plane.pos, new Vector2(0, -1), assetsContext, iDService, out BulletEntity newBul2);
                    if (hasBullet2) {
                        Bullets[BulletCount] = newBul2;
                        BulletCount++;
                    }
                    bool hasBullet3 = Factory.CreateBullet(1, 1, plane.pos, dir3, assetsContext, iDService, out BulletEntity newBul3);
                    if (hasBullet3) {
                        Bullets[BulletCount] = newBul3;
                        BulletCount++;
                    }
                }
                input.isSpacePressed = false;

            }
        }
        // 每个飞行敌人每2s秒生成一颗子弹
        ref float fEBultimer = ref con.spawnTimer.fEBulTimer;
        ref float fEBulInterval = ref con.spawnTimer.fEBulInterval;
        fEBultimer -= dt;
        if (fEBultimer <= 0) {
            for (int i = 0; i < EnemyCount; i++) {
                fEBultimer = fEBulInterval;
                var enemy = Enemies[i];
                if(enemy.typeID==(int)PlaneType.fenemy){
                bool hasBullet1 = Factory.CreateBullet(2, 2, enemy.pos, new(0, 1), assetsContext, iDService, out BulletEntity newBullet1);
                if (hasBullet1) {
                    newBullet1.pos.X -= 3f * newBullet1.radius;
                    Bullets[BulletCount] = newBullet1;
                    BulletCount++;
                }
                bool hasBullet2 = Factory.CreateBullet(2, 2, enemy.pos, new(0, 1), assetsContext, iDService, out BulletEntity newBullet2);
                if (hasBullet2) {
                    newBullet1.pos.X += 3f * newBullet1.radius;
                    Bullets[BulletCount] = newBullet2;
                    BulletCount++;
                }
                }

            }
        }
        // 每个固定敌人 每3s 生成一个子弹
        ref float sEBulTimer = ref con.spawnTimer.sEBulTimer;
        ref float sEBulInterval = ref con.spawnTimer.sEBulInterval;
        sEBulTimer -= dt;
        if (sEBulTimer <= 0) {
            for (int i = 0; i < EnemyCount; i++) {
                sEBulTimer = sEBulInterval;
                var enemy = Enemies[i];
                if(enemy.typeID==(int)PlaneType.senemy){
            Vector2 firstDir = plane.pos - enemy.pos;
                bool hasBullet = Factory.CreateBullet(3, 2, enemy.pos, firstDir, assetsContext, iDService, out BulletEntity newBullet);
                if (hasBullet) {
                    Bullets[BulletCount] = newBullet;
                    BulletCount++;
                }
                }
            }
        }
    }
    public static void Move(ref Context con, float dt) {
        ref BulletEntity[] Bullets = ref con.Bullets;
        ref int BulletCount = ref con.BulletCount;
        ref InputEntity input = ref con.input;
        ref PlaneEntity plane = ref con.plane;

        ref PlaneEntity[] Enemies = ref con.Enemies;
        ref int EnemyCount = ref con.EnemyCount;
        // 子弹 移动
        for (int i = 0; i < BulletCount; i++) {
            ref var bul = ref Bullets[i];
            Vector2 dir = bul.firstDir;
            bul.Move(dir, dt);
            if (bul.ally == (int)Ally.player) {
                bool hasnearlyEnemy = FindUtil.FindEnemy(bul, Enemies, EnemyCount, out int nearEnemyIndex, out PlaneEntity nearlyEnemy);
                if (hasnearlyEnemy) {
                    if ((IntersectUtil.IsCircleIntersect(nearlyEnemy, bul))) {
                        bul.isDead = true;
                        Enemies[nearEnemyIndex].hp -= 10;
                        if (Enemies[nearEnemyIndex].hp <= 0) {
                            Enemies[nearEnemyIndex].isDead = true;
                        }
                    }
                }
            }
            if (bul.ally == (int)Ally.enemy) {
                if (IntersectUtil.IsCircleIntersect(plane, bul)) {
                    bul.isDead = true;
                    plane.hp -= 10;
                    plane.bulType = 1;
                    if (plane.hp <= 0) {
                        plane.isDead = true;
                    }
                }
            }
        }



        // if (bul.typeID == (int)bulType.playerTwoBul)
        // {
        //     Vector2 dir =
        //     bul.Move(dir, dt);
        //     // 找子弹的最近敌人
        //     // 碰撞检测1.碰到子弹isDead =true；敌人hp-10；如果敌人hp<=0 则敌人isDead=true；
        //     //        2.没碰到不做任何动作；
        //     PlaneEntity nearlyEnemy = FindUtil.FindEnemy(bul, Enemies, EnemyCount, out float distance, out int index);
        //     // 最近存在敌人
        //     if (index != -1)
        //     {
        //         // 碰撞检测
        //         if (IntersectUtil.IsCircleIntersect(nearlyEnemy, bul))
        //         {
        //             bul.isDead = true;
        //             Enemies[index].hp -= 10;
        //             if (Enemies[index].hp <= 0)
        //             {
        //                 Enemies[index].isDead = true;
        //             }
        //         }
        //     }
        // }
        // if (bul.typeID == (int)bulType.playerThreeBulles)
        // {

        //     bul.PlayerBulMove3(dir, dt);
        //     // 找子弹的最近敌人
        //     // 碰撞检测1.碰到子弹isDead =true；敌人hp-10；如果敌人hp<=0 则敌人isDead=true；
        //     //        2.没碰到不做任何动作；
        //     PlaneEntity nearlyEnemy = FindUtil.FindEnemy(bul, Enemies, EnemyCount, out float distance, out int index);
        //     // 最近存在敌人
        //     if (index != -1)
        //     {
        //         // 碰撞检测
        //         if (IntersectUtil.IsCircleIntersect(nearlyEnemy, bul))
        //         {
        //             bul.isDead = true;
        //             Enemies[index].hp -= 10;
        //             if (Enemies[index].hp <= 0)
        //             {
        //                 Enemies[index].isDead = true;
        //             }
        //         }
        //     }
        // }
        // if (bul.typeID == (int)bulType.fEnemyBul)
        // {
        //     // 飞行敌人 子弹移动
        //     // 从上垂直向下
        //     bul.FEnemyBulMove(bul.firstDir, dt);
        //     // 飞行子弹检测
        //     if (IntersectUtil.IsCircleIntersect(plane, bul))
        //     {
        //         bul.isDead = true;
        //         plane.hp -= 10;
        //         plane.bulType = 1;
        //         if (plane.hp <= 0)
        //         {
        //             plane.isDead = true;
        //         }
        //     }
        // }

        // // 固定敌人 子弹移动
        // if (bul.typeID == (int)bulType.sEnemyBul)
        // {
        //     bul.SEnemyBulMove(bul.firstDir, dt);
        //     if (IntersectUtil.IsCircleIntersect(plane, bul))
        //     {
        //         bul.isDead = true;
        //         plane.hp -= 10;
        //         plane.bulType = 1;
        //         if (plane.hp <= 0)
        //         {
        //             plane.isDead = true;
        //         }
        //     }
        // }

    }
    public static void Remove(ref Context con) {
        ref BulletEntity[] Bullets = ref con.Bullets;
        ref int BulletCount = ref con.BulletCount;

        // 遍历敌人子弹 消除isDead的
        for (int i = BulletCount - 1; i >= 0; i--) {
            ref var bul = ref Bullets[i];
            if (Bullets[i].isDead) {
                RemoveUtil.RemoveBul(bul, i, BulletCount, Bullets);
                BulletCount -= 1;
            }
        }

        // 遍历所有的 我机子弹 消除isDead的子弹
        for (int i = BulletCount - 1; i >= 0; i--) {
            ref var bul = ref Bullets[i];
            if (Bullets[i].isDead) {
                RemoveUtil.RemoveBul(bul, i, BulletCount, Bullets);
                BulletCount -= 1;
            }
        }
    }
}
