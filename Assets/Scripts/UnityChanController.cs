using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour {
	private Animator animator;
	private int count = 0;

	private int doWalkId;
	private int doRunId;
	private int count_walk = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		doWalkId = Animator.StringToHash ("Do WALK");
		doRunId = Animator.StringToHash ("Do RUN");
	}
	
	// Update is called once per frame
	void Update () { 
		count++;
		// Test
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
		//
		 
		// Connection 
		// TODO: Time
		if (count == 100) {
			SessionManager manager = new SessionManager ();
			PoseUpdate updater = new PoseUpdate (animator);
			Pose pose = manager.getPoseId ();
			updater.updatePose (pose);
			count = 0;
		}
	}
}
