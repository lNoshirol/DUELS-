using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimageDeMort : MonoBehaviour
{
    public static LimageDeMort Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}