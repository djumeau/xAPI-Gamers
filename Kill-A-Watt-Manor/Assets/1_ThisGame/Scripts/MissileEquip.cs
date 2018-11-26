using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEquip : MonoBehaviour {

    public Transform firePoint;
    public GameObject missilePrefab;
    private Animator m_Anim;

    // Use this for initialization
    void Start () {
        m_Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(Missile());
        }

    }

    IEnumerator Missile()
    {
        m_Anim.SetBool("Shooting", true);
        Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(0.1f);
        m_Anim.SetBool("Shooting", false);
    }
}
