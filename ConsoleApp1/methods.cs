using Raylib_cs;
using System.Numerics;
class Menu{
    public void OptionBoxes(List<Vector2> options,List<string> optionsText, int textSize, Color c){ // draws black boxes with text inside      
        for (int i = 0; i < options.Count; i++)
        {
            Raylib.DrawRectangleV(options[i],new Vector2(textSize*5,textSize*2),c);
            Raylib.DrawRectangleLines((int)options[i].X,(int)options[i].Y,textSize*5,textSize*2,Color.Black);
            Raylib.DrawText(optionsText[i],(int)options[i].X+10, (int)options[i].Y+textSize/2,textSize,Color.White);
        }
    }
    public int Select(int action, int maxAction,int active,Vector2 position, int distance,int size)//apply´s a yellow overlay on the edge of a box and outputs a int
    {
        if (Raylib.IsKeyPressed(KeyboardKey.S)&&active==0)
        {
           action++; 
        }
        if (Raylib.IsKeyPressed(KeyboardKey.W)&&active==0)
        {
           action--; 
        }
        if(action>maxAction){action=1;}
        if(action<1){action=maxAction;}
        Raylib.DrawRectangleLines((int)position.X,distance*action+(int)position.Y,size*5/2,size,Color.Yellow);
        return action;
    }
}