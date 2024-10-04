using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField] int _bulletForce;

    [SerializeField] GameObject _tankTurret;
    [SerializeField] GameObject _fireSpawnPoint;

    public void OnFire(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            Vector3 _fireDirection = _fireSpawnPoint.transform.position - _tankTurret.transform.position;

            GameObject newBullet = GETTHENEWBULLET();
            
            newBullet.transform.position = _fireSpawnPoint.transform.position;
            newBullet.SetActive(true);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            newBullet.GetComponent<Rigidbody2D>().AddForce(_fireDirection * _bulletForce);
        }
    }

    private GameObject GETTHENEWBULLET()
    {
        if (ObjectPool.instance.CheckBulletListNotEmpty())
        {
            GameObject newBullet = ObjectPool.instance.GetFirstBulletFromList();
            return newBullet;
        }
        else
        {
            GameObject newBullet = ObjectPool.instance.BulletInstantiate();
            return newBullet;
        }
    }
}