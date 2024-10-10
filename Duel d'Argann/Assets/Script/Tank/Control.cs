using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    [SerializeField] bool isStickUse;
    [SerializeField] float speed;

    [SerializeField] private Bounds moovementLimits;
    private Vector3 moovement;
    [SerializeField] private float TurretRota;
    [SerializeField] private float TurretSpeed;

    [SerializeField] GameObject turretObject;

    [SerializeField] bool tank1;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            isStickUse = true;
        }
        if (callbackContext.canceled)
        {
            isStickUse = false;
        }
        Vector2 orientation = callbackContext.ReadValue<Vector2>();
        moovement = new Vector3(orientation.x, 0, 0);
    }

    public void OnRotateTurret(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            if (callbackContext.ReadValue<Vector2>().y > 0)
            {
                TurretRota = 1;
            }
            else
            {
                TurretRota = -1;
            }

            if (tank1)
            {
                TurretRota *= -1;
            }

        }
        if (callbackContext.canceled)
        {
            TurretRota = 0;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStickUse)
        {
            transform.position += (moovement * speed * Time.deltaTime);
            transform.position = moovementLimits.ClosestPoint(transform.position);
        }

        if (TurretRota != 0)
        {
            turretObject.transform.Rotate(new Vector3(0, 0, TurretRota) * TurretSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(moovementLimits.center, moovementLimits.size);
    }
}