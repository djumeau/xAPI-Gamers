using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPickup : MonoBehaviour {

    public int FlashLightPowerUp;
    public AudioClip pickupSound;
    AudioSource audioSourcePickup;

    private void Start()
    {
        audioSourcePickup = GetComponent<AudioSource>();  
    }

    bool gotFlashlight;

    void OnTriggerEnter2D(Collider2D other)
      {
        if(other.tag == "Player" && !gotFlashlight)
        {
            gotFlashlight = true;
            audioSourcePickup.PlayOneShot(pickupSound, 0.7f);
            GBL_Interface.SendFlashlightPick();
            StartCoroutine(FLPickup(other));

        }
      }

    IEnumerator FLPickup(Collider2D player)
    {
        

        Weapon weapon = player.GetComponent<Weapon>();
        weapon.flashlightPower += FlashLightPowerUp;


        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetBool("Pickup", true);

        yield return new WaitForSeconds(.43f);

        playerAnimator.SetBool("Pickup", false);

                
        Destroy(gameObject);

    }

}