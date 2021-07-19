using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<GameObject> playerObjects = new List<GameObject>();
    public List<Player> players = new List<Player>();
    public bool stop = false;
    public GameObject UI;
    public Text appleC;
    public Text SizeC;
    public int appleCount;
    public int sizeCount;
    public GameObject apple;
    public GameObject CountGroup;
    public bool appleHave;
    public GameObject greenBlock;
    public GameObject moreGreenBlock;
    public GameObject wallBlock;
    public int appleBool;
    public GameObject player;
    public int playerStatus;
    public List<Vector3> headPos = new List<Vector3>();
    public GameObject headSnake;
    public int time;
    public Text last;
    public List<GameObject> walls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Get();
        CreateObject();
        SetPlayerNum();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        AlwayesSet();
        SetPlayer();

        if (stop == true)
        {
            Stop(); 
        }


        if (appleBool == 2)
        {
            CreateWall();
            SizeUp();

            appleBool = 0;
        }
    }

    public void Get()
    {
        for (int i = 0; i < playerObjects.Count; i++)
        {
            players.Add(playerObjects[i].GetComponent<Player>());
        }

    }

    public void Stop()
    {
        UI.gameObject.SetActive(true);
        CountGroup.gameObject.SetActive(false);
    }

    public void SetText()
    {
        appleC.text = appleCount.ToString();
        SizeC.text = sizeCount.ToString();
        last.text = appleCount.ToString();
    }

    public void SetApple()
    {
        GameObject g = Instantiate(apple, new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11)), Quaternion.identity);
    }

    public void AlwayesSet()
    {
        if (appleHave == true)
        {
            return;
        }
        else
        {
            SetApple();
            appleHave = true;
            appleBool += 1;
        }
    }

    public void CreateObject()
    {
        int row = 11;
        int column = 11;

        for (int j = -10; j < row; j++)
        {
            for (int i = -10; i < column; i++)
            {
                if (i % 2 == 0 || j % 2 == 0)
                {
                    GameObject obj = Instantiate(greenBlock, new Vector3(j, 0, i), Quaternion.identity);
                }
                else
                {
                    GameObject obj = Instantiate(moreGreenBlock, new Vector3(j, 0, i), Quaternion.identity);
                }
            }

        }
    }

    public void CreateWall()
    {
            GameObject g = Instantiate(wallBlock, new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11)), Quaternion.identity);
            Debug.Log("puted wall");

    }

    public void SetPlayerNum()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].playerNumber = i;
        }
    }


    public void SetPlayer()
    {
        for (int i = 1; i < players.Count; i++)
        {
                players[i].gameObject.transform.position = players[i - 1].pos1;
        }
    }

    public void SizeUp()
    {
        GameObject g = Instantiate(player, new Vector3(0,0,0), Quaternion.identity);
        playerObjects.Add(g);
        players.Add(g.GetComponent<Player>());
    }

    public void Restart()
    {
        Debug.Log("Pushed");
        stop = false;
        UI.gameObject.SetActive(false);
        CountGroup.gameObject.SetActive(true);
        players[0].gameObject.transform.position = new Vector3(0, 1, 0);
        appleCount = 0;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall1");

        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }

        if (players[2] != null)
        {
            for (int i = 3; i < players.Count; i++)
            {
                Destroy(players[i].gameObject);
                playerObjects.RemoveAt(i);
                players.RemoveAt(i);
            }
        }
    }
}
