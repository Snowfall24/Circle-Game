using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
	float time;

	void Start () {
	
	}
	
	void Update () {
		time += Time.deltaTime;

		if(time > 3) {
			Destroy(gameObject);
		}
	}
}
