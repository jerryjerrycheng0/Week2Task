using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Guns_Parent : MonoBehaviour
{
    /// <summary>
    /// The purpose of this script is to create a "Parent" class
    /// that we can then use in "children" classes to make them inherits 
    /// variables and methods from it.
    /// </summary>

    //KEYWORDS:
    //public            -- WILL be inherited and WILL be visible in the editor
    //private           -- WILL NOT be inherited and WILL NOT be visible in the editor
    //protected         -- WILL inherited but WILL NOT be visible in the editor
    //abstract class    -- means that this is a polymorphism class
    //virtual           -- means that that method can be overridden (modified in a child script)


    //These three variables will deal with the muzzle flash
    public Transform tipOfTheBarrel;
    public GameObject muzzleFlash;
    public Vector3 muzzleFlashRotationAdjustment = new Vector3(0,95,0);

    //Recoil variables
    protected Vector3 originalPosition;
    public Vector3 recoilAmount;
    public float recoilDuration;

    //Gun sound variables
    public AudioClip gunSound;
    protected AudioSource gunAudioSource;

    public virtual void Start()
    {
        originalPosition = transform.position;
        gunAudioSource = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MuzzleFlash();
            GunSound();
            Recoil();
        }
    }

    public virtual void MuzzleFlash()
    {
        //THe first line will spawn the muzzle flash
        GameObject flash = Instantiate(muzzleFlash, tipOfTheBarrel.position, transform.rotation);
        //The next line will adjust the rotation of it
        flash.transform.Rotate(muzzleFlashRotationAdjustment);        
    }

    public virtual void Reload()
    {
        Debug.Log("Reloading Parent");
    }


    public virtual void Recoil()
    {
        var newRotation = transform.position + recoilAmount;

        transform.DOPunchRotation(newRotation, recoilDuration);
    }


    //Will force each child to implement their version of the GunSound() method
    public abstract void GunSound();
    
}
