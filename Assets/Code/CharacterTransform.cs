using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class CharacterTransform : MonoBehaviour
{
    public GameObject SelfCharacter;
    public GameObject OtherCharacter;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            flag = false;
            OtherCharacter.transform.position = SelfCharacter.transform.position;
            SelfCharacter.SetActive(false);
            OtherCharacter.gameObject.SetActive(true);
        }
        if (GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDie == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OtherCharacter.transform.position = SelfCharacter.transform.position;
                SelfCharacter.SetActive(false);
                OtherCharacter.gameObject.SetActive(true);
            }
        }
    }
}
