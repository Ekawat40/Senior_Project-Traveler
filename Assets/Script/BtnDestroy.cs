using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [SerializeField]
    GameObject btnDes;

    public void btnDestroy()
    {
        Destroy(btnDes);
    }
}
