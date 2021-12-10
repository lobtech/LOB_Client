using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyS : MonoBehaviour
{
    public string keyUp = "w";
    public string keyDown = "m";
    public string keyLeft = "m";
    public string keyRight = "m";

    [Header("===== Signl =====")]
    public float Dup;//Signal 1 to -1
    public float Dright;//
    public float Dmag;
    public Vector3 Dvec;
    public float Jup;//Camera control signal
    public float Jright;

    [Header("===== Others =====")]
    public bool inputEnable = true;

    protected float targetDup;
    protected float targetDright;
    protected float velocityDup;
    protected float velocityDright;


    public string keyJUp;
    public string keyJDown;
    public string keyJLeft;
    public string keyJRight;



    [Header("===== The mouse Settings =====")]
    public bool mouseEnable = false;
    public float mouseSensitivityX = 1.0f;
    public float mouseSensitivityY = 1.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (mouseEnable == true)
        {
            Jup = Input.GetAxis("Mouse Y") * 2.0f * -mouseSensitivityY;
            Jright = Input.GetAxis("Mouse X") * 2.0f * -mouseSensitivityX;
        }
        else
        {
            Jup = (Input.GetKey(keyJUp) ? 1.0f : 0.0f) - (Input.GetKey(keyJDown) ? 1.0f : 0.0f);//Camera control signal
            Jright = (Input.GetKey(keyJRight) ? 1.0f : 0.0f) - (Input.GetKey(keyJLeft) ? 1.0f : 0.0f);
        }

        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKeyDown(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKeyDown(keyRight) ? 1.0f : 0) - (Input.GetKeyDown(keyLeft) ? 1.0f : 0);

        if (inputEnable == false)//Direction of the lock
        {
            targetDup = 0;
            targetDright = 0;
        }

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Dmag = Mathf.Sqrt((Dup * Dup) + (Dright * Dright));
        Dvec = Dright * transform.right + Dup * transform.forward;
    }
    //protected void UpdateDmagDvec(float Dup2, float Dright2)
    //{
    //    Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
    //    Dvec = Dright2 * transform.right + Dup2 * transform.forward;
    //}
}
