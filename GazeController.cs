using UnityEngine;
using UnityEngine.UI;

public class GazeController : MonoBehaviour
{
    // Use this for initialization
    public Talk talks;
    public float myTime = 0f;
    public float myTime1 = 0f;
    public Transform Radial;
    public bool stop;
    public float timeTalk;
    public charactercontrolller audioclip;
    public float tempx;
    Quaternion targetRotation;
    public float tempz;
    public GameObject cam;
    public GameObject character;
    public GazeControllunitychan controll;
    public float forwardInputz, forwardInputx;
    public float limit;
    public float gocalpha;
    float a_cam, b_cam;
    public RectTransform btn;
    public float x;
    bool isStep;
    float a, b;
    public float angle;
    public int stt;
    public void Start()
    {
        timeTalk = 0f;
        limit = 0.6f;
        isStep = false;
        forwardInputx = forwardInputz = 0f;
        tempz = 0f;
        tempx = 0f;
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
        a = 0f;
        b = 0f;
        character.GetComponent<Transform>().LookAt(new Vector3(cam.GetComponent<Transform>().position.x, character.GetComponent<Transform>().position.y, cam.GetComponent<Transform>().position.z));
            x = 0f;
        tempx = 0f;
        tempz = 0f;
        forwardInputx = 0f;
        timeTalk = 0f;
    }
    
    public void Update()
    {
        timeTalk += Time.deltaTime;
        if (timeTalk > 5f)
        {
            talks.offTalk(stt);
        }
        else
            talks.gotoTalk(stt);
        forwardInputx += Time.deltaTime;
        a = btn.position.x - character.GetComponent<Transform>().position.x;
        b = btn.position.z - character.GetComponent<Transform>().position.z;
        float tuX = a;
        float mauX = Mathf.Sqrt(a * a + b * b);
        float alpha = tuX / mauX;

        float tuY = b;
        float mauY = Mathf.Sqrt(a * a + b * b);
        float beta = tuY / mauY;
        forwardInputz += Time.deltaTime;
        a_cam = cam.GetComponent<Transform>().position.x - character.GetComponent<Transform>().position.x;
        b_cam = cam.GetComponent<Transform>().position.z - character.GetComponent<Transform>().position.z;
        float tu = a * a_cam + b * b_cam;
        float mau = Mathf.Sqrt(a * a + b * b) * Mathf.Sqrt(a_cam * a_cam + b_cam * b_cam);
        gocalpha = tu / mau;
        x = Mathf.Sqrt(a * a + b * b);
        if (x > 50f)
        {
            controll.inputV = 1f;
            controll.anim.SetFloat("inputV", controll.inputV);
            
            character.GetComponent<Transform>().position = new Vector3(character.GetComponent<Transform>().position.x + forwardInputx *0.2f* alpha, character.GetComponent<Transform>().position.y, character.GetComponent<Transform>().position.z + forwardInputx *0.2f* beta);
            
            character.GetComponent<Transform>().LookAt(new Vector3(btn.GetComponent<Transform>().position.x, character.GetComponent<Transform>().position.y, btn.GetComponent<Transform>().position.z));
            if (forwardInputz >= limit)
            {
                audioclip.au();
                forwardInputz = 0f;
            }
        }
        else
        {
            character.GetComponent<Transform>().LookAt(new Vector3(cam.GetComponent<Transform>().position.x, character.GetComponent<Transform>().position.y, cam.GetComponent<Transform>().position.z));
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
                        talks.offTalk(stt);
                    }
                }
            }

            if (isStep == false)
            {
                audioclip.au();
                isStep = true;
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
