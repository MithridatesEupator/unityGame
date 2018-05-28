using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour {

    public Sprite sprite;
    int verticalLevel;
    int horizontalLevel;
    bool pressedAllowed;
    float increment = .05f;
    private SpriteRenderer spriteR;
    public Text text;
    public Text playText;
    public Text pointText;
    GameObject moveSprite;
    int[,] positionVar = new int[5,5];
    int typeVar;
    bool reload = false;
    int intCount = 0;
    int gamePoints = 0;

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
        int a = Random.Range(0, 5);
        int b = Random.Range(0, 5);
        bool loop = true;
        while (loop)
        {
            if (intCount != 25)
            {
                if (positionVar[a, b] != 0)
                { 
                    a = Random.Range(0, 5);
                    b = Random.Range(0, 5);

                }
                else
                {
                    loop = false;
                }
            }
            else
            {
                loop = false;
            }
        }
        return new int[] {a,b};
    }

    IEnumerator GenerateObject()
    {
        int[] temp = GenerateCoords();
        horizontalLevel = temp[0];
        verticalLevel = temp[1];
        pressedAllowed = false;
        moveSprite = new GameObject("Block" + intCount);
        spriteR = moveSprite.AddComponent<SpriteRenderer>();
        spriteR.transform.localScale = new Vector2(.84f, .84f);
        spriteR.sprite = sprite;
        
        int a = Random.Range(0, 6);
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
        else if (a == 4)
        {
            R = 0;
            B = 0;
            G = 0;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(R, G, B, 0);
            typeVar = 4;
        }
        else if (a == 5)
        {
            R = 1;
            B = 0;
            G = 1;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(R, G, B, 0);
            typeVar = 6;
        }
        else
        {
            R = 1;
            B = 1;
            G = 0;
            moveSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            typeVar = 7;
        }
        moveSprite.transform.position = new Vector3(temp[0] - 2, -1 * temp[1] + 2, -1);
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
        pointText.text = gamePoints.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("s") && verticalLevel != 4 && pressedAllowed)
        {
            bool check = false;
            if (positionVar[horizontalLevel, verticalLevel + 1] == 0)
            {
                check = true;
            }
            if (check)
            {
                StartCoroutine(moveAnimation(0.0f, 1.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("w") && verticalLevel != 0 && pressedAllowed)
        {
            bool check = false;
  
            if (positionVar[horizontalLevel, verticalLevel - 1] == 0)
            {
                 check = true;
            }
            if (check)
            {
                StartCoroutine(moveAnimation(0.0f, -1.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("a") && horizontalLevel != 0 && pressedAllowed)
        {
            bool check = false;
            if (positionVar[horizontalLevel - 1, verticalLevel] == 0)
            {
                check = true;
            }
            if (check)
            {
                StartCoroutine(moveAnimation(-1.0f, 0.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("d") && horizontalLevel != 4 && pressedAllowed)
        {
            bool check = false;
            if (positionVar[horizontalLevel + 1, verticalLevel] == 0)
            {
                check = true;
            }
            if (check)
            {
                StartCoroutine(moveAnimation(1.0f, 0.0f, 0.0f));
            }
        }
        if (Input.GetKeyDown("space") && pressedAllowed)
        {
            positionVar[horizontalLevel, verticalLevel] = typeVar;
            intCount++;
            moveSprite.name = ("Block" + horizontalLevel + ":" + verticalLevel);
            StartCoroutine(GenerateObject());
        }
        /*
        if(Input.GetKeyDown("p") && pressedAllowed)
        {
            for (int i = 0; i < 5; i++)
            {
                string passString = "";
                for (int j = 0; j < 5; j++)
                {
                    passString += positionVar[j, i].ToString() + ", ";
                }
                Debug.Log(passString);
            }
        }
        */
        if (intCount == 24 && pressedAllowed)
        {
            pressedAllowed = false;
            StartCoroutine(endGame());
        }
        if (Input.GetKeyDown("space") && reload)
        {
            SceneManager.LoadScene("main");
        }
        if(Input.GetKeyDown("x") && pressedAllowed)
        {
           
           for (int b = 0; b < 5; b++)
           {
                int first = positionVar[b, 0];
                int[] checkArray = new int[0];
                for (int c = 0; c < 5; c++)
                {
                    if (positionVar[b, c] == first && first != 0)
                    {
                        checkArray = extendArray(checkArray, (int) positionVar[b, c]);
                    }
                    if (checkArray.Length == 5)
                    {
                        gamePoints++;
                        pointText.text = gamePoints.ToString();
                        GameObject game1 = GameObject.Find("Block" + b + ":" + 0);
                        GameObject game2 = GameObject.Find("Block" + b + ":" + 1);
                        GameObject game3 = GameObject.Find("Block" + b + ":" + 2);
                        GameObject game4 = GameObject.Find("Block" + b + ":" + 3);
                        GameObject game5 = GameObject.Find("Block" + b + ":" + 4);
                        Destroy(game1);
                        Destroy(game2);
                        Destroy(game3);
                        Destroy(game4);
                        Destroy(game5);
                        positionVar[b, 0] = 0;
                        positionVar[b, 1] = 0;
                        positionVar[b, 2] = 0;
                        positionVar[b, 3] = 0;
                        positionVar[b, 4] = 0;
                        intCount -= 5;
                    }
                }
            }
            for (int c = 0; c < 5; c++)
            {
                int first = positionVar[0, c];
                int[] checkArray = new int[0];
                for (int b = 0; b < 5; b++)
                {
                    if (positionVar[b, c] == first && first != 0)
                    {
                        checkArray = extendArray(checkArray, (int)positionVar[b, c]);
                    }
                    if (checkArray.Length == 5)
                    {
                        gamePoints++;
                        pointText.text = gamePoints.ToString();
                        GameObject game1 = GameObject.Find("Block" + 0 + ":" + c);
                        GameObject game2 = GameObject.Find("Block" + 1 + ":" + c);
                        GameObject game3 = GameObject.Find("Block" + 2 + ":" + c);
                        GameObject game4 = GameObject.Find("Block" + 3 + ":" + c);
                        GameObject game5 = GameObject.Find("Block" + 4 + ":" + c);
                        Destroy(game1);
                        Destroy(game2);
                        Destroy(game3);
                        Destroy(game4);
                        Destroy(game5);
                        positionVar[0, c] = 0;
                        positionVar[1, c] = 0;
                        positionVar[2, c] = 0;
                        positionVar[3, c] = 0;
                        positionVar[4, c] = 0;
                        intCount -= 5;
                    }
                }
            }
            if(positionVar[0,0] == positionVar[1,1] && positionVar[0, 0] == positionVar[2, 2] && positionVar[0, 0] == positionVar[3, 3] && positionVar[0, 0] == positionVar[4, 4] && positionVar[0,0] != 0)
            {
                gamePoints++;
                pointText.text = gamePoints.ToString();
                GameObject game1 = GameObject.Find("Block" + 0 + ":" + 0);
                GameObject game2 = GameObject.Find("Block" + 1 + ":" + 1);
                GameObject game3 = GameObject.Find("Block" + 2 + ":" + 2);
                GameObject game4 = GameObject.Find("Block" + 3 + ":" + 3);
                GameObject game5 = GameObject.Find("Block" + 4 + ":" + 4);
                Destroy(game1);
                Destroy(game2);
                Destroy(game3);
                Destroy(game4);
                Destroy(game5);
                positionVar[0, 0] = 0;
                positionVar[1, 1] = 0;
                positionVar[2, 2] = 0;
                positionVar[3, 3] = 0;
                positionVar[4, 4] = 0;
                intCount -= 5;
            }
            if (positionVar[4, 0] == positionVar[1, 3] && positionVar[4, 0] == positionVar[2, 2] && positionVar[4, 0] == positionVar[3, 1] && positionVar[4, 0] == positionVar[0, 4] && positionVar[0, 4] != 0)
            {
                gamePoints++;
                pointText.text = gamePoints.ToString();
                GameObject game1 = GameObject.Find("Block" + 4 + ":" + 0);
                GameObject game2 = GameObject.Find("Block" + 3 + ":" + 1);
                GameObject game3 = GameObject.Find("Block" + 2 + ":" + 2);
                GameObject game4 = GameObject.Find("Block" + 1 + ":" + 3);
                GameObject game5 = GameObject.Find("Block" + 0 + ":" + 4);
                Destroy(game1);
                Destroy(game2);
                Destroy(game3);
                Destroy(game4);
                Destroy(game5);
                positionVar[0, 0] = 0;
                positionVar[1, 1] = 0;
                positionVar[2, 2] = 0;
                positionVar[3, 3] = 0;
                positionVar[4, 4] = 0;
                intCount -= 5;
            }
        }
    }

    IEnumerator endGame()
    {
        for (float a = 0; a < 1.0f; a += .05f)
        {
            yield return new WaitForSeconds(.000625f);
            text.color = new Color(0.0f, 0.0f, 0.0f, a);
        }
        yield return new WaitForSeconds(1.125f);
        text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        for (float a = 0; a < 1.0f; a += .05f)
        {
            yield return new WaitForSeconds(.000625f);
            playText.color = new Color(0.0f, 0.0f, 0.0f, a);
        }
        playText.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        reload = true;   
    }

    IEnumerator moveAnimation(float x, float y, float z)
    {
        int orgX = horizontalLevel - 2;
        int orgY = -1 * verticalLevel + 2;
        pressedAllowed = false;
        horizontalLevel += (int) x;
        verticalLevel += (int) y;
        for (float i = 0.0f; i <= 1.0f + increment; i += increment)
        {
            yield return new WaitForSeconds(.0000001f);
            moveSprite.transform.position = new Vector3(orgX + (i * x), orgY + (i * -y), -1);
        }
        pressedAllowed = true;
    }
}