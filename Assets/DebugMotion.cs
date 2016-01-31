using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DebugMotion : MonoBehaviour {
    private bool _ondebug;
    public bool OnDebug{
        get{ return this._ondebug;}
        set{ _ondebug=value; motion.SetBool("OnDEBUG",value); }
        }
    private Animator motion;
	// Use this for initialization
	void Start () {
	   motion = gameObject.GetComponent<Animator>();
       if(motions!=null){
           Debug.Log("all motions:");
           foreach (var item in new List<string>(motions))
           {
               Debug.Log(" " + item + " ");
           }
       }
	}
	
	// Update is called once per frame
	void Update () {
	   Debug.Log(OnDebug);
	}
    
    
    void OnGUI(){
        float width = 72f;
        float height = 20f;
        float startx = 240f;
        float starty = 20f;
        if(OnDebug){
            foreach (var item in motions.Select((v, i) => new { v, i }))
            {
                float x = startx;
                if (item.i%2 != 0) x += width * 1.2f;
                float y = starty + item.i * height * 0.8f;
                if(GUI.Button(new Rect(x,y,width,height),item.v)){
                    motion.SetTrigger(item.v);
                }
            }
        }
        else {
            if (GUI.Button(new Rect(20, 20, 100, 50), "Button"))
            {
                OnDebug = true;
            }
        }
    }
    private string[] motions = new string[]{
            "WALK_B",
            "WALK_L",
            "WALK_R",
            "WALK_F",
            "RUN_F",
            "RUN_L",
            "RUN_R",
            "UMATOBI",
            "JUMP0",
            "JUMP0",
            "JUMP0B",
            "JUMP1",
            "JUMP1B",
            "WAIT0",
            "WAIT1",
            "WAIT2",
            "WAIT3",
            "WAIT4",
            "REFLESH",
            "HANDUP",
            "DAMAGE0",
            "DAMAGE1",
            "SLIDE",
            "WIN",
            "LOSE",
            "IDLE",
        };
    
    
}
