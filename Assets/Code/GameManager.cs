using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MyBag;
    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        MyBag.SetActive(true);
        MyBag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenMyBag();
    }

    void OpenMyBag()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            MyBag.SetActive(isOpen);
        }
    }
}
