using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int bullets;

    void Start()
    {
        bullets = 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("BulletBundle"))
        {
            bullets += 5;
            Debug.Log("You have " + bullets + " bullets.");
            collision.gameObject.SetActive(false);
        }
    }
}
