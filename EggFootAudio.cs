using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggFootAudio : MonoBehaviour
{
    public AudioCol ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioCol>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AudioManager()
    {
        ac.audioS.PlayOneShot(ac.audioS.clip);
    }
}
