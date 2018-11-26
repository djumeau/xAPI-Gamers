using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    [SerializeField]
    private Animator animator;

    public float runSpeed = 60.0f;

    private float horizontalMove = 0f;
    private bool jump = false;

    private Vector3 respawnPosition;
    private bool isRespawningPlayer = false;

    private void Awake()
    {
        respawnPosition = this.transform.position;
        Debug.Log("Position of player [" + respawnPosition);
    }

    private void RespawnPlayer()
    {
        Debug.Log("Respawn player");
        isRespawningPlayer = true;
        this.transform.position = respawnPosition;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector" && !isRespawningPlayer)
        {
            Debug.Log("Hit Fall Detector");
            RespawnPlayer();
        } else {
            isRespawningPlayer = false;
        }
    }

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // Debug.Log("Jumping");
            FindObjectOfType<AudioManager>().Play("jump");
            animator.SetBool("IsJumping", true);
        }

	}

    public void OnLanding()
    {
        // Debug.Log("Landing.");
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
