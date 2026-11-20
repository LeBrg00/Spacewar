using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
class Spaceship
{
    private new Vector2 position;
    private new Vector2 velocity;
    private new Vector2 barp;
    private int ammo;
    private int fuel;
    private float direction;
    private KeyboardKey shoot;
    private KeyboardKey thrust;
    private KeyboardKey rotateleft;
    private KeyboardKey rotateright;
    public Spaceship(KeyboardKey fire, KeyboardKey go, KeyboardKey rotleft, KeyboardKey rotright, Vector2 start, Vector2 barpos)
    {
        shoot=fire;
        thrust=go;
        rotateleft=rotleft;
        rotateright=rotright;
        position=start;
        fuel=200;
        ammo=20;
        barp=barpos;
    }
    public void check()
    {
        Move();
        draw();
        accelarate();
        fire();
        Show(barp);
        rotate();
    }
    private void draw()
    {
        
        //Raylib.DrawTexturePro();
    }
    private void Move()
    {
        position=position+velocity;
    }
    private void accelarate()//Reminder använd sinus,cos,tangent för att konvertertera rotation till vector2
    {
        if (Raylib.IsKeyDown(thrust))
        {
            fuel--;
            float sin=(float)Math.Sin(direction);
            float cos=(float)Math.Cos(direction);
            Vector2 velocityAdd = new (sin,cos);
            velocity=velocity+velocityAdd;
        }
    }
    private void fire()
    {
        if (Raylib.IsKeyPressed(shoot))
        {
            ammo--;
        }
    }
    private void rotate()
    {
        if (Raylib.IsKeyDown(rotateleft))
        {
            direction--;
        }
        if (Raylib.IsKeyDown(rotateright))
        {
            direction++;
        }
        if (direction <= 0)
        {
            direction=360;
        }
        if (direction >= 360)
        {
            direction=0;
        }
    }
    private void Show(Vector2 barposition)
    {
        Bar(fuel,200,"Fuel",15, barposition,Color.White, Color.Orange);
        Bar(ammo,20,"Ammo",15, new Vector2(barposition.X,barposition.Y+20),Color.White, Color.LightGray);
    }
    private void Bar(int measurement,int maxMeasurement,string measurementName,int textsize, Vector2 position,Color boxColor, Color barColor) 
    {   //Draws a bar with a name and the value to the left. The bar has a set length multiplied by the measurement divided by the maxeasurement
        Raylib.DrawRectangleV(position,new Vector2(measurementName.Length*textsize/4*3,textsize+4),boxColor);
        Raylib.DrawText(measurementName,(int)position.X+4,(int)position.Y+2,textsize,Color.White);
        string measurementLengt= measurement.ToString();
        Raylib.DrawRectangleV(new Vector2((int)position.X+measurementName.Length*textsize/4*3,(int)position.Y),new Vector2(measurementLengt.Length*textsize/4*3,textsize+4),boxColor);
        Raylib.DrawText(measurementLengt,4+(int)position.X+measurementName.Length*textsize/4*3,(int)position.Y+2,textsize,Color.White);
        Raylib.DrawRectangleV(new Vector2((int)position.X+measurementName.Length*textsize/4*3+measurementLengt.Length*textsize/4*3,(int)position.Y),new Vector2(textsize*5,textsize+4),boxColor);
        float a=measurement;
        float b=maxMeasurement;
        float percentage=a/b;
        Raylib.DrawRectangleV(new Vector2((int)position.X+measurementName.Length*textsize/4*3+measurementLengt.Length*textsize/4*3,(int)position.Y+2),new Vector2(percentage*textsize*5,textsize-2),barColor);//The bar itself
        Raylib.DrawRectangleLines((int)position.X,(int)position.Y,measurementName.Length*textsize/4*3+measurementLengt.Length*textsize/4*3+textsize*5,textsize+4,Color.Black);
    }
}