using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PadAgent : Agent {

	[SerializeField] Transform m_Target;

	// Use this for initialization
	void Start () {
		Assert.IsNotNull(m_Target);
	}
	
	public override void AgentReset(){

	}

	public override void CollectObservations(){
		// Vector3 relativePosition = Target.position - transform.position;
		
		// // Relative position
		AddVectorObs(transform.position.x/5);
		AddVectorObs(transform.position.z/5);
	}

	public override void AgentAction(float[] vectorAction, string textAction){
		// Time penalty
		AddReward(-0.05f);

		// Car damage penalty
		// float damage = m_Damage.GetDamageAndReset();
		// AddReward(-damage);

		// // Car rewards
		// float reward = m_Reward.GetRewardAndReset();
		// AddReward(reward);

		// // Actions, size = 2

		// float force = Mathf.Clamp(vectorAction[0], -1, 1);
		// m_Controller.Throttle(force);

		// float steer = 0;
		// steer = Mathf.Clamp(vectorAction[1], -1, 1);
		// m_Controller.Steer(steer);

	}
}
