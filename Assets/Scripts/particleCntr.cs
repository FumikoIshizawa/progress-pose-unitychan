using UnityEngine;
using System.Collections;

public class particleCntr : MonoBehaviour, IReciever {

    private ParticleSystem ps;
    private SceneManager sceneManager;
    public int high = 5000;
    public int low = 1000;
    public int nothing = 0;
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
    
    public void HighGain(){RainGain(high);}
    public void LowGain(){RainGain(low);}
    public void StopRain(){RainGain(nothing);}
    
    public void OnRecieve(float value){
        RainGain((int)value * ratio);
    }
}
