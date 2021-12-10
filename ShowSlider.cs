using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Slider").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int i = 1;
    public void ChangeSliderState()
    {
        if (i/2==0)
        {
            transform.Find("Slider").gameObject.SetActive(true);
            i++;
        }
        else
        {
            transform.Find("Slider").gameObject.SetActive(false);
            i--;
        }
        
    }
}
