using UnityEngine;

public class TagControl : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _rb;
    [SerializeField] private KeyCode _right;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _up;
    private bool _isGrounded;
    [SerializeField] private LayerMask _mask;



    void Start()
    {
        _speed = 10f;
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
        if (Input.GetKey(_right))
        {
            //Debug.Log("right");
            transform.transform.transform.transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKey(_left))
        {
            //Debug.Log("left");
            transform.transform.transform.transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_up) && _isGrounded)
        {
            //Debug.Log("Saut");
            _rb.AddForce(transform.up * 500);
        }
    }
    
}
