using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBuildingCol : MonoBehaviour
{
    public GameObject House;
    public GameObject Exit;
    public GameObject Land;
    public GameObject Rotate;

    public GameObject TargetLookAt;

    public bool BuildingLock = true;
    public bool HouseLock = false;


    public float speed = 0.5f;
    public GameObject target;

    public List<GameObject> builds = new List<GameObject>();
    public static GameObject[] buildNumber = new GameObject[100];
    private int i = 0;
    //private int a = 0;

    void Awake()
    {
        House.SetActive(false);
        Exit.SetActive(false);
        Land.SetActive(false);
        Rotate.SetActive(false);
        i = 0;
        //foreach (var item in builds)
        //{
        //    buildNumber[i] = item;
        //    i++;
        //    Debug.Log(item);
        //    Debug.Log(buildNumber[1]);
        //}

    }

    void Update()
    {

        if ( BuildingLock == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.transform.CompareTag("House"))
                //{
                //    TargetLookAt = hit.transform.gameObject;
                //    //buildingCol = hit.transform.gameObject.GetComponent<WebBuildingCol>();
                //    Debug.Log(TargetLookAt.gameObject.name);
                //}
                if (Input.GetMouseButtonDown(0) && hit.transform.CompareTag("Ground") && HouseLock == false)
                {
                    //HouseLock = true;
                    House.transform.position = hit.point;//Get the coordinates of the collision point with the ground
                }
            }
        }

    }
    public void HouseCilk()
    {
        BuildingLock = false;
        HouseLock = false;
        Land.SetActive(true);
        House.SetActive(true);
        Exit.SetActive(true);
        Rotate.SetActive(true);       
    }
    public void ExitCilk()
    {
        BuildingLock = true;
        Land.SetActive(false);
        Exit.SetActive(false);
        Rotate.SetActive(false);
        HouseLock = false;
    }
    public void RightCilk()
    {
        if (BuildingLock == false)
        {
            House.transform.Rotate(0, 90, 0, Space.Self);
        }
    }
    public void LeftCilk()
    {
        if (BuildingLock == false)
        {
            House.transform.Rotate(0, -90, 0, Space.Self);
        }
    }
}
