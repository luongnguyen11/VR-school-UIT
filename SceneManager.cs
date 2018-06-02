using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    // Use this for initialization
    public List<Texture> Textures;
    public List<GameObject> text;
    public List<GameObject> btn;
    public GameObject Sphere;
	void Start () {
		
	}

    public void gotoScene(int Stt)
    {
        Sphere.GetComponent<Renderer>().material.mainTexture = Textures[Stt];
        text[Stt].SetActive(true);
        btn[Stt].SetActive(true);
        for (int i = 0; i < text.Count; i++)
            if (Stt != i)
            {
                text[i].SetActive(false);
                btn[i].SetActive(false);
            }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
