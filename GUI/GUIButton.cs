using System.Numerics;
using Raylib_cs;

public struct GUIButton
{
    public Rectangle rect;
    public string text;
    public Color bgC;
    public Color fontC;
    public bool isMouseHover;

    // 构造函数 可在new的时候传入参数  普通函数new完，再调用函数
    public GUIButton(Vector2 pos, Vector2 size, string text, Color bgC, Color fontC)
    {
        this.rect = new Rectangle(pos.X, pos.Y, size.X, size.Y);
        this.text = text;
        this.bgC = bgC;
        this.fontC = fontC;
        this.isMouseHover = false;
    }
    public bool IsBtnDown(Vector2 mousePos, bool isMousePressed)
    {
        if (IntersectUtil.IsMouseIntersect(mousePos, rect))
        {
            isMouseHover = true;
            if (isMousePressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            isMouseHover = false;
            return false;
        }
    }
    public void Draw()
    {
        if (isMouseHover)
        {
            Raylib.DrawRectangleRec(rect, Color.GREEN);
            Raylib.DrawText(text, (int)rect.X + 18, (int)rect.Y + 8, 8, fontC);
        }
        else
        {
            Raylib.DrawRectangleRec(rect, bgC);
            Raylib.DrawText(text, (int)rect.X + 20, (int)rect.Y + 8, 8, fontC);
        }
    }

}