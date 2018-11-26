using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleEnvi : MonoBehaviour {

    public int health;
    public GameObject destroyEffect;

    private void Update()
    {
        if(health <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            //Add screenshake?
            Destroy(gameObject);

        }
    }
}
