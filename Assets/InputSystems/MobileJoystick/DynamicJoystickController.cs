using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls character with dynamic joystick that can be established from
/// https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#publisher
/// </summary>
public class DynamicJoystickController : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField,Range(0,10)] private float speed;
    [SerializeField,Range(0,10)] private float turnSpeed;
    #endregion

    #region Private Fields
    private DynamicJoystick mainJoystick;
    private float horizontal, vertical;
    private Vector3 nextPos;
    private Vector3 lookRot;
    #endregion
    
    #region MonoBehaveMethods
    void Start()
    {
        mainJoystick = FindObjectOfType<DynamicJoystick>();
    }
    
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
    }
    #endregion
    
    #region PrivateMethods
    
    void JoystickMovement()
    { 
        GetJoystickInputs();
        HandlePositionChange();
        HandleRotationChange();
        
    }
    void GetJoystickInputs()
    {
        horizontal = mainJoystick.Horizontal;
        vertical = mainJoystick.Vertical;
    }

    void HandlePositionChange()
    {
        nextPos.x = horizontal * speed;
        nextPos.z = vertical * speed;
        transform.position += nextPos * Time.deltaTime;
    }

    void HandleRotationChange()
    {
        lookRot.z = vertical;
        lookRot.x = horizontal;

        //For not getting gameanalytics debug 
        if (lookRot != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(lookRot),turnSpeed*Time.deltaTime);
    }
    
    #endregion
}
