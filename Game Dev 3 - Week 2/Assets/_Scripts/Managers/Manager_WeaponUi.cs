using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameDevWithMarco.ScriptableObjects;

namespace GameDevWithMarco
{
    public class Manager_WeaponUi : MonoBehaviour
    {

        //References to the UI elements that we want to change 
        public TMP_Text gunName;
        public TMP_Text gunSubTitle;
        public TMP_Text gunDescription;
        public Image gunSymbol;
        public GunsType_ScriptableObject[] gunsSO;
        private int currentIndex = 0;



        //The method has a parameter of type scp_GunsType_ScriptableObject in 
        //order to be versatile when we need to use it.
        public void AssignUI(GunsType_ScriptableObject currentSO)
        {
            //These lines of code will assign the data we have in the s.o. to the Ui
            gunName.text = gunsSO[currentIndex].gunName;
            gunSubTitle.text = gunsSO[currentIndex].gunSubTitle;
            gunDescription.text = gunsSO[currentIndex].gunDescription;
            gunSymbol.sprite = gunsSO[currentIndex].gunSymbol.sprite;
        }

        public void DisplayItem(bool Next)
        {
            if (Next)
            {
                if (currentIndex + 1 > gunsSO.Length - 1)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }
            }
            else
            {
                if (currentIndex - 1 < 0)
                {
                    currentIndex = gunsSO.Length - 1;
                }
                else
                {
                    currentIndex--;
                }
            }
            gunName.text = gunsSO[currentIndex].gunName;
            gunSubTitle.text = gunsSO[currentIndex].gunSubTitle;
            gunDescription.text = gunsSO[currentIndex].gunDescription;
            gunSymbol.sprite = gunsSO[currentIndex].gunSymbol.sprite;
        }
    }
}
