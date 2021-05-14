using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public int bullets;
    public Image hpImage;
    public Text hpText;

    void Start()
    {
        bullets = 0;
        hpImage = GameObject.Find("Hp").GetComponent<Image>();
        hpText = GameObject.Find("HpText").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        setHealthBar();
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

    void setHealthBar()
    {
        hpImage.fillAmount = (float)hitPoints / maxHitPoints;
        hpText.text = "HP:" + (hpImage.fillAmount * maxHitPoints);
    }
}
