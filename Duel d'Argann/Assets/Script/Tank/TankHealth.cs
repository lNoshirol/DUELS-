using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] bool isDead;

    [SerializeField] GameObject theOtherPLayer;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            health = 0;
            Destroy(gameObject.GetComponent<Control>());
            Destroy(gameObject.GetComponent<Fire>());
            GetComponent<PLayerSounds>().PlayDeadSound();
            LimageDeMort.Instance.transform.position = new Vector3(transform.position.x, LimageDeMort.Instance.transform.position.y, 0);
            LimageDeMort.Instance.gameObject.SetActive(true);
            healthText.text = health.ToString();
            GetComponent<PLayerSounds>().StopSound();
            StartCoroutine(StartWin());
        }
        else if (!isDead)
        {
            GetComponent<PLayerSounds>().PlayHitSound();
            healthText.text = health.ToString();
        }
    }

    IEnumerator StartWin()
    {
        yield return new WaitForSeconds(GetComponent<PLayerSounds>().deadSound.length);
        LimageDeMort.Instance.gameObject.SetActive(false);
        Win.Instance.AndThisIsTheWin(theOtherPLayer);
    }
}