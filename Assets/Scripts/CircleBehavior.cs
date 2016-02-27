using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CircleBehavior : MonoBehaviour {
	public SpriteRenderer outline;
	float outlineSize = 2f;
	float size = 2f;

	public AudioSource clickSound;

	SpriteRenderer SR;
	//List<string> texts = new List<string>();
	string[] texts;
	GameObject text;
	GameObject particles;

	Color color;

	TextAsset file;

	float delay = 0;
	float maxdelay = 0.1f;

	// Use this for initialization
	void Start() {
		SR = GetComponent<SpriteRenderer>();

		file = Resources.Load("circlegametext") as TextAsset;
		texts = file.text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None);

		text = Resources.Load("Text") as GameObject;
		particles = Resources.Load("Particles") as GameObject;

		SetColor();
	}

	// Update is called once per frame
	void Update() {
		delay -= Time.deltaTime;

		if ((Input.GetMouseButtonDown(0) && delay <= 0) || (Input.GetMouseButton(1) && delay <= -0.1f)) {
			clickSound.Play();

			SetColor();
			outlineSize = 3f;
			delay = maxdelay;

			//Add text
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = -1;
			GameObject t = Instantiate(text, mousePos, Quaternion.identity) as GameObject;
			Instantiate(particles, mousePos, Quaternion.Euler(0, 180, 180));
			t.GetComponent<TextMesh>().text = texts[Random.Range(0, texts.Length - 1)];



			//Debug.Log("Text created at: " + mousePos.x + " " + mousePos.y + " " + mousePos.z);
		}
		if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
			size = 1.8f;
		} else {
			size = 2f;
		}

		SR.transform.localScale = Vector3.Lerp(SR.transform.localScale, new Vector3(size, size, 1f), Time.deltaTime * 10);
		SR.color = Color.Lerp(SR.color, color, Time.deltaTime * 10f);

		Outline();

		if (Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene(0);
		}
	}

	void SetColor() {
		color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 0.9f);
	}

	void Outline() {
		outlineSize -= 2f * Time.deltaTime;

		if (outlineSize < 2f) {
			outlineSize = 2f;
		}

		Color outlineColor = SR.color;
		outlineColor.a = 0.2f;
		outline.color = outlineColor;
		outline.transform.localScale = Vector3.Lerp(outline.transform.localScale, new Vector3(outlineSize, outlineSize, outlineSize), Time.deltaTime * 20);
	}
}
