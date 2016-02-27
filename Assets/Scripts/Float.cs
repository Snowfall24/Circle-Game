using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour
{
    TextMesh txt;

    // Use this for initialization
    void Start()
    {
        txt = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.color = new Color(1, 1, 1, txt.color.a - (1f * Time.deltaTime));
		transform.position += new Vector3(0, 2f * Time.deltaTime);
        transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);

		//Delete if no longer visible
        if (txt.color.a <= 0)
        {
            Destroy(gameObject);
        }

    }
}
