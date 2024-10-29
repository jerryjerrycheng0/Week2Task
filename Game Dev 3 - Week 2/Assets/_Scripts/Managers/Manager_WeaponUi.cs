using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameDevWithMarco.ScriptableObjects;

namespace GameDevWithMarco.Managers
{
    public class Manager_WeaponUi : MonoBehaviour
    {
        public TMP_Text gunName;
        public TMP_Text gunSubTitle;
        public TMP_Text gunDescription;
        public Image gunSymbol;
        public GunsType_ScriptableObject[] gunsSO; //An array of scriptable guns
        private int currentIndex = 0;

        // Reference to the gun execution manager to spawn the new 3D gun
        private Manager_Execution gunExecutionScript;

        void Start()
        {
            
            gunExecutionScript = FindObjectOfType<Manager_Execution>();
        }

        //Assigns the UI data
        public void AssignUI(GunsType_ScriptableObject currentSO)
        {
            gunName.text = currentSO.gunName;
            gunSubTitle.text = currentSO.gunSubTitle;
            gunDescription.text = currentSO.gunDescription;
            gunSymbol.sprite = currentSO.gunSymbol.sprite;
        }

        // Cycles between guns and updates both UI and 3D model
        public void DisplayItem(bool next)
        {
            //The boolean "next" is used to determine if the list goes forwards or backwards
            if (next)
            {
                currentIndex = (currentIndex + 1) % gunsSO.Length; //List goes forwards
            }
            else
            {
                currentIndex = (currentIndex - 1 + gunsSO.Length) % gunsSO.Length; //List goes backwards
            }

            GunsType_ScriptableObject currentSO = gunsSO[currentIndex];
            AssignUI(currentSO);

            //Showcase the current gun
            gunExecutionScript.UpdateActiveGun(currentSO);
        }
    }
}
