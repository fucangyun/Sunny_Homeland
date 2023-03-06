using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Light : MonoBehaviour
{
    public Sprite LightOn;
    public Sprite LightOff;
    private SpriteRenderer sr;
    public bool IsOn;

    // Start is called before the first frame update
    void Start()
    {
        //LightOn = Resources.Load<Sprite>("pictures/LightOn") as Sprite;
        //LightOff = Resources.Load<Sprite>("pictures/LightOff") as Sprite;
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (IsOn == true)
        {
            sr.sprite = LightOn;
        }
        if (IsOn == false)
        {
            sr.sprite = LightOff;
        }
    }
}
