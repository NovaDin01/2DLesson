using UnityEngine;

public class SawController : MonoBehaviour
{
    public void ChangeDirection()
    {
       var render = gameObject.GetComponent<SpriteRenderer>();
       render.flipX = !render.flipX;
    }
}
