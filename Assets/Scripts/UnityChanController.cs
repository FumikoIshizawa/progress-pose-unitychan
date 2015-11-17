using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour {
	private Animator animator;

	private int doWalkId;
	private int doRunId;
	private int count_walk = 0;
	
	void Start () {
		animator = GetComponent<Animator> ();
		doWalkId = Animator.StringToHash ("Do WALK");
		doRunId = Animator.StringToHash ("Do RUN");
	}

	void Update () { 
		// Test Source! feel free to delete this :>
		if (Input.GetKey (KeyCode.UpArrow)) {
			animator.SetBool (doWalkId, true);
			count_walk++;
		} else {
			animator.SetBool (doRunId, false);
			animator.SetBool (doWalkId, false);
			count_walk = 0;
		}
		if (count_walk == 5) {
			animator.SetBool (doRunId, true); 
		}
	}
}
