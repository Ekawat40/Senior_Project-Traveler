using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {


    public SpriteRenderer part;
    public Sprite[] options;
    public int index;


    int moneyAmount;
	int isLootboxSold;

	public Text moneyAmountText;
	public Text LootboxPrice;

	public Button buyButton;

	// Use this for initialization
	void Start () {
		moneyAmount = 200;

	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < options.Length; i++)
        {
            if (i == index)
            {
                part.sprite = options[i];
            }
        }


	}

	public void buyLootbox()
	{



       moneyAmount -= 200;
        PlayerPrefs.SetInt("IsLootboxSold", 1);
        LootboxPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
    }


    public void Swap()
    {

        int randomNumber = Random.Range(1, 4);

        /*if (index < options.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }*/
        if(randomNumber == 1)
        {
            index = 1;
        }else if(randomNumber == 2)
        {
            index = 2;
        }
        else if (randomNumber == 3)
        {
            index = 3;
        }

    }


        public void btnCity()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void btnShop()
    {
        SceneManager.LoadScene("ShopItem");
    }

    public void btnmain()
    {
        SceneManager.LoadScene("Main_1");
    }



}
