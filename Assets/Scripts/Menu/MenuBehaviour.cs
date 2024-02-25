using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {

    public int delay = 2;

    public Canvas menu;
    public Canvas quitMenu;
    public Canvas helpSplash;
    public Canvas reset;
    public Canvas mapSelector;
    public Canvas optionsMenu;
    public Canvas controlCanvas;

    public Button startText;
    public Button optionText;
    public Button resetText;
    public Button helpText;
    public Button exitText;
    public Button secretMenu;
    
    public bool enter = false;

    void Awake()
    {
        Application.targetFrameRate = 300;
    }

    void Start() {

        menu = menu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        helpSplash = helpSplash.GetComponent<Canvas>();
        reset = reset.GetComponent<Canvas>();
        mapSelector = mapSelector.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        controlCanvas = controlCanvas.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        optionText = optionText.GetComponent<Button>();
        resetText = resetText.GetComponent<Button>();
        helpText = helpText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        secretMenu = secretMenu.GetComponent<Button>();

        reset.enabled = false;
        controlCanvas.enabled = false;
        helpSplash.enabled = false;
        quitMenu.enabled = false;
        mapSelector.enabled = false;
        optionsMenu.enabled = false;
    }

    public void MapSelector() {
        quitMenu.enabled = false;
        helpSplash.enabled = false;
        startText.enabled = false;
        resetText.enabled = false;
        optionText.enabled = false;
        helpText.enabled = false;
        exitText.enabled = false;
        mapSelector.enabled = true;
        optionsMenu.enabled = false;
    }

    public void OptionsMenu() {
        quitMenu.enabled = false;
        helpSplash.enabled = false;
        startText.enabled = false;
        resetText.enabled = false;
        optionText.enabled = false;
        helpText.enabled = false;
        exitText.enabled = false;
        mapSelector.enabled = false;
        optionsMenu.enabled = true;
    }

    public void ExitPress() {
        quitMenu.enabled = true;
        helpSplash.enabled = false;
        startText.enabled = false;
        resetText.enabled = false;
        optionText.enabled = false;
        helpText.enabled = false;
        exitText.enabled = false;
        mapSelector.enabled = false;
        optionsMenu.enabled = false;
    }

    public void SplashClose() {
        quitMenu.enabled = false;
        helpSplash.enabled = false;
        startText.enabled = true;
        resetText.enabled = true;
        optionText.enabled = true;
        helpText.enabled = true;
        exitText.enabled = true;
        mapSelector.enabled = false;
        optionsMenu.enabled = false;
    }

    public void HelpSplash() {
        quitMenu.enabled = false;
        helpSplash.enabled = true;
        startText.enabled = false;
        resetText.enabled = false;
        optionText.enabled = false;
        helpText.enabled = false;
        exitText.enabled = false;
        mapSelector.enabled = false;
        optionsMenu.enabled = false;
    }

    public void StartLevel01()
    {
        StartCoroutine(StartLevels("Map01"));
    }

    public void StartLevel02()
    {
        StartCoroutine(StartLevels("Map02"));
    }

    public void StartLevel03()
    {
        StartCoroutine(StartLevels("Map03"));
    }

    public void StartLevel04()
    {
        StartCoroutine(StartLevels("Map04"));
    }

    IEnumerator StartLevels(string text)
    {
        controlCanvas.enabled = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("_Scenes/" + text);
    }

    public void secretPress()
    {
        reset.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
