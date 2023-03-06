using System.Collections;
using System.Collections.Generic;
//using UnityEditor.EditorTools;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject ControllingLight;
    public GameObject DarkImage;
    public SpriteRenderer sr;
    private bool isNearSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearSwitch == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ControllingLight.GetComponent<Light>().IsOn == true)
                {
                    ControllingLight.GetComponent<Light>().IsOn = false;
                    DarkImage.SetActive(true);
                    sr.flipY = false;
                }
                else
                {
                    ControllingLight.GetComponent<Light>().IsOn = true;
                    DarkImage.SetActive(false);
                    sr.flipY = true;
                }
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(1);
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            isNearSwitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            isNearSwitch = false;
        }
    }
}
