using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	[SerializeField] Text m_ScoreText;
	List<int> m_Score;

	// Use this for initialization
	void Start () {
		m_Score.Add(0);
		m_Score.Add(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int player, int score){

	}
}
