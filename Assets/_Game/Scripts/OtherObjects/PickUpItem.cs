using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.OtherObjects
{
    public class PickUpItem : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PickUpLogic();
            }
        }

        protected virtual void PickUpLogic()
        {
            
            Destroy(gameObject);
        }
    }
}