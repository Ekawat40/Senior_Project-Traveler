namespace PedometerU.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class SwapBg : MonoBehaviour
    {

        public SpriteRenderer part;
        public Sprite[] options;
        public int index;
        public Text stepText, distanceText,testText;
        private Pedometer pedometer;
        private int num, numBg;
        int state = 0;


        private void Start()
        {

            // Create a new pedometer
            pedometer = new Pedometer(OnStep);
            // Reset UI
            OnStep(0, 0);

            
        }

        private void OnStep(int steps, double distance)
        {
            // Display the values // Distance in feet
            num = steps;
            numBg = steps;
            //testText.text = numBg.ToString();
            stepText.text = num.ToString();
            //stepText.text = steps.ToString();
            //distanceText.text = (distance * 3.28084).ToString("F2") + " ft";
        }

        private void OnDisable()
        {
            // Release the pedometer
            pedometer.Dispose();
            pedometer = null;
        }

        void Update()
        {
           /* for (int i = 0; i < options.Length; i++)
            {
                if (i == index)
                {
                    part.sprite = options[i];
                }
            }*/

            Cbg();
        }

        public void Swap()
        {
            if (index < options.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
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


            if(state == 0)
            {

                if (numBg >= 20)
                {
                    index++;
                    state = 1;
                    part.sprite = options[index];
                }
            }else if(state == 1)
            {
                if (numBg >= 40)
                {
                    index++;
                    state = 2;
                    part.sprite = options[index];
                }
            }else if(state == 2)
            {
                if (numBg >= 60)
                {
                    index++;
                    state = 3;
                    part.sprite = options[index];
                }
            }else if(state == 3)
            {
                if (numBg >= 80)
                {
                    index++;
                    state = 4;
                    part.sprite = options[index];
                }
            }else if(state == 4)
            {
                if (numBg >= 100)
                {
                    index=0;
                    state = 0;
                    part.sprite = options[index];
                }
            }


        }

        public void Addnum()
        {
            num += 10;
        }


        public void btnCity()
        {
            SceneManager.LoadScene("DecorateCity2");
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
}