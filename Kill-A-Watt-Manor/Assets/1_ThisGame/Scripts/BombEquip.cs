using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEquip : MonoBehaviour {

    public Transform firePoint;
    public GameObject truthBombPrefab;
    private Animator m_Anim;

    // Use this for initialization
    void Start () {
        m_Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Bomb());
        }

    }

    IEnumerator Bomb()
    {
        m_Anim.SetBool("Shooting", true);
        Instantiate(truthBombPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(0.1f);
        m_Anim.SetBool("Shooting", false);
    }
}