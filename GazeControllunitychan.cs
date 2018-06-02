using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class GazeControllunitychan : MonoBehaviour
{

    // Use this for initialization
    public float mytime;
    public Animator anim;
    public AudioClip audioClip;
    public float inputH;
    public float inputV;
    public Rigidbody rigid;
    public bool check;
    Rigidbody rBody;

    void Start()
    {
        inputH = 0f;
        inputV = 1f;
        anim = GetComponent<Animator>();
        check = false;
        rigid = GetComponent<Rigidbody>();
    }
    public void au()
    {
        AudioSource aud = GetComponent<AudioSource>();
        aud.PlayOneShot(audioClip);
    }
    
    public void Cute()
    {
        if (mytime >= 20f)
        {
            anim.Play("WAIT02", -1, 0f);
            mytime = 0;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        Cute();
        
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
       
    }
}
