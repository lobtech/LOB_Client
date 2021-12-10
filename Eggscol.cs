using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggscol : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject egg;
    public Animator anim;
    public KeyS ks;
    public AudioCol ac;

    private Rigidbody rb;

    public Vector3 movingVec;
    private Vector3 thrustVec;//The impulse vector

    void Awake()
    {
        ac = GetComponent<AudioCol>();
        rb = GetComponent<Rigidbody>();
        ks = egg.GetComponent<KeyS>();
        //anim = egg.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float targetRunMulti = ks.run ? 2.0f : 1.0f;
        if (ks.inputEnable == true)
        {
            anim.SetFloat("forward", ks.Dmag);//Animations convert signals and speeds
            //anim.SetFloat("right", 0);
            if (ks.Dmag > 0.1f)
            {
                egg.transform.forward = ks.Dvec;
            }
        }
        movingVec = egg.transform.forward * ks.Dmag * speed;
    }
    private void FixedUpdate()
    {
        rb.position += movingVec * Time.fixedDeltaTime;
    }
}
