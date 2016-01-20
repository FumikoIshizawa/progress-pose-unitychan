using UnityEngine;
using System.Collections;

public class LightningCtr : MonoBehaviour, IReciever {

    private SceneManager sm;
    private ParticleSystem ps;
    public float ratio = 0.5f;
	// Use this for initialization
	void Start () {
	   sm = GameObject.Find("SceneManager").GetComponent<SceneManager>();
       sm.AddGameObj(this.gameObject);
       ps = this.gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void RainGain(int gain){
        ps.Emit(gain);
    }
    
    public void OnRecieve(float value){
        RainGain((int)(value * ratio));
    }
}
