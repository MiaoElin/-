using System.Numerics;
using Raylib_cs;

public struct GUIHP
{
    public Rectangle rectBg;
    public Rectangle rectHp;
    public Color bgC;
    public Color hpC;
    public int hpHave;
    public string text;

    public GUIHP(Vector2 posBg, Vector2 bgSize, int planeHp, Color bgC, Color hpC)
    {

        this.bgC = bgC;
        this.hpC = hpC;
        this.hpHave = planeHp;        
        this.rectBg = new Rectangle(posBg.X, posBg.Y, bgSize.X, bgSize.Y);
        this.rectHp = new Rectangle(posBg.X, posBg.Y, planeHp*2, bgSize.Y);
        this.text = "100/100";
    }
    public void Draw(string txt, int planeHpInScreen)
    {   
        Raylib.DrawRectangleRec(rectBg, bgC);
        Raylib.DrawRectangle((int)rectHp.X,(int)rectHp.Y, planeHpInScreen,(int)rectHp.Height, hpC);
        Raylib.DrawText(txt,(int)rectBg.X+80,(int)rectBg.Y+8,15,Color.BLACK);
    }

}