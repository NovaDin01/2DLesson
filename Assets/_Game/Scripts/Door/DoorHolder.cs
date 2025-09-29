using System;
using UnityEngine;

public class DoorHolder : MonoBehaviour
{
   [SerializeField] private GameObject hint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
