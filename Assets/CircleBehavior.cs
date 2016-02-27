using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CircleBehavior : MonoBehaviour
{
    SpriteRenderer SR;
    List<string> texts = new List<string>();
    GameObject text;

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

        Debug.Log(texts.ToString());

        text = Resources.Load("Text") as GameObject;

		SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && delay <= 0)
        {
			SetColor();
            delay = maxdelay;
            GameObject t = Instantiate(text) as GameObject;
            t.GetComponent<TextMesh>().text = texts[Random.Range(0, texts.Count - 1)];
        }
    }

	void SetColor() {
		SR.color = Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
	}
}
