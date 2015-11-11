using UnityEngine;
using System.Collections; 

public enum Pose {
	pose1,
	pose2,
	pose3
}; 

static class PoseExtender {
	// TODO: return Animator
	public static string PoseName(this Pose pose) {
		switch(pose) {
		case Pose.pose1:
			return "Pose 1";
		case Pose.pose2:
			return "Pose 2";
		case Pose.pose3:
			return "Pose 3";
		default:
			return "No Pose";
		}
	}
}

public class PoseUpdate { 
	Animator animator;

	public PoseUpdate (Animator sanimator) {
		animator = sanimator;
	}

	public void updatePose(Pose pose) {
		Debug.Log (pose.PoseName());
	}
}
