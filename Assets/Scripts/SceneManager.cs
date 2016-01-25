using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; 
 
public class SceneManager : MonoBehaviour { 
  static string url = "http://pom.l-u-l.tk" ;
  static string healthUrlParameter = "/api/health_scores/1";
	 
  string latestDate = "";
  double github_score = 0;
  double slack_score = 0;
  double photo_score = 0;

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
    StartCoroutine (getHealthStatus());
    return 10f;
  }

  IEnumerator getHealthStatus() 
  {
    string urlHealth = url + healthUrlParameter;
 	
    WWW www = new WWW (urlHealth);
    yield return www; 

    JSONObject json = new JSONObject (www.text);
    JSONObject latestData = json [6]; 

    latestDate = latestData.GetField("date").str; 
    github_score = latestData.GetField ("github_score").GetField("value").n; 
    slack_score = latestData.GetField ("slack_score").GetField("value").n;
    photo_score = latestData.GetField ("photo_score").GetField("value").n; 
    // Debug output
    // Debug.Log ("Result(" + latestDate + "): " + github_score + ", " + slack_score + ", " + photo_score); 
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
