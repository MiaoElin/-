using System.Numerics;
using Raylib_cs;

public static class RemoveUtil{
    public static void RemoveBul(BulletEntity bul, int index,int bulletCount,BulletEntity[]bullets){
        bullets[index]= bullets[bulletCount-1];
        bullets[bulletCount-1]=bul;
    }
        public static void RemoveEnemy(PlaneEntity enemy, int index,int enemyCount,PlaneEntity[]enemies){
        enemies[index]= enemies[enemyCount-1];
        enemies[enemyCount-1]=enemy;
    }
    
}