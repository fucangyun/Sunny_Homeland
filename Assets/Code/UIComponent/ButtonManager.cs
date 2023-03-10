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
    public GameObject ExitButton;
    public GameObject ContinueButton1;
    public GameObject ContinueButton2;
    public GameObject ContinueButton3;
    public GameObject TutorialPage1;
    public GameObject TutorialPage2;
    public GameObject TutorialPage3;
    
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
    public void ButtonLevel7()
    {
        SceneManager.LoadScene(7);
    }
    public void ButtonLevel8()
    {
        SceneManager.LoadScene(8);
    }
    public void ButtonLevel9()
    {
        SceneManager.LoadScene(9);
    }

    public void ButtonLevel10()
    {
        SceneManager.LoadScene(10);
    }
    public void ButtonLevel11()
    {
        SceneManager.LoadScene(11);
    }
    public void ButtonLevel12()
    {
        SceneManager.LoadScene(12);
    }
    public void ButtonLevel13()
    {
        SceneManager.LoadScene(13);
    }
    public void ButtonLevel14()
    {
        SceneManager.LoadScene(14);
    }
    public void ButtonLevel15()
    {
        SceneManager.LoadScene(15);
    }
    public void ButtonLevel16()
    {
        SceneManager.LoadScene(16);
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
        ExitButton.SetActive(false);
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
        ExitButton.SetActive(true);
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

    public void BottonExit()
    {
        PlayerPrefs.SetInt("InventoryCount", 0);
        PlayerPrefs.SetInt("unlockedLevelIndex", 0);
        Application.Quit();
    }

    public void BottonContinue1()
    {
        ContinueButton1.SetActive(false);
        ContinueButton2.SetActive(true);
        TutorialPage1.SetActive(false);
        TutorialPage2.SetActive(true);
    }

    public void BottonContinue2()
    {
        ContinueButton2.SetActive(false);
        ContinueButton3.SetActive(true);
        TutorialPage2.SetActive(false);
        TutorialPage3.SetActive(true);
    }
    public void BottonContinue3()
    {
        ContinueButton3.SetActive(false);
        TutorialPage3.SetActive(false);
    }
}

