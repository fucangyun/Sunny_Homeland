using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    private bool isDoor;//player can only transport when isDoor is true
    private Transform PlayerTransform;
    public Vector2 TransformDoor;//target door
    public Vector2 TransformPosition;
    [SerializeField]
    public int pairNUM;
    [SerializeField]
    public int doorNUM;
    public int TouchDoorNUM;
    [SerializeField]
    private float transformOffset;
    SpriteRenderer Sr;
    // Start is called before the first frame update
    private DoorManagerDemo_1 doorManager;

    void Start()
    {
        doorManager = FindObjectOfType<DoorManagerDemo_1>();
        
        if (doorManager == null) return;

        //if(doorNUM == 2)   Debug.Log(pairNUM);
        Sr= GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.P))
        {
            if (doorNUM == 2) Debug.Log(pairNUM);
        }


        if (pairNUM == 1)
        {
            Sr.color = new Color32(255, 0, 255, 255);
        }
        if (pairNUM == 2)
        {
            Sr.color = new Color32(255, 255, 0, 255);
        }
        if (pairNUM == 3)
        {
            Sr.color = new Color32(0, 0, 255, 255);
        }
        if (pairNUM == 4)
        {
            Sr.color = new Color32(255, 255, 255, 255);
        }
        if (pairNUM == 5)
        {
            Sr.color = new Color32(0, 255, 255, 255);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerTransform = FindObjectOfType<Character>().GetComponent<Transform>();
            if (isDoor == true)
            {
                TransformPosition =new Vector2(TransformDoor.x, TransformDoor.y - transformOffset);
                PlayerTransform.position = TransformPosition;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(1);
        if(collision.gameObject.GetComponent<Character>() != null)
        {
            isDoor = true;
        }
        if(collision.gameObject.GetComponent<Door>() != null)
        {
            
            TouchDoorNUM = collision.GetComponent<Door>().doorNUM;
            doorManager.PairManager(doorNUM, TouchDoorNUM);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            
            isDoor = false;
        }
    }
}
