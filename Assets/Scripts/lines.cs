using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lines : MonoBehaviour {

	// Use this for initialization
	void DrawLine(Vector3 startPos, Vector3 endPos, Color color, float duration = .2f)
    {
        GameObject myLine = new GameObject("line");
        myLine.transform.position = startPos;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lineR = myLine.GetComponent<LineRenderer>();
        lineR.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lineR.startColor = color;
        lineR.endColor = color;
        lineR.startWidth = 0.05f;
        lineR.endWidth = 0.05f;
        lineR.SetPosition(0, startPos);
        lineR.SetPosition(1, endPos);
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
