using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{

    [SerializeField] private string _tag;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _inpulsionForce;
    [SerializeField] private Vector2 _inpulsionOrientation;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == _tag)
        {
            Debug.Log("Touché !");
<<<<<<< Updated upstream
            if (_bomb.activeInHierarchy) _bomb.SetActive(false); else _bomb.SetActive(true);//suce
=======
            if (_bomb.activeInHierarchy) _bomb.SetActive(false); else _bomb.SetActive(true);
            _rb.AddForce(-other.relativeVelocity * _inpulsionForce, ForceMode2D.Impulse);

>>>>>>> Stashed changes
        }
    }
}
