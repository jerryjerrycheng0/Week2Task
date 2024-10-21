using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.ScriptableObjects;

namespace GameDevWithMarco.Managers
{
    public class Manager_Execution : MonoBehaviour
    {
        /// <summary>
        /// This script will be used to execute the methods from the other little scripts we 
        /// have created.
        /// The reason to I do this, is to create script with single responsibilities.
        /// </summary>



        //This variable will contain an array of gun scriptable objects
        public GunsType_ScriptableObject[] gunScriptableObjects;

        //This variable will be used to see what scriptable 
        [SerializeField] private GunsType_ScriptableObject activeScriptableObject;

        // Reference to the gun UI manager
        private Manager_WeaponUi gunUiScript;

        // Reference to the gun 3D manager
        private Manager_Gun3dManager gun3dScript;

        void Start()
        {
            // Fill the variables with references to the other scripts
            FindScripts();
            // Execute the methods from the other scripts and use data from the first S.O. in the array
            FirstRun();
        }

        private void FindScripts()
        {
            gunUiScript = FindObjectOfType<Manager_WeaponUi>();
            gun3dScript = FindObjectOfType<Manager_Gun3dManager>();
        }

        private void FirstRun()
        {
            // Set the variable to be the first S.O. in the array
            activeScriptableObject = gunScriptableObjects[0];

            // Execute the methods from the other scripts
            gunUiScript.AssignUI(activeScriptableObject);
            gun3dScript.SpawnGun(activeScriptableObject);
        }

        // New method to update the active gun
        public void UpdateActiveGun(GunsType_ScriptableObject newActiveGun)
        {
            activeScriptableObject = newActiveGun;
            gun3dScript.SpawnGun(newActiveGun);
        }
    }
}
