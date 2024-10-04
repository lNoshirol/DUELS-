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
    [SerializeField] private float jspAVecLeSida;
    [SerializeField] private float  turretOrientationValue;

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
        if (callbackContext.started && turretOrientationValue >= 0)
        {
            if (callbackContext.ReadValue<Vector2>().y > 0)
            {
                jspAVecLeSida = 1;
            }
            else
            {
                jspAVecLeSida = -1;
            }

            if (tank1)
            {
                jspAVecLeSida *= -1;
            }

        }
        if (callbackContext.canceled)
        {
            jspAVecLeSida = 0;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStickUse)
        {
            transform.position += (moovement * speed * Time.deltaTime);
            transform.position = moovementLimits.ClosestPoint(transform.position);
        }

        if (jspAVecLeSida != 0 && 900 >= turretOrientationValue && turretOrientationValue >= 0)
        {
            turretOrientationValue += jspAVecLeSida * Time.deltaTime;
            turretObject.transform.Rotate(new Vector3(0, 0, jspAVecLeSida));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(moovementLimits.center, moovementLimits.size);
    }
}