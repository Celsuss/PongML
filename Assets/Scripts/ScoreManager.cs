using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class ScoreManager : MonoBehaviour {
	static ScoreManager m_Instance = null;
	static public ScoreManager Instance { 
		get{
			if(m_Instance)
				return m_Instance;
			m_Instance = new ScoreManager();
			return m_Instance;
		}
	}
	
	public delegate void EndGameEvent();
	public static event EndGameEvent OnEndGame;
	[SerializeField] Text m_ScoreText;
	[SerializeField] int m_MaxScore = 3;
	List<float> m_Score = new List<float>();

	// Use this for initialization
	void Start () {
		if(m_Instance != null && m_Instance != this)
			Destroy(m_Instance);
		m_Instance = this;

		Assert.IsNotNull(m_Score);
		Assert.IsNotNull(m_ScoreText);

		m_Score.Add(0);
		m_Score.Add(0);
		UpdateScoreText();				
	}

	public void AddScore(int player, float score){
		m_Score[player] += score;
		UpdateScoreText();

		if(m_Score[0] > m_MaxScore)
			EndGame(0);
		if(m_Score[1] > m_MaxScore)
			EndGame(1);
	}

	void EndGame(int winner){
		if(OnEndGame != null)
			OnEndGame();
	}
	void UpdateScoreText(){
		m_ScoreText.text = "Score: " + m_Score[0] + " - " + m_Score[1];
	}

	public void Reset(){
		for(int i = 0; i < m_Score.Count; ++i)
			m_Score[i] = 0;
	}

}
