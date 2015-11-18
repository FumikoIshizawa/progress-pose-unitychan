using UnityEngine;
using System.Collections;

public class testReciever : MonoBehaviour, IReciever {

  private SceneManager sceneManager;

	// Use this for initialization
	void Start () {
    sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    sceneManager.AddGameObj(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void OnRecieve(float value)
  {
    Debug.Log(value);
  }
}
