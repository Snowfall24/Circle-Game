using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void LoadScene() {
		SceneManager.LoadScene("CircleScene");
	}
	
	void Update() {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
