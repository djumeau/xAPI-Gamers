using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int pigPower = 1;
    public Transform enemyReflectionPoint;
    public LineRenderer linePigRenderer;
    public GameObject deathEffect;
    public ParticleSystem particle;

    public RPGTalk rpgtalk;
  

    public void TakeDamage(int damage)
    {
        health -= damage;

        particle.Stop();

        if (health <= 0)
        {
            Die();
            if(rpgtalk != null)
            {
                rpgtalk.NewTalk();
            }
            
        }
               
    }



    public IEnumerator Ricochet()
    {
        linePigRenderer.SetPosition(0, enemyReflectionPoint.position);
        linePigRenderer.SetPosition(1, enemyReflectionPoint.position + enemyReflectionPoint.right * 100);
        linePigRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        linePigRenderer.enabled = false;
              
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GBL_Interface.SendKilled();
        
    }
}