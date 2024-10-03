using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagControl : MonoBehaviour
{
    private float _vitesse;
    private Rigidbody2D _rb;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Up;
    private bool _isGrounded;
    [SerializeField] private LayerMask _mask;



    void Start()
    {
        _vitesse = 10f;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1, _mask.value))
        {
            _isGrounded = true;
            print("is grounded");
        }
        else
        {
            _isGrounded = false;
        }

        MoveLeft();
        MoveRight();
        Jump();       
    }

    private void MoveRight()
    {
        if (Input.GetKey(Right))
        {
            //Debug.Log("right");
            transform.transform.transform.transform.Translate(Vector3.right * _vitesse * Time.deltaTime);
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKey(Left))
        {
            //Debug.Log("left");
            transform.transform.transform.transform.Translate(Vector3.left * _vitesse * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(Up) && _isGrounded)
        {
            Debug.Log("Saut");
            _rb.AddForce(transform.up * 500);
        }
    }
    
}
