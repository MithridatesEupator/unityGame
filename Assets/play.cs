using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour {

    public Sprite sprite;
    int verticalLevel;
    int horizontalLevel;
    bool pressedAllowed;
    float increment = .05f;
    private SpriteRenderer spriteR;
    public Text text;
    GameObject moveSprite;
    int[][] positionVar = new int[0][];
    int typeVar;

    int[][] extendArray(int[][] baseArray, int[] addArray)
    {
        int c = baseArray.Length;
        int[][] finalArray = new int[c + 1][];
        for (int i = 0; i < c; i++)
        {
            finalArray[i] = baseArray[i];
        }
        finalArray[c] = addArray;
        return finalArray;
    }

    int[] extendArray(int[] baseArray, int addArray)
    {
        int c = baseArray.Length;
        int[] finalArray = new int[c + 1];
        for (int i = 0; i < c; i++)
        {
            finalArray[i] = baseArray[i];
        }
        finalArray[c] = addArray;
        return finalArray;
    }

    int[] GenerateCoords()
    {
        int a = Random.Range(-2, 3);
        int b = Random.Range(-2, 3);
        int i = 0;
        while (i < positionVar.Length)
        {
            if (positionVar.Length != 25)
            {
                if (a == positionVar[i][0] && b == positionVar[i][1])
                {
                    i = -1;
                    a = Random.Range(-2, 3);
                    b = Random.Range(-2, 3);
                }
            }
            else
            {
                break;
            }
            i++;
        }
        return new int[] {a,b};
    }

    IEnumerator GenerateObject()
    {
        pressedAllowed = false;
        moveSprite = new GameObject();
        spriteR = moveSprite.AddComponent<SpriteRenderer>();
        spriteR.transform.localScale = new Vector2(.42f, .42f);
        spriteR.sprite = sprite;
        int[] temp = GenerateCoords();
        horizontalLevel = temp[0];
        verticalLevel = temp[1];
        int a = Random.Range(0, 4);
        int R;
        int B;
        int G;
        if (a == 1) {
            R = 1;
            B = 0;
            G = 0;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(R, G, B, 0);
            typeVar = 1;
        }
        else if (a == 2)
        {
            R = 0;
            B = 0;
            G = 1;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(R, G, B, 0);
            typeVar = 2;
        }
        else if (a == 3)
        {
            R = 0;
            B = 1;
            G = 1;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(R, G, B, 0);
            typeVar = 3;
        }
        else
        {
            R = 1;
            B = 0;
            G = 1;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(R, G, B, 0);
            typeVar = 4;
        }
        moveSprite.transform.position = new Vector3(temp[0], temp[1], -1);
        for (float h = 0; h < 1.0f; h += .05f)
        {
            yield return new WaitForSeconds(.000625f);
            moveSprite.GetComponent<SpriteRenderer>().color = new Color((float) R, (float) G, (float) B, h);
        }
        moveSprite.GetComponent<SpriteRenderer>().color = new Color((float) R, (float) G, (float) B, 1.0f);
        pressedAllowed = true;
    }

    void Start ()
    {
        pressedAllowed = true;
        StartCoroutine(GenerateObject());
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("s") && verticalLevel != -2 && pressedAllowed)
        {
            bool check = true;
            for(int i = 0; i < positionVar.Length; i++)
            { 
                if (horizontalLevel == positionVar[i][0] && (verticalLevel - 1) == positionVar[i][1])
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                StartCoroutine(moveAnimation(0.0f, -1.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("w") && verticalLevel != 2 && pressedAllowed)
        {
            bool check = true;
            for (int i = 0; i < positionVar.Length; i++)
            {
                if (horizontalLevel == positionVar[i][0] && (verticalLevel + 1) == positionVar[i][1])
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                StartCoroutine(moveAnimation(0.0f, 1.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("a") && horizontalLevel != -2 && pressedAllowed)
        {
            bool check = true;
            for (int i = 0; i < positionVar.Length; i++)
            {
                if ((horizontalLevel -1) == positionVar[i][0] && verticalLevel == positionVar[i][1])
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                StartCoroutine(moveAnimation(-1.0f, 0.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("d") && horizontalLevel != 2 && pressedAllowed)
        {
            bool check = true;
            for (int i = 0; i < positionVar.Length; i++)
            {
                if ((horizontalLevel + 1) == positionVar[i][0] && verticalLevel == positionVar[i][1])
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                StartCoroutine(moveAnimation(1.0f, 0.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("space") && pressedAllowed)
        {
    
            int[] posVar = new int[] { horizontalLevel, verticalLevel, typeVar};
            positionVar = extendArray(positionVar, posVar);
            string print = "{";
            foreach(int[] varArray in positionVar)
            {
                print += "{";
                foreach (int var in varArray)
                {
                    print += var.ToString() + ",";
                }
                print += "}";
            }
            print += "}";
            StartCoroutine(GenerateObject());
            int[] posArray = new int[0];
        
            for(int n = 0; n < positionVar.Length; n++)
            {
                for (int k = 0; k < positionVar.Length; k++)
                {
                    if (positionVar[n][0] == positionVar[k][0] && n != k && positionVar[n][2] == positionVar[k][2])
                    {
                        posArray = extendArray(posArray, positionVar[n][0]);
                    }
                    else if (positionVar[n][1] == positionVar[k][1] && n != k)
                    {

                    }

                    System.Array.Sort(posArray);
                    Debug.Log()
                }
                
            }
        }
        if (positionVar.Length == 24 && pressedAllowed)
        {
            pressedAllowed = false;
            StartCoroutine(endGame());           
        }
    }

    IEnumerator endGame()
    {
        for (float a = 0; a < 1.0f; a += .05f)
        {
            yield return new WaitForSeconds(.000625f);
            text.color = new Color(0.0f, 0.0f, 0.0f, a);
        }
        text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        Debug.Log("DOWN");
        
    }

    IEnumerator moveAnimation(float x, float y, float z)
    {
        pressedAllowed = false;
        int orgX = horizontalLevel;
        int orgY = verticalLevel;
        horizontalLevel += (int) x;
        verticalLevel += (int) y;
        for (float i = 0.0f; i <= 1.0f; i += increment)
        {
            yield return new WaitForSeconds(.000001f);
            moveSprite.transform.position = new Vector3(orgX + (i * x), orgY + (i * y), -1);
        }
        moveSprite.transform.position = new Vector3(horizontalLevel, verticalLevel, -1);
        pressedAllowed = true;
    }

}
