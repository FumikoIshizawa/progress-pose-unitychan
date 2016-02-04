using UnityEngine;


public class particleCntr : MonoBehaviour, IReciever {

    private ParticleSystem ps;
    private SceneManager sceneManager;
    public int ratio = 45;
	// Use this for initialization
	void Start () {
        ps = this.gameObject.GetComponent<ParticleSystem>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        sceneManager.AddGameObj(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	   
	}
    
    void RainGain(int gain){
        ps.Emit(gain);
    }
    
    public void OnRecieve(float value){
        RainGain((int)value * ratio);
    }
}
