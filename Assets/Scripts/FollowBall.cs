using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FollowBall : MonoBehaviour {

	[SerializeField] Transform m_Target;
	PadMovement m_PadMovement;

	// Use this for initialization
	void Start () {
		m_PadMovement = GetComponent<PadMovement>();
		Assert.IsNotNull(m_PadMovement, "m_PadMovement is null");
		if(m_Target == null)
			Debug.LogError("m_Target is null");
	}
	
	// Update is called once per frame
	void Update () {
		float direction = 0.0f;
		if(m_Target.position.y > transform.position.y)
			direction = 1.0f;
		else if(m_Target.position.y < transform.position.y)
			direction = -1.0f;

		m_PadMovement.Move(direction);
	}
}
