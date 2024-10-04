using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<GameObject> _bulletList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            GameObject newbullet = Instantiate(_bulletPrefab);
            newbullet.transform.parent = transform;
            newbullet.transform.position = Vector3.zero;
            newbullet.SetActive(false);
            _bulletList.Add(newbullet);
        }
    }

    public bool CheckBulletListNotEmpty()
    {
        if (_bulletList.Count > 0)
        {
            return true;
        }
        return false;
    }

    public GameObject GetFirstBulletFromList()
    {
        GameObject bullet = _bulletList[0];
        _bulletList.RemoveAt(0);
        return bullet;
    }

    public GameObject BulletInstantiate()
    {
        return Instantiate(_bulletPrefab);
    }

    public void ResetBullet(GameObject bullet)
    {
        bullet.GetComponent<Bullet>().ResetTag();
        bullet.SetActive(false);
        bullet.transform.position = Vector3.zero;
        if (!_bulletList.Contains(bullet)) 
        { 
            _bulletList.Add(bullet);
        }
    }
}