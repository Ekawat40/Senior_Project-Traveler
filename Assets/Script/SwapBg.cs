namespace PedometerU.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using Firebase;
    using Firebase.Database;
    using Firebase.Unity.Editor;
    using System;

    public class SwapBg : ChangeAppearances
    {

        public SpriteRenderer part;
        public Sprite[] options;
        public int index;
        public Text stepText, distanceText, testText;
        private Pedometer pedometer;
        private int num, numBg;
        public int state ;
        int Round = 0;
        private DatabaseReference reference;
        public int temp;


        private void Start()
        {
            pedometer = new Pedometer(OnStep);
            // Reset UI
            OnStep(0, 0);
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
            // สำหรับใช้ในการอ้างอิง Firebase
            reference = FirebaseDatabase.DefaultInstance.RootReference;
            // Create a new pedometer




        }

        private void OnStep(int steps, double distance)
        {
            // Display the values // Distance in feet
            num = steps;
            numBg = steps;
            Round = steps;
            //testText.text = numBg.ToString();
            stepText.text = num.ToString();
            //stepText.text = steps.ToString();
            //distanceText.text = (distance * 3.28084).ToString("F2") + " ft";
        }

        private void OnDisable()
        {
            // Release the pedometer
            //pedometer.Dispose();
            pedometer = null;
        }

        void Update()
        {
            /*  for (int i = 0; i < options.Length; i++)
             {
                 if (i == index)
                 {
                     part.sprite = options[i];
                 }
             }*/

            Cbg();
            //setState();
        }

        

        public void Cbg()
        {
            /*if (num>15)
            {
                index++;
                num = 0;
            }
            else 
            {
                index = 0;
            }*/


            // ถ้านับก้าวครบทุกๆ15ก้าวจะเปลี่ยนประเทศ 

            /* if (numBg >= 40)
             {
                 index++;
             }
             else if(numBg >=80)
             {
                 index = 0;
             }*/


            // ถ้าครบ10เปลี่ยนBg ถ้าครบ20เปลี่ยนBG ถ้าครบ30เปลี่ยนBg  / Bgแรกจะstate=1 โดยจะเพิ่มตามลำดับแต่ละstate เมื่อครบรอบstate = 1เพื่อกลับไปวนลูปใหม่


            /*if (state == 0)
            {

                if (numBg >= 20)
                {

                    index++;
                    state = 1;
                    part.sprite = options[index];
                }
            }
            else if (state == 1)
            {
                if (numBg >= 40)
                {
                    index++;
                    state = 2;
                    part.sprite = options[index];
                }
            }
            else if (state == 2)
            {
                if (numBg >= 60)
                {
                    index++;
                    state = 3;
                    part.sprite = options[index];
                }
            }
            else if (state == 3)
            {
                if (numBg >= 80)
                {
                    index++;
                    state = 4;
                    part.sprite = options[index];
                }
            }
            else if (state == 4)
            {
                if (numBg >= 100)
                {
                    index = 0;
                    state = 0;
                    part.sprite = options[index];
                }
            }*/


            if (state == 0)
            {

                if (Round >= 20)
                {
                    Round = Round - 20;
                    index++;
                    state = 1;
                    part.sprite = options[index];
                    Round = 20;
                }
                //Round = 20;
            }
            else if (state == 1)
            {
                if (Round >= 40)
                {
                    Round = Round - 40;
                    index++;
                    state = 2;
                    part.sprite = options[index];
                    Round = 40;
                }
               // Round = 40;
            }
            else if (state == 2)
            {
                if (Round >= 60)
                {
                    Round = Round - 60;
                    index++;
                    state = 3;
                    part.sprite = options[index];
                    Round = 60;
                }
               // Round = 60;
            }
            else if (state == 3)
            {
                if (Round >= 80)
                {
                    Round = Round - 80;
                    index++;
                    state = 4;
                    part.sprite = options[index];
                    Round = 80;
                }
                //Round = 80;
            }
            else if (state == 4)
            {
                if (Round >= 100)
                {
                    Round = Round - 100;
                    index = 0;
                    state = 0;
                    part.sprite = options[index];
                    Round = 0;
                }
                //Round = 0;
            }

        }

        public void Addnum()
        {
            Round += 1;
            Debug.Log(Round);
        }


        public void btnCity()
        {
            Debug.Log("State : "+ state);
            setName();
            SaveState();
            reference.Child("User/" + RootName).Child("StepCount").SetValueAsync(num);
            SceneManager.LoadScene("MapCountry");
        }
        public void btnShop()
        {
            SceneManager.LoadScene("ShopItem");
        }

        public void btnmain()
        {
            SceneManager.LoadScene("Main_1");
        }

        public void setState()
        {
            
            //healthValue = PlayerPrefs.GetInt("HealthKey", 0);
            //PlayerPrefs.SetInt("HealthKey", 0);
            if (PlayerPrefs.HasKey("StateKEy"))
            {
                //do something
            }
            temp = PlayerPrefs.GetInt("StateKey", 0);
        }


        public void SaveState()
        {
            
            PlayerPrefs.SetInt("StateKey", state);


        }






    }
}