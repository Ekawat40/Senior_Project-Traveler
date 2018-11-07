﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

    public GameObject Panel;
    public GameObject BtnCity;

    // Use this for initialization
    void Start()
    {
        Panel.SetActive(false);
    }
    public void changePanelState(bool state)
    {
        Panel.SetActive(state);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckCharacterHistory()
    {

    }
    public void ChangeSceneGirl()
    {
        SceneManager.LoadScene("CreateCharacter");
    }
    public void ChangeSceneBoy()
    {
        SceneManager.LoadScene("CreateBoyCharacter");
    }
    public void ChangeSceneGender()
    {
        SceneManager.LoadScene("ChooseGender");
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DecreaseMoney()
    {
        Destroy(BtnCity);
    }
}
