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
        // References to the UI elements that we want to change 
        public TMP_Text gunName;
        public TMP_Text gunSubTitle;
        public TMP_Text gunDescription;
        public Image gunSymbol;
        public GunsType_ScriptableObject[] gunsSO;
        private int currentIndex = 0;

        // Reference to the gun execution manager to spawn the new 3D gun
        private Manager_Execution gunExecutionScript;

        void Start()
        {
            // Find the Manager_Execution script
            gunExecutionScript = FindObjectOfType<Manager_Execution>();
        }

        // Assigns the UI data
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
            if (next)
            {
                currentIndex = (currentIndex + 1) % gunsSO.Length;
            }
            else
            {
                currentIndex = (currentIndex - 1 + gunsSO.Length) % gunsSO.Length;
            }

            GunsType_ScriptableObject currentSO = gunsSO[currentIndex];
            AssignUI(currentSO);

            // Call the Manager_Execution to update the 3D model
            gunExecutionScript.UpdateActiveGun(currentSO);
        }
    }
}
