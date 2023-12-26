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
        ref RandomService r= ref con.randomService;
        ref AssetsContext assetsContext=ref con.assetsContext;
        ref IDService iDService=ref con.iDService;

        // 生成加血食物 
        ref float hpFoodInterval = ref con.spawnTimer.hpFoodInterval;
        ref float hpFoodtimer = ref con.spawnTimer.hpFoodTimer;
        hpFoodtimer -= dt;
        if (hpFoodtimer <= 0)
        {
            hpFoodtimer = hpFoodInterval;
            Vector2 rectPos = r.GetRandomPosOn_HalfBottom(scale);
            bool hasHpFood = Factory.CreateFood(2,new Rectangle(rectPos.X, rectPos.Y, 20, 20),assetsContext,iDService,out FoodEntity newHpFood);
            if(hasHpFood){
            food[foodCount] = newHpFood;
            foodCount++;
            }else{
                System.Console.WriteLine("没有2类型的食物模板");
            }
        }

        // 生成3子弹食物
        ref float bulFoodInterval= ref con.spawnTimer.bulFoodInterval;
        ref float bulFoodTimer=ref con.spawnTimer.bulFoodTimer;
        bulFoodTimer -=dt;
        if(bulFoodTimer<=0){
            bulFoodTimer=bulFoodInterval;
            Vector2 rectPos =r.GetRandomPosOn_HalfBottom(scale);
            bool hasBulFood =Factory.CreateFood(1,new Rectangle(rectPos.X,rectPos.Y,20,20),assetsContext,iDService,out FoodEntity newBulFood);
            if(hasBulFood){
            food[foodCount]=newBulFood;
            foodCount ++;
            }else{
                System.Console.WriteLine("没有1类型的食物模板");
            }

        }

        //如果我机吃了加血食物 则加20hp；如果hp>=100 则=100；
        for (int i = 0; i < foodCount; i++)
        {
            ref var fo = ref food[i];
            if (fo.typeID ==(int)Ally.hpFood)
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
            if(fo.typeID==(int)Ally.bulFood){
              if(IntersectUtil.IsRectangleIntersect(fo.rect,plane)){
                fo.isDead=true;
                plane.bulType=2;
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
    public static void Draw(ref Context con,float scale)
    {
        ref FoodEntity[] food = ref con.food;
        ref int foodCount = ref con.foodCount;
        ref AssetsContext asset=ref con.assetsContext;
        for (int i = 0; i < foodCount; i++)
        {
            var fo = food[i];
            if (fo.typeID == (int)Ally.bulFood)
            {
                fo.bulFoodDraw(asset, scale);
            }
            if (fo.typeID == (int)Ally.hpFood)
            {
                fo.hpFoodDraw(asset, scale);
            }
        }
    }
}