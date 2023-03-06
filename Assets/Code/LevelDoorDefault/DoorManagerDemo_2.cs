using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerDemo_2 : MonoBehaviour
{
    [SerializeField]
    private Door_Demo2[] doorArr_Demo2;
    //private int count;
    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        //count = 0;
        //doorArr = FindObjectsOfType<Door>();
        flag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1)
        {
            flag = 0;
            doorArr_Demo2[0].pairNUM = 1;
            doorArr_Demo2[1].pairNUM = 2;
            doorArr_Demo2[2].pairNUM = 1;
            doorArr_Demo2[3].pairNUM = 2;
            doorArr_Demo2[4].pairNUM = 3;
            doorArr_Demo2[5].pairNUM = 3;
            doorArr_Demo2[6].pairNUM = 4;
            doorArr_Demo2[7].pairNUM = 4;
            doorArr_Demo2[8].pairNUM = 5;
            doorArr_Demo2[9].pairNUM = 5;
        }
        for (int x = 0; x < doorArr_Demo2.Length; x++)
        {
            for (int y = x + 1; y < doorArr_Demo2.Length; y++)
            {
                if (doorArr_Demo2[x].pairNUM == doorArr_Demo2[y].pairNUM)
                {
                    doorArr_Demo2[x].TransformDoor = doorArr_Demo2[y].GetComponent<Transform>().position;
                    doorArr_Demo2[y].TransformDoor = doorArr_Demo2[x].GetComponent<Transform>().position;
                }
            }
        }

    }
    public void PairManager(int ThisDoorNUM, int TouchDoorNUM)
    {
        //Debug.Log($"{count},{ThisDoorNUM},{TouchDoorNUM}");
        //count++;

        if (doorArr_Demo2[ThisDoorNUM].pairNUM == doorArr_Demo2[TouchDoorNUM].pairNUM)
            return;

        for (int x = 0; x < doorArr_Demo2.Length; x++)
        {
            if (x == ThisDoorNUM) continue;

            if (doorArr_Demo2[x].pairNUM == doorArr_Demo2[ThisDoorNUM].pairNUM)
            {
                doorArr_Demo2[x].pairNUM = doorArr_Demo2[TouchDoorNUM].pairNUM;
            }
        }
        for (int x = 0; x < doorArr_Demo2.Length; x++)
        {
            if (x == TouchDoorNUM) continue;

            if (doorArr_Demo2[x].pairNUM == doorArr_Demo2[TouchDoorNUM].pairNUM)
            {
                doorArr_Demo2[x].pairNUM = doorArr_Demo2[ThisDoorNUM].pairNUM;
            }
        }
        doorArr_Demo2[ThisDoorNUM].pairNUM = doorArr_Demo2[TouchDoorNUM].pairNUM;
    }
}
