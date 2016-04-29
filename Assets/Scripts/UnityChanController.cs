using UnityEngine;
 
[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour, IReciever {
	private Animator animator;

	private int doWalkId;
	private int doRunId;
	private int count = 0;
    private int waiting1;
    private int waiting2;
	private int count_walk = 0;
  private SceneManager sceneManager;

	void Start () {
    sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    sceneManager.AddGameObj(this.gameObject);
		animator = GetComponent<Animator> ();
		doWalkId = Animator.StringToHash ("Do WALK");
		doRunId = Animator.StringToHash ("Do RUN");
        waiting1 = Animator.StringToHash("Base Layer.WAIT02");
        waiting2 = Animator.StringToHash("Base Layer.WAIT04");
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
		if(isBasicMode()){
			var currentState = animator.GetCurrentAnimatorStateInfo (0);
			if (currentState.fullPathHash == waiting1) {
				count++;
				if (count > 120) {
					count = 0;
					setWait (2);
					setWait (1);
				}
			}else {
				Debug.Log("どこここ？");
			}	
		}
	}

	void setWait(int stage){
		count = 0;
		string stateName = "";
		if (stage == 1) {
			stateName = "Idle1";
		} else if (stage == 2) {
			stateName = "Idle2";
		}
		animator.SetTrigger (stateName);
	}

	bool isEndWaiting2(AnimatorStateInfo state){
		if (waiting2 != state.fullPathHash)	return false;
		else if (state.normalizedTime < 0.9f) return false;
		return true;
	}
	bool isBasicMode(){
		return animator.GetBool ("BasicMode");
	}

	public void OnRecieve(float value){
		float threshold = 5f;
		if (threshold < value) {
			animator.SetBool ("BasicMode", false);
			animator.SetBool ("FearMode", true);
		} else if (threshold >= value) {
			animator.SetBool ("BasicMode", true);
			animator.SetBool ("FearMode", false);			
		}
	}
    void OnGUI(){
        float width = 150f;
        float height = 60f;
        float startx = 510f;
        float starty = 120f;
        if(GUI.Button(new Rect(startx,starty,width,height), "草原へ")){
            transform.position = new Vector3(-22f,2f,-50f);
        }
        if(GUI.Button(new Rect(startx,starty+height*1.5f,width*0.8f,height*0.8f), "森へ")){
            transform.position = new Vector3(10f,2f,-22f);
        }
    }
}
