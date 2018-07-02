using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class InputParser : MonoBehaviour {
	static InputParser m_Instance = null;
	static public InputParser Instance { 
		get{
			if(m_Instance)
				return m_Instance;
			m_Instance = new InputParser();
			return m_Instance;
		}
	}

	[SerializeField] Text m_InputText;
	[SerializeField] int m_MaxInputs;
	Queue<float> m_Inputs;

	// Use this for initialization
	void Start () {
		if(m_Instance != null && m_Instance != this)
			Destroy(m_Instance);
		m_Instance = this;

		Assert.IsNotNull(m_InputText);
	}

	void UpdateInputText(){
		string text = "Inputs: [";
		foreach(float input in m_Inputs){
			text.Insert(text.Length-1, input.ToString() + ", ");
		}

		// Remove last komma 
		if(!text.EndsWith("["))
			text.Remove(text.Length-1);

		text.Insert(text.Length-1, "]");
	}

	public void AddInput(float input){
		m_Inputs.Enqueue(input);

		while(m_Inputs.Count > m_MaxInputs)
			m_Inputs.Dequeue();

		UpdateInputText();
	}

	public void Reset(){
		m_Inputs.Clear();
	}
}
