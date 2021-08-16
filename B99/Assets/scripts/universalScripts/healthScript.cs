using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    public float health = 100f;
    private characterAnimation animationScript;
    private enemyMovement enemymovement;
    private bool characterDied;
    public bool is_Player;
    private healthUI health_UI;
    void Awake()
    {
        animationScript = GetComponentInChildren<characterAnimation>(); 
        if(is_Player)
        health_UI=GetComponent<healthUI>();

    }
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;
        health_UI.DisplayHealth(health);
        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;
            if (is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<enemyMovement>().enabled=false;
            }
            return;
        }
        if (!is_Player)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }
}
 