using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMgr : MonoBehaviour {

    public Text scoreValueText;
    public Text highScoreValueText;

	// Use this for initialization
	void Start () {
        scoreValueText.text = GameManager.instance.GetScore().ToString();
        highScoreValueText.text = GameManager.instance.GetHighScore().ToString();
	}

}
