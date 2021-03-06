﻿using UnityEngine;
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
	float total_score = 0;

  private List<GameObject> allObj = new List<GameObject>();
	// Use this for initialization
	void Start () {
		getTeamStatus();
		notifyAllObj(total_score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void AddGameObj(GameObject go)
  {
    allObj.Add(go);
  }

	private void getTeamStatus()
  {
    StartCoroutine (getHealthStatus());
  }
	private float calcTeamScore(){
		// range 0f-10f
		return (float)(github_score + photo_score + slack_score) / 0.3f;
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
		total_score = calcTeamScore ();
    // Debug output
    Debug.Log ("Result(" + latestDate + "): " + github_score + ", " + slack_score + ", " + photo_score); 
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
    void OnGUI(){
        var stylestate = new GUIStyleState();
        stylestate.textColor = Color.magenta;
        var style = new GUIStyle();
        style.normal = stylestate;
        total_score = GUI.HorizontalSlider(new Rect(100, 200, 100, 20), total_score, 0f, 10f);
        GUI.Label( new Rect(220, 200, 200, 20), total_score.ToString(), style);
        notifyAllObj(total_score);
  }
}
