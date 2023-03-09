using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager_S2L3 : MonoBehaviour
{
    [SerializeField]
    private Door_S2L3[] doorArr;
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
            doorArr[0].pairNUM = 1;
            doorArr[1].pairNUM = 1;
            doorArr[2].pairNUM = 2;
            doorArr[3].pairNUM = 2;
            doorArr[4].pairNUM = 3;
            doorArr[5].pairNUM = 3;
            doorArr[6].pairNUM = 4;
            doorArr[7].pairNUM = 4;
        }
        for (int x = 0; x < doorArr.Length; x++)
        {
            for (int y = x + 1; y < doorArr.Length; y++)
            {
                if (doorArr[x].pairNUM == doorArr[y].pairNUM)
                {
                    doorArr[x].TransformDoor = doorArr[y].GetComponent<Transform>().position;
                    doorArr[y].TransformDoor = doorArr[x].GetComponent<Transform>().position;
                }
            }
        }

    }
    public void PairManager(int ThisDoorNUM, int TouchDoorNUM)
    {
        //Debug.Log($"{count},{ThisDoorNUM},{TouchDoorNUM}");
        //count++;

        if (doorArr[ThisDoorNUM].pairNUM == doorArr[TouchDoorNUM].pairNUM)
            return;

        for (int x = 0; x < doorArr.Length; x++)
        {
            if (x == ThisDoorNUM) continue;

            if (doorArr[x].pairNUM == doorArr[ThisDoorNUM].pairNUM)
            {
                doorArr[x].pairNUM = doorArr[TouchDoorNUM].pairNUM;
            }
        }
        for (int x = 0; x < doorArr.Length; x++)
        {
            if (x == TouchDoorNUM) continue;

            if (doorArr[x].pairNUM == doorArr[TouchDoorNUM].pairNUM)
            {
                doorArr[x].pairNUM = doorArr[ThisDoorNUM].pairNUM;
            }
        }
        doorArr[ThisDoorNUM].pairNUM = doorArr[TouchDoorNUM].pairNUM;
    }
}
