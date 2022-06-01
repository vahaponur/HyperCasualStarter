using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwerveInputSystem))]
public class Swerver : MonoBehaviour
{
   [SerializeField] private Transform objectToSwerve;
   [SerializeField] float maxMovement,sensitivity;


   private SwerveInputSystem swerveInputSystem;

   private void Start()
   {
      swerveInputSystem = GetComponent<SwerveInputSystem>();
      swerveInputSystem.Swerve += HandleSwerve;
   }

   private void Update()
   {
     HandleSwerve();
   }

   void HandleSwerve()
   {
      var moveFactor = swerveInputSystem.MoveFactorX * sensitivity * Time.deltaTime;
      float newX = (objectToSwerve.localPosition.x + moveFactor );
      newX = Mathf.Clamp(newX, -maxMovement, maxMovement);

      
      if (moveFactor != 0)
      {
         objectToSwerve.localPosition = new Vector3(newX,
            objectToSwerve.localPosition.y, objectToSwerve.localPosition.z);
      }
   
   }
}
