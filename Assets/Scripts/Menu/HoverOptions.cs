using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoverOptions : MonoBehaviour {

    public Canvas resolutionPopup;
    public Canvas qualityPopup;
    public Canvas antiAliasPopup;
    public Canvas vSyncPopup;
    public Canvas musicPopup;

    public Button resolutionBox;
    public Button qualityBox;
    public Button aaBox;
    public Button vSyncBox;
    public Button musicBox;
    public float time = 2f;

    public float timeSet;

    void Start() {
        resolutionPopup = resolutionPopup.GetComponent<Canvas>();
        qualityPopup = qualityPopup.GetComponent<Canvas>();
        antiAliasPopup = antiAliasPopup.GetComponent<Canvas>();
        vSyncPopup = vSyncPopup.GetComponent<Canvas>();
        musicPopup = musicPopup.GetComponent<Canvas>();
        resolutionBox = resolutionBox.GetComponent<Button>();
        qualityBox = qualityBox.GetComponent<Button>();
        aaBox = aaBox.GetComponent<Button>();
        vSyncBox = vSyncBox.GetComponent<Button>();
        musicBox = musicBox.GetComponent<Button>();

        resolutionPopup.enabled = false;
        qualityPopup.enabled = false;
        antiAliasPopup.enabled = false;
        vSyncPopup.enabled = false;
        musicPopup.enabled = false;

        timeSet = time;
    }

    void Update()
    {
        if (resolutionPopup.enabled || qualityPopup.enabled || antiAliasPopup.enabled || vSyncPopup.enabled || musicPopup.enabled) {
            timeSet -= 0.0025f;

            if (timeSet <= 0)
            {
                CloseSplash();
            }
        }
    }

    public void OpenResolutionHelp()
    {
        resolutionPopup.enabled = true;
        qualityPopup.enabled = false;
        antiAliasPopup.enabled = false;
        vSyncPopup.enabled = false;
        musicPopup.enabled = false;
        timeSet = time;
    }

    public void OpenQualityHelp()
    {
        resolutionPopup.enabled = false;
        qualityPopup.enabled = true;
        antiAliasPopup.enabled = false;
        vSyncPopup.enabled = false;
        musicPopup.enabled = false;
        timeSet = time;
    }

    public void OpenAntiAliasHelp()
    {
        resolutionPopup.enabled = false;
        qualityPopup.enabled = false;
        antiAliasPopup.enabled = true;
        vSyncPopup.enabled = false;
        musicPopup.enabled = false;
        timeSet = time;
    }

    public void OpenVSyncHelp()
    {
        resolutionPopup.enabled = false;
        qualityPopup.enabled = false;
        antiAliasPopup.enabled = false;
        vSyncPopup.enabled = true;
        musicPopup.enabled = false;
        timeSet = time;
    }

    public void OpenMusicHelp()
    {
        resolutionPopup.enabled = false;
        qualityPopup.enabled = false;
        antiAliasPopup.enabled = false;
        vSyncPopup.enabled = false;
        musicPopup.enabled = true;
        timeSet = time;
    }

    void CloseSplash()
    {
        resolutionPopup.enabled = false;
        qualityPopup.enabled = false;
        antiAliasPopup.enabled = false;
        vSyncPopup.enabled = false;
        musicPopup.enabled = false;
        timeSet = time;
    }
}
