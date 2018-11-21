using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEquip : MonoBehaviour {

    public Transform firePoint;
    public GameObject truthBombPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2"))
        {
            Bomb();
        }

    }

    void Bomb()
    {
        Instantiate(truthBombPrefab, firePoint.position, firePoint.rotation);
    }
}
