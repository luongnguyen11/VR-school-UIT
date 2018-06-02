using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clickMap : MonoBehaviour
{

    // Use this for initialization
    public GameObject canvasBack;
    public GameObject canvasGoto;
    public Map gaze;
    public bool check;
    public Button btn;
    public int count;
    void Start()
    {
        check = true;
        count = 0;
    }

    // Update is called once per frame
    public void activeButton()
    {
        if (gaze.stop == true)
            btn.GetComponent<Button>().onClick.Invoke();
    }
    public void enter()
    {
        if (check == true && count < 1)
        {
            canvasBack.SetActive(false);
            canvasGoto.SetActive(true);
            check = false;
            count++;
            gaze.enabled = false;
            gaze.stop = false;

        }
    }
    public void Reset()
    {
        count = 0;
    }
    // Update is called once per frame
    public void Update()
    {
        check = true; ;
        activeButton();
    }
}

