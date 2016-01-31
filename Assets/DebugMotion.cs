using UnityEngine;
using System.Collections;

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
       
	}
	
	// Update is called once per frame
	void Update () {
	   Debug.Log(OnDebug);
	}
    
    
    void OnGUI(){
        if (GUI.Button(new Rect(20, 20, 100, 50), "Button"))
        {
            OnDebug = true;
        }
    }
}
