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
        public string gunName;
        public string gunSubTitle;
        public string gunDescription;
        public string gunFireSpeed;

        public GameObject gunPrefab;
        public Image gunSymbol;

    }
}
