using UnityEngine;
using System.Collections;

public class LightingCtr : MonoBehaviour, IReciever {

    private SceneManager sceneManager;
    private Material skybox;
    private Light dLight;
    public float ratio = 0.1f;
	// Use this for initialization
	void Start () {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        sceneManager.AddGameObj(this.gameObject);
        
        skybox = new Material(RenderSettings.skybox);
        RenderSettings.skybox = skybox;
        
        dLight = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void OnRecieve(float value)
  {
    skybox.SetFloat("_AtmosphereThickness", 1f - value * ratio);
    Debug.Log("Atmos=>" + value*ratio);
    RenderSettings.skybox = skybox;
    dLight.intensity = (1f-value*ratio);
  }
}
