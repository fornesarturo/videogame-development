using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AState {

	private Type behaviour;
	private string name;

	// each of the states needs to know where to go.
	Dictionary<ASymbol, AState> transition;


	// property
	// equivalent to get/set methods
	public string Name {
		get {
			return name;
		}
	}

	public Type Behaviour {
		get {
			return behaviour;
		}
	}

	public AState(string name, Type behaviour) {
		this.name = name;
		transition = new Dictionary<ASymbol, AState> ();
		this.behaviour = behaviour;
	}

	public void AddTransition(ASymbol key, AState value) {
		transition.Add (key, value);
	}

	public AState ApplySymbol(ASymbol key) {
		if (transition.ContainsKey (key))
			return transition [key];
		return this;
	}
}
