using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

	public static LevelControlScript instance = null;
	GameObject levelSign, gameOverText;
	int sceneIndex, levelPassed;

	// Use this for initialization
	void Start () {
		
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		levelSign = GameObject.Find ("LevelNumber");
		//gameOverText = GameObject.Find ("GameOverText");
		//youWinText = GameObject.Find ("YouWinText");
		gameOverText.gameObject.SetActive (false);


		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
	}

	public void youWin()
	{
		if (sceneIndex == 3)
			Invoke ("loadMainMenu", 1f);
		else {
			if (levelPassed < sceneIndex)
				PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
			levelSign.gameObject.SetActive (false);

			Invoke ("loadNextLevel", 1f);
		}
	}


	void loadNextLevel() //ปลดล็อคlevel แก้เป็นปลดล็อคไอเทม/เมือง ต่างๆเมื่อจ่ายตังค์
	{
		//SceneManager.LoadScene (sceneIndex + 1);
	}

	void loadMainMenu()
	{
		SceneManager.LoadScene ("MainMenu"); //เปลี่ยนscene
	}
}
