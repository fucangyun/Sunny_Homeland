using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject DieMenu;
    public GameObject MenuPage;
    public GameObject MenuButton;
    public GameObject LevelButtons;
    public GameObject LevelSelectButton;
    public GameObject BackToMenuButton;
    public GameObject RestartButton;
    public GameObject ResumeButton;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BottonBackToManu()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonLevel1 ()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void ButtonLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void ButtonLevel5()
    {
        SceneManager.LoadScene(5);
    }
    public void ButtonLevel6()
    {
        SceneManager.LoadScene(6);
    }
    public void ButtonNextLevel()
    {
        GameObject.Find("LevelSelectManager").SendMessage("UnlockedLevelManager");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ButtonSelectLevel() 
    {
        LevelButtons.SetActive(true);
        LevelSelectButton.SetActive(false);
        ResumeButton.SetActive(false);
        BackToMenuButton.SetActive(false);
        RestartButton.SetActive(false);
        GameObject.Find("LevelSelectManager").SendMessage("LevelSelect");
    }
    public void ButtonSelectLevel_Menu()
    {
        LevelButtons.SetActive(true);
        LevelSelectButton.SetActive(false);
        GameObject.Find("LevelSelectManager").SendMessage("LevelSelect");
    }
    public void ButtonRestart()
    {
        GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDie = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ButtonBack()
    {
        BackToMenuButton.SetActive(true);
        LevelSelectButton.SetActive(true);
        ResumeButton.SetActive(true);
        RestartButton.SetActive(true);
        LevelButtons.SetActive(false);
    }
    public void ButtonMenu()
    {
        MenuPage.SetActive(true);
        MenuButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ButtonResume()
    {
        MenuPage.SetActive(false);
        MenuButton.SetActive(true);
        Time.timeScale = 1;
    }
}

