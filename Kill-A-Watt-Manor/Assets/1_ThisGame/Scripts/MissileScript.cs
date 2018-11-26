using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private void Start()
    {
        rb.velocity = transform.right * speed;        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Player player = hitInfo.GetComponent<Player>();
        if (player == null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);


            Destroy(gameObject);
        }
       

    }



}  