using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCamera1 : MonoBehaviour
{
    //public WebBuildingCol wb;
    public KeyS ks;

    public GameObject backpackOpen;
    public GameObject backpackDown;
    public GameObject egg;
    public GameObject cameraHandle;
    private float tempEulerx;
    public GameObject model;
    private GameObject camer;
    public GameObject HouseList;

    public GameObject buildCamera;
    public GameObject eggCamera;

    public float horizontalSpeed = 20.0f;
    public float verticalSpeed = 20.0f;
    public float cameraDampValue = 0.5f;
    private Vector3 cameraDampVelocity;//Camera delay display

    private int i = 0;
    private int a = 0;


    void Start()
    {
        //cameraHandle = transform.parent.gameObject;
        //egg = cameraHandle.transform.parent.gameObject;
        HouseList.SetActive(false);
        tempEulerx = 20.0f;
        camer = Camera.main.gameObject;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (i == 1)
        //    {
        //        i = 0;
        //        Cursor.lockState = CursorLockMode.Locked;
        //    }
        //    if (i == 0)
        //    {
        //        i = 1;
        //        Cursor.lockState = CursorLockMode.None;
        //    }
        //}
        Vector3 tempModelEuler = model.transform.eulerAngles;
        //euler angle
        egg.transform.Rotate(Vector3.up, ks.Jright * -horizontalSpeed * Time.deltaTime);//Camera rotation and movement
                                                                                        //playerHandle.transform.Rotate(Vector3.up, ji.Jright * -horizontalSpeed * Time.fixedDeltaTime);
                                                                                        //cameraHandle.transform.Rotate(Vector3.right, pi.Jup * -verticalSpeed * Time.fixedDeltaTime);
                                                                                        //tempEulerx = cameraHandle.transform.eulerAngles.x;
        tempEulerx += ks.Jup * verticalSpeed * Time.deltaTime;
                                                                   //tempEulerx -= ji.Jup * -verticalSpeed * Time.fixedDeltaTime;

        tempEulerx = Mathf.Clamp(tempEulerx, -40, 80);
        cameraHandle.transform.localEulerAngles = new Vector3(tempEulerx, 0, 0);//Maximum and minimum camera angles

        model.transform.eulerAngles = tempModelEuler;//Change euler Angle to set the camera to free view

        camer.transform.position = Vector3.Lerp(camer.transform.position, transform.position, 0.5f);
        camer.transform.position = Vector3.SmoothDamp(camer.transform.position, transform.position, ref cameraDampVelocity, cameraDampValue);

        camer.transform.eulerAngles = transform.eulerAngles;
        camer.transform.LookAt(cameraHandle.transform);//Reduce screen shake  

    }
    public void CameraCilkOpen()
    {

        backpackOpen.SetActive(false);
        backpackDown.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        buildCamera.SetActive(true);
        eggCamera.SetActive(false);
        HouseList.SetActive(true);

    }
    public void CameraCilkDown()
    {

        backpackDown.SetActive(false);
        backpackOpen.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
        buildCamera.SetActive(false);
        eggCamera.SetActive(true);
        HouseList.SetActive(false);

    }
}
