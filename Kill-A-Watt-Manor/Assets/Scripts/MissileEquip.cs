using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEquip : MonoBehaviour {

    public Transform firePoint;
    public GameObject missilePrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire3"))
        {
            Missile();
        }

    }

    void Missile()
    {
        Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
    }
}
