using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour {

	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	// OnClick
	// Events in C# (in .NET)
	public void ClickTest() {
		text.text = "Button was pressed and it was good.";
	}

	// OnValueChanged
	public void ValueChangedTest(float v) {
		text.text = "Value was changed to " + v + " and it was OK.";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
