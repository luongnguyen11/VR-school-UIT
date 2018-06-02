using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> talks;
	void Start () {
        
	}
    public void gotoTalk(int stt)
    {
        talks[stt].SetActive(true);
        for (int i = 0; i < talks.Count; i++)
            if (stt != i)
                talks[i].SetActive(false);
    }

    public void offTalk(int stt)
    {
        talks[stt].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
