using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyFlipper : MonoBehaviour {

    public GameObject deathEffect;
    private Transform playerLoc;
    private bool m_FacingLeft = true;  // For determining which way the family member is currently facing.

    // Use this for initialization
    void Start () {
        playerLoc = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerLoc.position.x > deathEffect.transform.position.x && m_FacingLeft)
        {
            Flip();
        }else if(playerLoc.position.x < deathEffect.transform.position.x && !m_FacingLeft)
        {
            Flip();
        }
	}

    private void Flip()
    {
        // Switch the way the family member is labelled as facing.
        m_FacingLeft = !m_FacingLeft;

        transform.Rotate(0f, 180f, 0f);
    }

}
