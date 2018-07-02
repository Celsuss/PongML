using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PadAgent : Agent {
	[SerializeField] InputParser m_InputParser;
	[SerializeField] Transform m_Target;
	PadMovement m_Movement;
	AgentRewards m_Rewards;

	// Use this for initialization
	void Start () {
		Assert.IsNotNull(m_InputParser);
		Assert.IsNotNull(m_Target);
		m_Movement = GetComponent<PadMovement>();
		Assert.IsNotNull(m_Movement);
		m_Rewards = GetComponent<AgentRewards>();
		Assert.IsNotNull(m_Rewards);
	}

	/*void OnEnable(){
		//ScoreManager.OnEndGame += AgentReset;
	}

	void OnDisable(){
		//ScoreManager.OnEndGame -= AgentReset;
	}*/
	
	public override void AgentReset(){
		m_Rewards.Reset();
	}

	public override void CollectObservations(){
		// Vector3 relativePosition = Target.position - transform.position;
		
		// // Relative position
		AddVectorObs(transform.position.x/5);
		//AddVectorObs(transform.position.z/5);
	}

	public override void AgentAction(float[] vectorAction, string textAction){
		// Time penalty
		AddReward(-0.05f);

		// Add all other rewards
		float reward = m_Rewards.Reward;
		AddReward(reward);

		// Actions, size = 1
		float direction = Mathf.Clamp(vectorAction[0], -1, 1);
		m_InputParser.AddInput(direction);
		m_Movement.Move(direction);
	}
}
