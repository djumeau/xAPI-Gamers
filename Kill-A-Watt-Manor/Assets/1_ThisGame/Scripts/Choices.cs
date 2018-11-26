using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour {

    public RPGTalk talk;
    
	// Use this for initialization
	void Start () {
        talk.OnMadeChoice += OnMadeChoice;        
	}
	
	void OnMadeChoice(int questionID, int choiceID)
    {
        Debug.Log("In the question " + questionID + "player chose choice " + choiceID);
        //xAPI Statements go here?        
    }
}
