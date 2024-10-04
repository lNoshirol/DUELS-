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
            if (_bomb.activeInHierarchy) _bomb.SetActive(false); else _bomb.SetActive(true);
            _rb.AddForce(Vector2.left * Mathf.Sign(other.transform.position.x - transform.position.x) * _inpulsionForce, ForceMode2D.Impulse);
        }
    }
}
