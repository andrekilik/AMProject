﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    // Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Pause"))
        {
            SceneManager.LoadScene("GameScene");
        }   
	}
}
