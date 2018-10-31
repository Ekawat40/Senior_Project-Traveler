using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class ChangeAppearances : MonoBehaviour {
    Scene sceneM;
    public Color[] colors;
    public Sprite[] cOptions;
    public Sprite[] hOptions;
    public int whatColor = 0;
    public int clothId = 0;
    public int hairId = 0;
    public int gender;
    public SpriteRenderer skin;
    public SpriteRenderer cloth;
    public SpriteRenderer hair;
    private DatabaseReference reference;

    // Use this for initialization
    void Start () {
        sceneM = SceneManager.GetActiveScene();
        if (sceneM.name == "CreateGirlCharacter")
        {
            gender = 0;
        }
        else if (sceneM.name == "CreateBoyCharacter")
        {
            gender = 1;
        }
        // ใช้สำหรับอ้างอิง Firebase Project
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveller-c316a.firebaseio.com/"); ของตัวที่ใช้ร่วมกัน
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

	// Update is called once per frame
	void Update () {
        for (int i = 0; i < colors.Length; i++)
        {
            if (i == whatColor)
            {
                skin.color = colors[i];
            }
        }
        for (int i = 0; i < cOptions.Length; i++)
        {
            if (i == clothId)
            {
                cloth.sprite = cOptions[i];
            }
        }
        for (int i = 0; i < hOptions.Length; i++)
        {
            if (i == hairId)
            {
                hair.sprite = hOptions[i];
            }
        }
    }

    public void CreateCharacter()
    {
        SceneManager.LoadScene("Main_1");
        var refPush = reference.Child("User").Push();
        //refPush.Child("Username").SetValueAsync(""+username.text);
        refPush.Child("Skincolor").SetValueAsync(whatColor);
        refPush.Child("Gender").SetValueAsync(gender);
        refPush.Child("ClothId").SetValueAsync(clothId);
        refPush.Child("HairId").SetValueAsync(hairId);

    }

    public void ChangeSkinColor(int skinId)
    {
        whatColor = skinId;
    }
    public void ChangeCloth(int cId)
    {
        clothId = cId;
    }
    public void ChangeHair(int hId)
    {
        hairId = hId;
    }
}
