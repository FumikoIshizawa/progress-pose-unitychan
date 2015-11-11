using UnityEngine;
using System.Collections;

public class SessionManager {
	Pose pose;
	 
	public Pose getPoseId() {
		manageSession ();
		return pose;
	}

	void manageSession() {
		pose = Pose.pose1;
	}
}
