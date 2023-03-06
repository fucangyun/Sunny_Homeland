using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassPoint : MonoBehaviour
{
    private bool ispassed;

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
                GameObject.Find("LevelSelectManager").SendMessage("UnlockedLevelManager");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
