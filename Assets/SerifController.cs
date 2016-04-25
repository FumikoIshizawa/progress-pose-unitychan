using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class SerifController : MonoBehaviour {

    public Text serif;
    private List<string> serifs = new List<string>();
    private Entity_serif entitySerif;
   
    public AudioClip audioClip;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
	    entitySerif = Resources.Load("DATA/serif") as Entity_serif;
        entitySerif.sheets[0].list.ForEach(x => serifs.Add(x.serif));
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void ChangeSerif(int id){
        serif.text = serifs[id];
    }
    
    void OnGUI(){
        float width = 72f;
        float height = 25f;
        float startx = 240f;
        float starty = 120f;
        foreach (var item in serifs.Select((v, i) => new { v, i }))
        {
            float x = startx;
            if (item.i%2 != 0) x += width * 1.2f;
            float y = starty + item.i * height * 0.8f;
            if(GUI.Button(new Rect(x,y,width,height),(item.i+1).ToString())){
                ChangeSerif(item.i);
                audioSource.Play();
                Debug.Log("serif => " + item.v);
            }
        }
    }
}
