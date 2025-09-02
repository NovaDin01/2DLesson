using UnityEngine;
public class Pig : Enemy
{
    protected override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

    protected override void Die()
    {
        Debug.Log("Pig died!");
        base.Die();
    }
}