using UnityEngine;

public class AddCrystal : Pickup
{
    public int coins = 5;
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(coins);
        base.Picked();
    }
}
