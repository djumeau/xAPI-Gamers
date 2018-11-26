using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public int flashlightPower = 0;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    private Animator m_Anim;
    public AudioClip beam;
    AudioSource audioSource;

    
   
    

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());            

        }

        
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy == null)
            {
                Instantiate(impactEffect, hitInfo.point, Quaternion.identity); // impact Effect Here
            }
            if (enemy != null)
            {
                if(flashlightPower >= enemy.pigPower)
                {
                    Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
                    enemy.TakeDamage(damage);
                }
                else
                {
                    StartCoroutine(enemy.Ricochet());
                }
                
            }

           
            
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;
        m_Anim.SetBool("Shooting", true);
        audioSource.PlayOneShot(beam, 0.7F);

        yield return new WaitForSeconds(0.1f);

        m_Anim.SetBool("Shooting", false);
        lineRenderer.enabled = false;
    }

    
}
