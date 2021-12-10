using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonPic : MonoBehaviour
{
    public Sprite Mysprit;
    
    private Sprite Defallsprit;
    
    private bool ischange = false;

    //public MediaPlayer PlayingPlayer;
    // Use this for initialization
    void Start()
    {

        ///Listen for click events
        transform.GetComponent<Button>().onClick.AddListener(OnClick);
        ///Gets the initial default image of the button
        Defallsprit = transform.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Method executed after the button is clicked
    /// </summary>
    public void OnClick()
    {
        transform.GetComponent<Image>().sprite = Mysprit;
        transform.GetComponent<Image>().sprite = Defallsprit;
    }
}
