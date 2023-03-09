using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassPoint : MonoBehaviour
{
    private bool ispassed;
    private byte pellucidity = 255;
    private float speed = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        ispassed = false;
    }

    // Update is called once per frame
    void Update()
    {
 
        if (ispassed == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDie = true;
                InvokeRepeating("AA", 0.1f, speed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            ispassed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            ispassed = false;
        }
    }
    private void AA()
    {
        pellucidity -= 1;
        GameObject.FindObjectOfType<Character>().GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, pellucidity);
        if (pellucidity == 0)
        {
            GameObject.Find("LevelSelectManager").SendMessage("UnlockedLevelManager");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
