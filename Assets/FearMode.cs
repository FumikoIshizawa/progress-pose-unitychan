using UnityEngine;
using System.Collections;

public class FearMode : MonoBehaviour {

	private Animator motion;
	private int Fear1;
	private int Fear2;
	private int count = 0;
	// Use this for initialization
	void Start () {
		motion = gameObject.GetComponent<Animator> ();
		Fear1 = Animator.StringToHash ("Base Layer.Fear.REFLESH00");
		Fear2 = Animator.StringToHash ("Base Layer.Fear.LOSE00");
	}
	
	// Update is called once per frame
	void Update () {
		if(isFearMode()){
			var currentState = motion.GetCurrentAnimatorStateInfo (0);
			if (currentState.fullPathHash == Fear1) {
				count++;
				if (count > 120) {
					count = 0;
					motion.SetTrigger ("Fear2");
					motion.SetTrigger ("Fear1");
				}
//			}else if (isEndFear2(currentState)){
//				motion.SetTrigger ("Fear1");
			}else {
				Debug.Log("どこここ？");
			}

		}
	}
	bool isEndFear2(AnimatorStateInfo state){
		if (Fear2 != state.fullPathHash)	return false;
		else if (state.normalizedTime < 0.9f) return false;
		return true;
	}
	bool isFearMode(){
		return motion.GetBool ("FearMode");
	}
}
