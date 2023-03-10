using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public int CurrentLevelIndex;
    public GameObject LevelSelectPanel;
    Button[] LevelSelectButtons;
    int UnlockedLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetInt("unlockedLevelIndex", 0);
        }*/
    }
    public void UnlockedLevelManager()
    {
        if (CurrentLevelIndex > UnlockedLevelIndex)
        {
            UnlockedLevelIndex= CurrentLevelIndex;
            PlayerPrefs.SetInt("unlockedLevelIndex", UnlockedLevelIndex);
        }
    }
    public void LevelSelect()
    {
        if (PlayerPrefs.GetInt("InventoryCount") == 14)
        {
            PlayerPrefs.SetInt("unlockedLevelIndex", 16);
        }
        UnlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevelIndex");
        LevelSelectButtons = new Button[LevelSelectPanel.transform.childCount];
        for (int i = 0; i < LevelSelectPanel.transform.childCount; i++)
        {
            LevelSelectButtons[i] = LevelSelectPanel.transform.GetChild(i).GetComponent<Button>();
        }

        for (int i = 0; i < LevelSelectButtons.Length; i++)
        {
            LevelSelectButtons[i].interactable = false;
        }

        for (int i = 0; i < UnlockedLevelIndex + 1; i++)
        {
            LevelSelectButtons[i].interactable = true;
        }
    }
}
