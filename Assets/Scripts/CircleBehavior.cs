﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CircleBehavior : MonoBehaviour
{
	public SpriteRenderer outline;
	float outlineSize = 2f;

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
			outlineSize = 3f;
            delay = maxdelay;

			//Add text
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			GameObject t = Instantiate(text, mousePos, Quaternion.identity) as GameObject;
            t.GetComponent<TextMesh>().text = texts[Random.Range(0, texts.Count - 1)];
        }
		outlineSize -= 2f * Time.deltaTime;
		Color outlineColor = SR.color;
		outlineColor.a = 0.2f;
		outline.color = outlineColor;
		outline.transform.localScale = Vector3.Lerp(outline.transform.localScale, new Vector3(outlineSize, outlineSize, outlineSize), Time.deltaTime * 20);
    }

	void SetColor() {
		SR.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 0.9f);
	}
}
