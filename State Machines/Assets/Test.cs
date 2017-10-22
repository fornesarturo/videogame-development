using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour {

	private AState current;
	private ASymbol t, g, p, b;
	private MonoBehaviour currentBehaviour;

	// Use this for initialization
	void Start () {
		AState sleeping = new AState ("sleeping", typeof(Sleeping));
		AState eating = new AState ("eating", typeof(Eating));
		AState peeing = new AState ("peeing", typeof(Peeing));
		AState playing = new AState ("playing", typeof(Playing));
		AState dead = new AState ("dead", typeof(Dead));

		t = new ASymbol ("treat");
		g = new ASymbol ("good boy");
		p = new ASymbol ("pet");
		b = new ASymbol ("bad boy");

		sleeping.AddTransition (t, eating);
		sleeping.AddTransition (b, peeing);
		sleeping.AddTransition (p, playing);

		eating.AddTransition (g, peeing);

		peeing.AddTransition (b, dead);

		dead.AddTransition (g, sleeping);

		playing.AddTransition (b, dead);

		current = sleeping;
		currentBehaviour = gameObject.AddComponent (current.Behaviour) as MonoBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		print (current.Name);
		if (Input.GetKeyUp (KeyCode.T))
			ApplySymbol (t);

		if (Input.GetKeyUp (KeyCode.G))
			ApplySymbol (g);

		if (Input.GetKeyUp (KeyCode.P))
			ApplySymbol (p);

		if (Input.GetKeyUp (KeyCode.B))
			ApplySymbol (b);

		if (Input.GetKeyUp (KeyCode.Return))
			SceneManager.LoadScene ("scene2");
	}

	private void ApplySymbol(ASymbol symbol) {
		AState previous = current;
		current = current.ApplySymbol (symbol);
		if (previous != current) {
			Destroy (currentBehaviour);
			currentBehaviour = gameObject.AddComponent (current.Behaviour) as MonoBehaviour;
		}
	}
}
