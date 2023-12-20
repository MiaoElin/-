using System.Numerics;
using Raylib_cs;

public static class FindUtil
{
    // public static PlaneEntity FindNearlyEnemy(PlaneEntity enemy1,PlaneEntity enemy2,float distance1,float distance2,int index1,int index2,out int nearIndex, bool isSameDistance){
    //     PlaneEntity nearlyEnemy =default;
    //     isSameDistance =false;
    //     nearIndex =-1;
    //     if(distance1>distance2){
    //         nearlyEnemy =enemy2;
    //         nearIndex= index2;
    //         isSameDistance =false;
    //     }if(distance1<distance2){
    //         nearlyEnemy=enemy1;
    //         nearIndex= index1;
    //         isSameDistance =false;
    //     }if(distance1==distance2){
    //     // default 则enemy1和enemy2都要扣血
    //     isSameDistance = true;
    //      nearIndex =-1;
    //     }
    //     return nearlyEnemy;
    // }
    public static PlaneEntity FindEnemy(BulletEntity bullets, PlaneEntity[] Enemies, int EnemyCount,out float nearDistance, out int nearEnemyIndex)
    {

        PlaneEntity nearEnemy = default;
        nearDistance = float.MaxValue;
        nearEnemyIndex = -1;
        for (int j = 0; j < EnemyCount; j++)
        {
            var fly = Enemies[j];
            float flyBulDisance1 = Vector2.Distance(bullets.pos1, Enemies[j].pos);
            float flyBulDisance2 = Vector2.Distance(bullets.pos2, Enemies[j].pos);
            float flyBulDisance = 0;
            if(Enemies[j].isDead){
                continue;
            }
            if (flyBulDisance1 < flyBulDisance2)
            {
                flyBulDisance = flyBulDisance1;
            }
            else{
                flyBulDisance = flyBulDisance2;
            }

            if (flyBulDisance < nearDistance)
            {
                nearDistance = flyBulDisance;
                nearEnemy = Enemies[j];
                nearEnemyIndex = j;
            }else
            {
            }
        }
        return nearEnemy;
    }
}