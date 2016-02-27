using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	public void LoadScene() {
		SceneManager.LoadScene("CircleScene");
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
