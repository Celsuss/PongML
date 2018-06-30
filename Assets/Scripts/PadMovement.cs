using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMovement : MonoBehaviour {
	[SerializeField] float m_Speed = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(float direction){
		transform.Translate(new Vector3(0, Mathf.Clamp(direction, -1, 1) * m_Speed, 0));
	}
}
