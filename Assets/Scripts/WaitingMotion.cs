using UnityEngine;
using System.Collections;

public class WaitingMotion : MonoBehaviour {
    private Animator motion;
    private AnimatorStateInfo start;
	// Use this for initialization
	void Start () {
		motion = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	   if (start.normalizedTime > 1.0f){
           
       }
	}

    void Wait2(){
        start = motion.GetCurrentAnimatorStateInfo(0);
    }
    void Wait1(){
        start = motion.GetCurrentAnimatorStateInfo(0);
    }
}
