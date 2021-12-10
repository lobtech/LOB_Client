using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoToURl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    string url = "https://hbeasts.com/";
    public void GouRL()
    {
        //Application.OpenURL("www.baidu.com");
        Application.OpenURL(url);
    }
}
