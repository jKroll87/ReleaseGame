using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public Image hpImage;
    public Text hpText;
    public int bullets;
    public int maxBullets;
    public Image bulletFillImage;
    public Text bulletText;

    void Start()
    {
        hpImage = GameObject.Find("Hp").GetComponent<Image>();
        hpText = GameObject.Find("HpText").GetComponent<Text>();

        bulletFillImage = GameObject.Find("BulletFillImage").GetComponent<Image>();
        bulletText = GameObject.Find("BulletText").GetComponent<Text>();
    }
    private void OnEnable()
    {
        ResetCharacter();
    }

    void FixedUpdate()
    {
        setHealthBar();
        setBulletBar();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("BulletBundle"))
        {
            bullets += 5;
            collision.gameObject.SetActive(false);
        }
    }

    void setHealthBar()
    {
        hpImage.fillAmount = (float)hitPoints / maxHitPoints;
        hpText.text = "HP:" + (hpImage.fillAmount * maxHitPoints);
    }

    void setBulletBar()
    {
        bulletFillImage.fillAmount = (float)bullets / maxBullets;
        bulletText.text = bullets + "/" + maxBullets;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            hitPoints = hitPoints - damage;

            if (hitPoints <= 0)
            {
                setHealthBar();
                KillCharacter();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
}
