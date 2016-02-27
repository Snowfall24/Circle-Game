using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CircleBehavior : MonoBehaviour
{
	public SpriteRenderer outline;
	float outlineSize = 2f;
	float size = 2f;

	public AudioSource clickSound;

    SpriteRenderer SR;
    List<string> texts = new List<string>();
    GameObject text;
	GameObject particles;

	Color color;

    float delay = 0;
    float maxdelay = 0.1f;

    // Use this for initialization
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        StreamReader sr = new StreamReader(Application.dataPath + "\\circlegametext.txt");
        while (!sr.EndOfStream)
        {
            texts.Add(sr.ReadLine());
        }

        text = Resources.Load("Text") as GameObject;
		particles = Resources.Load("Particles") as GameObject;

		SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && delay <= 0)
        {
			clickSound.Play();

			SetColor();
			outlineSize = 3f;
            delay = maxdelay;

			//Add text
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = -1;
			GameObject t = Instantiate(text, mousePos, Quaternion.identity) as GameObject;
			Instantiate(particles, mousePos, Quaternion.Euler(0, 180, 180));
            t.GetComponent<TextMesh>().text = texts[Random.Range(0, texts.Count - 1)];
        }
		if (Input.GetMouseButton(0)) {
			size = 1.8f;
		} else {
			size = 2f;
		}

		SR.transform.localScale = Vector3.Lerp(SR.transform.localScale, new Vector3(size, size, 1f), Time.deltaTime * 10);
		SR.color = Color.Lerp(SR.color, color, Time.deltaTime * 10f);

		Outline();
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
