using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCol : MonoBehaviour
{
    public AudioSource audioS;
    public bool StartBGM = false;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BGMColTrue()
    {
        StartBGM = true;
        audioS.PlayOneShot(audioS.clip);
    }
    public void BGMColFalse()
    {
        StartBGM = false;
        audioS.Stop();
    }
    public void BGMStart()
    {
        //if(StartBGM == true)
        //{
            audioS.PlayOneShot(audioS.clip);
        //}
        //else
        //{
        //audioS.Stop();
        //}

    }

}
