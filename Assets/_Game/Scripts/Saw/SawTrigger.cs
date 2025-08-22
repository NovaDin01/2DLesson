using System;
using UnityEngine;

public class SawTrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.TryGetComponent<SawController>(out var saw))
      {
         Debug.Log("123");
         var slider = saw.GetComponent<SliderJoint2D>();
         if (slider != null)
         {
            JointMotor2D motor = slider.motor;
            motor.motorSpeed *= -1;
            slider.motor = motor;
            
            saw.ChangeDirection();
         }
      }
   }
}
