using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;  //DoTween library

public class Guns_Rotator : MonoBehaviour
{
    //THese two variables are used for the drag rotations
    public float rotationSpeed = 10f;
    Camera cam;

    //These two variables are used for the lerping of the weapon
    //to its original rotation
    Vector3 originalRotation = new Vector3(0,60,12);
    public float lerpTime = 0.5f;
    public Vector3 punch;
    public float punchDuration;

    private void Start()
    {
        //Will find the camera and store it into the variable
        cam = FindObjectOfType<Camera>();
    }



    private void OnMouseDrag()
    {
        RotateWeapon();
    }

    private void OnMouseUp()
    {
        StartCoroutine(RotateToOriginal());  
    }



    //This code to rotate the weapon comes from a Youtube video
    //https://www.youtube.com/watch?v=Jxz5wbv7z3k&t=67s (I just used the pc code)
    private void RotateWeapon()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed;

        Vector3 right   = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
        Vector3 up      = Vector3.Cross(transform.position - cam.transform.position, right);

        transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
    }

    IEnumerator RotateToOriginal()
    {
        //This line will rotate the gun back to its set position over some time
        //It will also store the informations into a Tween that we can then use
        Tween myTween = transform.DORotate(originalRotation, lerpTime);
        //Waits for the mentioned tween to finish before executing the next line
        yield return myTween.WaitForCompletion();
        //Punches the rotation at the end to make it feel better
        transform.DOPunchRotation(punch, punchDuration);
    }
}
