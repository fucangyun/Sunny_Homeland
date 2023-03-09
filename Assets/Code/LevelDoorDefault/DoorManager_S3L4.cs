using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class DoorManager_S3L4 : MonoBehaviour
{
    [SerializeField]
    private Door_S3L4[] doorArr_S3L4;
    //private int count;
    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == 1)
        {
            flag = 0;
            doorArr_S3L4[0].pairNUM = 1;
            doorArr_S3L4[1].pairNUM = 1;
            doorArr_S3L4[2].pairNUM = 2;
            doorArr_S3L4[3].pairNUM = 2;
            doorArr_S3L4[4].pairNUM = 3;
            doorArr_S3L4[5].pairNUM = 3;
            doorArr_S3L4[6].pairNUM = 4;
            doorArr_S3L4[7].pairNUM = 4;
            doorArr_S3L4[8].pairNUM = 5;
            doorArr_S3L4[9].pairNUM = 5;
        }
        for (int x = 0; x < doorArr_S3L4.Length; x++)
        {
            for (int y = x + 1; y < doorArr_S3L4.Length; y++)
            {
                if (doorArr_S3L4[x].pairNUM == doorArr_S3L4[y].pairNUM)
                {
                    doorArr_S3L4[x].TransformDoor = doorArr_S3L4[y].GetComponent<Transform>().position;
                    doorArr_S3L4[y].TransformDoor = doorArr_S3L4[x].GetComponent<Transform>().position;
                }
            }
        }

    }
    public void PairManager(int ThisDoorNUM, int TouchDoorNUM)
    {
        //Debug.Log($"{count},{ThisDoorNUM},{TouchDoorNUM}");
        //count++;

        if (doorArr_S3L4[ThisDoorNUM].pairNUM == doorArr_S3L4[TouchDoorNUM].pairNUM)
            return;

        for (int x = 0; x < doorArr_S3L4.Length; x++)
        {
            if (x == ThisDoorNUM) continue;
           
            if (doorArr_S3L4[x].pairNUM == doorArr_S3L4[ThisDoorNUM].pairNUM)
            {
                doorArr_S3L4[x].pairNUM = doorArr_S3L4[TouchDoorNUM].pairNUM;
            }
        }
        for (int x = 0; x < doorArr_S3L4.Length; x++)
        {
            if (x == TouchDoorNUM) continue;

            if (doorArr_S3L4[x].pairNUM == doorArr_S3L4[TouchDoorNUM].pairNUM)
            {
                doorArr_S3L4[x].pairNUM = doorArr_S3L4[ThisDoorNUM].pairNUM;
            }
        }
        doorArr_S3L4[ThisDoorNUM].pairNUM = doorArr_S3L4[TouchDoorNUM].pairNUM;
    }
}
