using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Execution : MonoBehaviour
{
    /// <summary>
    /// This script will be used to execute the methods from the other little scripts we 
    /// have created.
    /// The reason to I do this, is to create script with single responsibilities.
    /// </summary>



    //This variable will contain an array of gun scriptable objects
    public GunsType_ScriptableObject[] gunScriptableObjects;

    //This variable will be used to see what scriptable object is currently in use
    [SerializeField] private GunsType_ScriptableObject activeScriptableObject;

    //Reference to the gun ui manager
    Manager_WeaponUi gunUiScript;
    //Reference to the gun 3d manager
    Manager_Gun3dManager gun3dScript;



    void Start()
    {
        //Fills the variables with references to the other scripts
        FindScripts();
        //Executes the methods from the other scripts, and uses the data from the first S.O. in the array
        FirstRun();
    }

    private void FindScripts()
    {
        gunUiScript = FindObjectOfType<Manager_WeaponUi>();
        gun3dScript = FindObjectOfType<Manager_Gun3dManager>();
    }

    private void FirstRun()
    {
        //Will set the variable to be the first s.o. in the array
        activeScriptableObject = gunScriptableObjects[0];

        //Will execute the methods from the other scripts
        gunUiScript.AssignUI(activeScriptableObject);
        gun3dScript.SpawnGun(activeScriptableObject);
    }
}
