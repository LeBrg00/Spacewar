using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;
Raylib.InitWindow(800, 600, "Waa");
Raylib.SetTargetFPS(60);
List<Projectile> onFieldProjectile;
List<Vector2> menupos=[new(300,200),new(300,250),];
int gamemode=0; //determines game state. If 0 its on original menu, if 1 the game is on
Menu startmenu=new(); 
Color whiteHalfTransparent = new(256, 256, 256, 128);
int select=1;
bool startSequence=true;
Spaceship Left;
Spaceship Right;
while (!Raylib.WindowShouldClose())
{
    Raylib.ClearBackground(Color.Black);
    if (gamemode == 0)
    {
        startmenu.OptionBoxes(menupos,["Start","Exit"],20,whiteHalfTransparent);
        select=Menu.Select(select,2,0,new Vector2(300,250),50,20);
    }
    if (gamemode == 1)
    {
        if (startSequence == true)
        {
            Left=new(KeyboardKey.LeftShift,KeyboardKey.W,KeyboardKey.A,KeyboardKey.D,new(100,500),new(50,10));
            Right=new(KeyboardKey.RightShift,KeyboardKey.Up,KeyboardKey.Left,KeyboardKey.Right,new(700,100),new(700,10));
            startSequence=false;
        }
        Left.check();
        Right.check();
    }
}