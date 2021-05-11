using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelsController : MonoBehaviour
{
    public GameObject levelButton;
    private int lastOpenLevel;
    private int levelCount;
    private List<GameObject> buttons;
    void Start()
    {
        lastOpenLevel = LevelData.Instance.levelInfo.lastOpenLevel;
        levelCount = MainMenuManager.levelCount;
        buttons = new List<GameObject>();
        for (int i=1; i<=levelCount; i++){
            GameObject newlevel = Instantiate(levelButton, new Vector3(0, 0, 0), Quaternion.identity);
            newlevel.transform.SetParent(gameObject.transform, false);
            newlevel.GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Level.Text")+" " + i;
            if (i>lastOpenLevel) newlevel.GetComponent<Button>().interactable = false;
            buttons.Add(newlevel);
        }
    }

}
