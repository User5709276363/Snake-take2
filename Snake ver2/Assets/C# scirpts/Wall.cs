using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Manager m;
    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<Manager>();
    }


    // Update is called once per frame
    void Update()
    {
        if(m.stop == true)
        {
            Destroy(this.gameObject);
        }
    }
}
