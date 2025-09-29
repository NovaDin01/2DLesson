using UnityEngine;
public class Pig : Enemy
{
    protected override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
    }

    protected override void Die()
    {
        base.Die();
    }
}