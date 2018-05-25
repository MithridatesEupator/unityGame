using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lines : MonoBehaviour {

	// Use this for initialization
	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = .2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        //GameObject.Destroy(myLine, duration);
    }

    void Start()
    {
        DrawLine(new Vector3(-2.525f, -2.5f, -2.0f), new Vector3(2.525f, -2.5f, -2.0f), Color.black);
        DrawLine(new Vector3(2.5f, 2.5f, -2.0f), new Vector3(2.5f, -2.5f, -2.0f), Color.black);
        DrawLine(new Vector3(2.525f, 2.5f, -2.0f), new Vector3(-2.525f, 2.5f, -2.0f), Color.black);
        DrawLine(new Vector3(-2.5f, -2.5f, -2.0f), new Vector3(-2.5f, 2.5f, -2.0f), Color.black);
        //----------------------------------------------------------------------------------------
        DrawLine(new Vector3(-1.5f, 2.5f, -2.0f), new Vector3(-1.5f, -2.5f, -2.0f), Color.black);
        DrawLine(new Vector3(1.5f, 2.5f, -2.0f), new Vector3(1.5f, -2.5f, -2.0f), Color.black);
        DrawLine(new Vector3(-0.5f, 2.5f, -2.0f), new Vector3(-0.5f, -2.5f, -2.0f), Color.black);
        DrawLine(new Vector3(0.5f, 2.5f, -2.0f), new Vector3(0.5f, -2.5f, -2.0f), Color.black);
        //----------------------------------------------------------------------------------------
        DrawLine(new Vector3(-2.5f, -1.5f, -2.0f), new Vector3(2.5f, -1.5f, -2.0f), Color.black);
        DrawLine(new Vector3(-2.5f, -0.5f, -2.0f), new Vector3(2.5f, -0.5f, -2.0f), Color.black);
        DrawLine(new Vector3(-2.5f, 1.5f, -2.0f), new Vector3(2.5f, 1.5f, -2.0f), Color.black);
        DrawLine(new Vector3(-2.5f, 0.5f, -2.0f), new Vector3(2.5f, 0.5f, -2.0f), Color.black);
    }
}
