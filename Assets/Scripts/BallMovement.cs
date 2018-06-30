using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	[SerializeField] float m_MaxAngle = 75f;
	[SerializeField] Vector3 m_Direction;
	[SerializeField] float m_Speed = 0.1f;
	Vector3 m_StartPosition;

	// Use this for initialization
	void Start () {
		m_StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeDirectionInYAxis();
		if(GetIsInGoal())
			Reset();	
	}

	void ChangeDirectionInYAxis(){
		transform.Translate(m_Direction * m_Speed);
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if(pos.y <= 0 || pos.y >= 1)
			m_Direction.y *= -1;
	}

	void OnCollisionEnter(Collision collision){
		Vector3 padPosition = collision.transform.position;
		float yOffset = Mathf.Clamp(transform.position.y - padPosition.y, -1f, 1f);
		float angle = yOffset * m_MaxAngle * Mathf.Deg2Rad;

		m_Direction = new Vector3(Mathf.Cos(angle) * collision.transform.right.x, Mathf.Sin(angle), 0f).normalized;
    }

	bool GetIsInGoal(){
		transform.Translate(m_Direction * m_Speed);
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

		if(pos.x <= 0.0f || pos.x >= 1.0f)
			return true;
		return false;
	}

	public void Reset(){
		transform.position = m_StartPosition;
	}
}