using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int hitPoints;
    public int maxHitPoints;

    public void KillCharacter()
    {
        Destroy(gameObject);
    }

    public void ResetCharacter()
    {
        hitPoints = maxHitPoints;
    }

    public virtual IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            hitPoints = hitPoints - damage;

            if (hitPoints <= 0)
            {
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
