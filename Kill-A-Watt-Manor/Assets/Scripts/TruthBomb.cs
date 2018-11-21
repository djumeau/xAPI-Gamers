using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruthBomb : MonoBehaviour {

    public float speed = 2f;
    public Rigidbody2D rb;
    public float delay = 3f;
    public int damage = 10;

    public GameObject explosionEffect;

    public float areaOfEffect;
    public LayerMask whatIsDestructible;

    float countdown;
    bool hasExploded = false;

	// Use this for initialization
	void Start () {
        countdown = delay;
        rb.velocity = transform.right * speed;

	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);

        for (int i = 0; i < objectsToDamage.Length; i++)
        {
            objectsToDamage[i].GetComponent<DestructibleEnvi>().health -= damage;            
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
        
    }
    
}
