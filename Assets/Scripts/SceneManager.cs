using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SceneManager : MonoBehaviour {

  private List<GameObject> allObj = new List<GameObject>();
	// Use this for initialization
	void Start () {
    var value = getTeamStatus();
    notifyAllObj(value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void AddGameObj(GameObject go)
  {
    allObj.Add(go);
  }

  private float getTeamStatus()
  {
    return 10f;
  }

  private void notifyAllObj(float value)
  {
    foreach (var go in allObj)
    {
      ExecuteEvents.Execute<IReciever>(
        target: go,
        eventData: null,
        functor: (target, y) => target.OnRecieve(value));
    }
  }
}
