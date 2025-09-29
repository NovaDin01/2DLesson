using System;
using System.Collections;
using UnityEngine;

public class DoorHolder : MonoBehaviour
{
   [SerializeField] private GameObject hint;
   [SerializeField] private Animator playerAnimator;
   [SerializeField] private Animator doorAnimator;
   
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(true);
            playerAnimator.SetBool("door", true);
            doorAnimator.SetBool("isOpen", true);
            StartCoroutine("WaitComeInDoor");
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

    private IEnumerator WaitComeInDoor()
    {
        yield return new WaitForSeconds(0.7f);
        playerAnimator.SetBool("door", false);
        doorAnimator.SetBool("isOpen", false);
        Time.timeScale = 0;
    }
}
