using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D_ThisGame))]
    public class Platformer2DUserControl_ThisGame : MonoBehaviour
    {
        private PlatformerCharacter2D_ThisGame m_Character;
        private bool m_Jump;
        public bool controls = true;



        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D_ThisGame>();
        }


        private void Update()
        {
            if (controls)
            {
                if(!m_Jump)
                {
                    // Read the jump input in Update so button presses aren't missed.
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
            }         
        }


        private void FixedUpdate()
        {
            if (controls)
            {
                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxis("Horizontal");

                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Jump);
                m_Jump = false;
            }        
        }

        //the player cant move
        public void CancelControls()
        {
            controls = false;
        }

        //give back the controls to player
        public void GiveBackControls()
        {
            controls = true;
        }
    }


}
