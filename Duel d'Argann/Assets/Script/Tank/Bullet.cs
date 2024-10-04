using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] string LauncherTag;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitBeforeGoBackToList());
    }

    IEnumerator WaitBeforeGoBackToList()
    {
        yield return new WaitForSeconds(4);
        ObjectPool.instance.ResetBullet(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        if (gameObject.tag != null)
        {

            if (collision.gameObject.tag != gameObject.tag && collision.gameObject.tag != "Ground")
            {
                if (collision.GetComponent<TankHealth>())
                {
                    collision.gameObject.GetComponent<TankHealth>().TakeDamage(1);
                }
                ObjectPool.instance.ResetBullet(gameObject);
            }
            else if (collision.gameObject.tag == "Ground")
            {
                ObjectPool.instance.ResetBullet(gameObject);
            }
        }
    }

    public void ResetTag()
    {
        LauncherTag = null;
    }
}