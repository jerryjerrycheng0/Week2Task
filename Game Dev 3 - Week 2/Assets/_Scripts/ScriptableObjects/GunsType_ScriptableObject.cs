using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDevWithMarco.ScriptableObjects
{
    //CreateAssetMenu will allow us to create our new scriptable objects straight from the create tab
    [CreateAssetMenu(fileName = "NewGunData", menuName = "GunData", order = 1)]

    //A scriptable object is a data container.In this specific case we will just use it to store data for the 
    //guns we will create
    public class GunsType_ScriptableObject : ScriptableObject
    {
        //These variables are just data that we can customise when creating a new scriptable object!
        //We will use these to easily create more guns
        public string gunName; //Name of the gun
        public string gunSubTitle; //Subtitle of the gun
        public string gunDescription; //Description of the gun
        public string gunFireSpeed; //Fire speed of the gun

        public GameObject gunPrefab; //Prefab and appearance of the gun
        public Image gunSymbol; //Symbol of the gun

    }
}
