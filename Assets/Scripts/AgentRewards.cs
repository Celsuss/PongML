using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRewards : MonoBehaviour {
	float m_Reward;
	public float Reward{ get{
			float reward = m_Reward;
			m_Reward = 0;
			return reward;
		}}

	// Use this for initialization
	void Start () {
		m_Reward = 0;
	}

	public void GiveReward(float reward){
		m_Reward += reward;
	}

	public void Reset(){
		m_Reward = 0;
	}
}
