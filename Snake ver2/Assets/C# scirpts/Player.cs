using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber = 1;

    public float speed;

    public Manager m;

    public int playerMode = 1; //1:front  2:right  3:back  4:left

    public Vector3 pos1; //before 0.1 pos

    public Vector3 test;


    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<Manager>();
        speed = 0.2f;
        InvokeRepeating("Call01", 0.1f, 0.1f);
        if (playerNumber == 0)
        {
            InvokeRepeating("Move", 0.05f, 0.05f);
        }
    }


    void Move()//0.1s 1run
    {
        if(m.stop == true)
        {
            return;
        }
        else
        {
           transform.Translate(0, 0, speed);
        }
    }

    void Call01()
    {
        test = this.gameObject.transform.position;
        Invoke("GetPos", 1f);
    }

    void GetPos()
    {
        pos1 = test;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Wkey();
        }

        if (Input.GetKeyDown("s"))
        {
            Skey();
        }

        if (Input.GetKeyDown("a"))
        {
            Akey();
        }

        if (Input.GetKeyDown("d"))
        {
            Dkey();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Destroy(other.gameObject);
            m.appleCount += 1;
            m.appleHave = false;
        }
        if (other.gameObject.tag == "Player")
        {

        }
        if (other.gameObject.tag == "Wall")
        {
            m.stop = true;
        }
        if (other.gameObject.tag == "Wall1")
        {
            m.stop = true;
            Debug.Log("wall1");
        }
        else
        {
            return;
        }
    }

    public void NumWillGood()
    {
        Vector3 obj = this.gameObject.transform.position;
        
        obj.x = Mathf.Round(obj.x);
        obj.z = Mathf.Round(obj.z);
        float x = obj.x;
        float y = obj.y;
        float z = obj.z;
        this.gameObject.transform.position = new Vector3(x, y, z);
    }

    void Wkey()
    {
        transform.eulerAngles = (new Vector3(0, 0, 0));
        NumWillGood();
        playerMode = 1;
    }

    void Skey()
    {
        transform.eulerAngles = (new Vector3(0, -180, 0));
        NumWillGood();
        playerMode = 3;
    }

    void Dkey()
    {
        transform.eulerAngles = (new Vector3(0, 90, 0));
        NumWillGood();
        playerMode = 2;
    }

    void Akey()
    {
        transform.eulerAngles = (new Vector3(0, -90, 0));
        NumWillGood();
        playerMode = 4;
    }

    
}
