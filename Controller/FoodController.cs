using System.Numerics;
using Raylib_cs;
public static class FoodController
{
    enum Ally{none,bulFood,hpFood}
    public static void LogicTick(ref Context con, float dt,float scale)
    {
        ref PlaneEntity plane = ref con.plane;
        ref FoodEntity[] food = ref con.food;
        ref int foodCount = ref con.foodCount;

        // 生成加血食物 
        ref float hpFoodInterval = ref con.hpFoodInterval;
        ref float hpFoodtimer = ref con.hpFoodTimer;
        hpFoodtimer -= dt;
        if (hpFoodtimer <= 0)
        {
            hpFoodtimer = hpFoodInterval;
            Vector2 rectPos = RandomHelper.GetRandomPosOn_HalfBottom(scale);
            FoodEntity newHpFood = Factory.CreateFood(new Rectangle(rectPos.X, rectPos.Y, 20, 20),Color.RED, 2);
            food[foodCount] = newHpFood;
            foodCount++;
        }

        // 生成3子弹食物
        ref float bulFoodInterval= ref con.bulFoodInterval;
        ref float bulFoodTimer=ref con.bulFoodTimer;
        bulFoodTimer -=dt;
        if(bulFoodTimer<=0){
            bulFoodTimer=bulFoodInterval;
            Vector2 rectPos =RandomHelper.GetRandomPosOn_HalfBottom(scale);
            FoodEntity newBulFood =Factory.CreateFood(new Rectangle(rectPos.X,rectPos.Y,20,20),Color.BROWN,1);
            food[foodCount]=newBulFood;
            foodCount ++;
        }

        //如果我机吃了加血食物 则加20hp；如果hp>=100 则=100；
        for (int i = 0; i < foodCount; i++)
        {
            ref var fo = ref food[i];
            if (fo.ally ==(int)Ally.hpFood)
            {
                if (IntersectUtil.IsRectangleIntersect(fo.rect, plane))
                {
                    fo.isDead = true;
                    plane.hp += 20;
                    if (plane.hp >= 100)
                    {
                        plane.hp = 100;
                    }
                }
            }
            if(fo.ally==(int)Ally.bulFood){
              if(IntersectUtil.IsRectangleIntersect(fo.rect,plane)){
                fo.isDead=true;
                plane.bulletType=2;
              }   
            }

        }
        
        // 食物消除
        for(int i =foodCount-1;i>=0;i--){
            ref var fo =ref food[i];
            if(fo.isDead){
                RemoveUtil.RemoveFood(fo,i,foodCount,food);
                foodCount--;
            }
        }
    }
    public static void Draw(ref Context con)
    {
        ref FoodEntity[] food = ref con.food;
        ref int foodCount = ref con.foodCount;
        for (int i = 0; i < foodCount; i++)
        {
            var fo = food[i];
            fo.Draw();
        }
    }
}