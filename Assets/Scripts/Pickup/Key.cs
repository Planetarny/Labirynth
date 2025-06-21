using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Blue,
    Gold
}
public enum KeyType
{
    Skull,
    Snowflake,
    Old,
    Cogwheel
}

public class Key : Pickup
{
    public KeyColor color;
    public KeyType type;

    public override void Picked()
    {
        GameManager.gameManager.AddKey(color, type);
        base.Picked();
    }
}
