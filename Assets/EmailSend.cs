using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class EmailSend : MonoBehaviour {

    private DatabaseReference reference;
    public InputField email_input;

    // Use this for initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btn()
    {


        string[] separatingChars = { "@" };

        string text1 = email_input.text;
        System.Console.WriteLine("Original text: '{0}'", text1);

        string[] words = text1.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
        System.Console.WriteLine("{0} substrings in text:", words.Length);

        Debug.Log(words[0]);

        

         var refPush = reference.Child("User/" + words[0]).Child("Name").SetValueAsync("aekwatt");

    }
}
