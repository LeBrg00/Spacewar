using System.Numerics;
class Object
{
    protected new Vector2 position;
    protected new Vector2 velocity;
    protected void Move()
    {
        position=position+velocity;
    }
}