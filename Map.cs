using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    // Use this for initialization
    public float myTime = 0f;
    public float myTime1 = 0f;
    public Transform Radial;
    public bool stop;
    public void Start()
    {
        myTime = 0f;
        myTime1 = 0f;
        Radial.GetComponent<Image>().fillAmount = 0;
        stop = false;
    }
    // Update is called once per frame

    public void Reset()
    {
        myTime = 0f;
        myTime1 = 0f;
        Radial.GetComponent<Image>().fillAmount = 0.001f;
        stop = false;
    }

    public void Update()
    {        
        if (stop == false)
        {
            myTime1 += Time.deltaTime;
            if (myTime1 >= 4f)
            {
                myTime += Time.deltaTime;
                Radial.GetComponent<Image>().fillAmount = myTime;
                if (Radial.GetComponent<Image>().fillAmount == 1)
                {
                    stopTime();
                }
            }
        }
    }
    public void stopTime()
    {
        myTime = 0f;
        myTime1 = 0f;
        Radial.GetComponent<Image>().fillAmount = 0;
        stop = true;
    }
}
