using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

//TODO:
//1.two Coordinate system problems
public class RoomOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 TempPos;
    //[SerializeField]
    //private Door[] doorArray;

    void Start()
    {
        //doorArray = FindObjectsOfType<Door>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Time.timeScale = 0;
        //Debug.Log(doorArray.Length);
        //for (int i = 0; i < doorArray.Length; i++)
        //{
        //    doorArray[i].gameObject.GetComponent<Collider2D>().enabled = false;
        //}

        //GetComponent<RoomOnDrag>().gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
        //if (GetComponent<RoomOnDrag>().GetComponentInChildren<Character>() != null)
        //    GetComponent<RoomOnDrag>().GetComponentInChildren<Character>().GetComponent<Rigidbody2D>().gravityScale = 0;
        TempPos = transform.position;
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //GroundManager.DisableGroundCollider();
        //WallManager.DisableWallCollider();
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //GetComponent<RoomOnDrag>().GetComponentInChildren<BoxCollider2D>().enabled = true;
        //if (GetComponent<RoomOnDrag>().GetComponentInChildren<Character>() != null)
        //    GetComponent<RoomOnDrag>().GetComponentInChildren<Character>().GetComponent<Rigidbody2D>().gravityScale = 50;

        //GroundManager.AbleGroundCollider();
        //WallManager.AbleWallCollider();

        //for (int i = 0; i < doorArray.Length; i++)
        //{
        //    doorArray[i].gameObject.GetComponent<Collider2D>().enabled = true;
        //}
        Time.timeScale = 1;

        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<RoomOnDrag>())
        {
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            eventData.pointerCurrentRaycast.gameObject.transform.position = TempPos;
        }
        else
        {
            transform.position = TempPos;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() || collision.gameObject.GetComponent<FSM_Enemy>() != null)
            collision.gameObject.transform.SetParent(transform);
    }
}
