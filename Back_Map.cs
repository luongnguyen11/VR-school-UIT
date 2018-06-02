using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Map : MonoBehaviour {

    // Use this for initialization
    public GameObject canvas;
    public float timeOut;
    public GameObject canvas_back;
    public bool check;
	void Start () {
        timeOut = 0f;
        check = false;
	}
	public void isLooking()
    {
        check = false;
        timeOut = 0f;
    }
    public void NoLook()
    {
        check = true;
    }
    public void Reset()
    {
        if (check == true)
        {
            timeOut += Time.deltaTime;
            if (timeOut >= 10f)
            {
                canvas.SetActive(false);
                canvas_back.SetActive(true);
                timeOut = 0f;
            }
        }
    }
	// Update is called once per frame
	public void Update () {
        Reset();
        
    }
}
