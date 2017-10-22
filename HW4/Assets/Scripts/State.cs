using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State {

	private Type behaviour;
	private string name;

	Dictionary<Symbol, State> transition;

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

	public State(string name, Type behaviour) {
		this.name = name;
		this.behaviour = behaviour;
		transition = new Dictionary<Symbol, State> ();
	}

	public void AddTransition(Symbol key, State value) {
		transition.Add (key, value);
	}

	public State ApplySymbol(Symbol symbol) {
		if (transition.ContainsKey (symbol))
			return transition [symbol];
		return this;
	}
}
