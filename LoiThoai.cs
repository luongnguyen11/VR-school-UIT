using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoiThoai : MonoBehaviour {

    // Use this for initialization
    public float myTime;
    public List<GameObject> list;
    public int i;
    public GameObject game;
    public SceneManager scene;
	void Start () {
        myTime = 0f;
        i = 1;
        list[0].SetActive(true);
	}
    public void change()
    {

            myTime += Time.deltaTime;
            if (myTime > 5f)
            {
                list[i].SetActive(true);
                list[i - 1].SetActive(false);
                myTime = 0f; i++;
            }

       
    }
    // Update is called once per frame
    void Update () {
        if(i<list.Count)
            change();
        if (i == list.Count)
        {
            game.SetActive(true);
            scene.gotoScene(0);
            list[i - 1].SetActive(false);
            i++;
        }
    }
}
