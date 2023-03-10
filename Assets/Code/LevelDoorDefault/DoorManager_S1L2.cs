using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager_S1L2 : MonoBehaviour
{
    [SerializeField]
    private Door_S1L2[] doorArr_Demo1;
    //private int count;
    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        //count = 0;
        //doorArr_Demo1 = FindObjectsOfType<Door>();
        flag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1)
        {
            flag = 0;
            doorArr_Demo1[0].pairNUM = 1;
            doorArr_Demo1[1].pairNUM = 1;
            doorArr_Demo1[2].pairNUM = 2;
            doorArr_Demo1[3].pairNUM = 2;
            //doorArr_Demo1[4].pairNUM = 3;
            //doorArr_Demo1[5].pairNUM = 3;
            //doorArr_Demo1[6].pairNUM = 4;
            //doorArr_Demo1[7].pairNUM = 4;
        }
        for (int x = 0; x < doorArr_Demo1.Length; x++)
        {
            for (int y = x + 1; y < doorArr_Demo1.Length; y++)
            {
                if (doorArr_Demo1[x].pairNUM == doorArr_Demo1[y].pairNUM)
                {
                    doorArr_Demo1[x].TransformDoor = doorArr_Demo1[y].GetComponent<Transform>().position;
                    doorArr_Demo1[y].TransformDoor = doorArr_Demo1[x].GetComponent<Transform>().position;
                }
            }
        }

    }
    public void PairManager(int ThisDoorNUM, int TouchDoorNUM)
    {
        //Debug.Log($"{count},{ThisDoorNUM},{TouchDoorNUM}");
        //count++;

        if (doorArr_Demo1[ThisDoorNUM].pairNUM == doorArr_Demo1[TouchDoorNUM].pairNUM)
            return;

        for (int x = 0; x < doorArr_Demo1.Length; x++)
        {
            if (x == ThisDoorNUM) continue;

            if (doorArr_Demo1[x].pairNUM == doorArr_Demo1[ThisDoorNUM].pairNUM)
            {
                doorArr_Demo1[x].pairNUM = doorArr_Demo1[TouchDoorNUM].pairNUM;
            }
        }
        for (int x = 0; x < doorArr_Demo1.Length; x++)
        {
            if (x == TouchDoorNUM) continue;

            if (doorArr_Demo1[x].pairNUM == doorArr_Demo1[TouchDoorNUM].pairNUM)
            {
                doorArr_Demo1[x].pairNUM = doorArr_Demo1[ThisDoorNUM].pairNUM;
            }
        }
        doorArr_Demo1[ThisDoorNUM].pairNUM = doorArr_Demo1[TouchDoorNUM].pairNUM;
    }
}
