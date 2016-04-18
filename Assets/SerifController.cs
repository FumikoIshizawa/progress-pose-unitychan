using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class SerifController : MonoBehaviour {

    public Text serif;
    private List<string> serifs = new List<string>();
    private Entity_serif entitySerif;
    
	// Use this for initialization
	void Start () {
	    entitySerif = Resources.Load("DATA/serif") as Entity_serif;
        entitySerif.sheets[0].list.ForEach(x => serifs.Add(x.serif));
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void ChangeSerif(int id){
        serif.text = serifs[id];
    }
    
    void OnGUI(){
        float width = 72f;
        float height = 20f;
        float startx = 240f;
        float starty = 20f;
        foreach (var item in serifs.Select((v, i) => new { v, i }))
        {
            float x = startx;
            if (item.i%2 != 0) x += width * 1.2f;
            float y = starty + item.i * height * 0.8f;
            if(GUI.Button(new Rect(x,y,width,height),item.i.ToString())){
                ChangeSerif(item.i);
                Debug.Log("serif => " + item.v);
            }
        }
    }
}
