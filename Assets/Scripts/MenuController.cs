using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject settingsObject;
    [SerializeField] private GameObject chooseLevelPanelObject;

    private void Start()
    {
    }

    public void OnPlayButton()
    {
        menuObject.SetActive(false);
        chooseLevelPanelObject.SetActive(true);
    }

    public void OnSettingsButton()
    {
        menuObject.SetActive(false);
        settingsObject.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnToMenuButton()
    {
        menuObject.SetActive(true);
        chooseLevelPanelObject.SetActive(false);
    }

    public void OnToMenuSettingsButton()
    {
        menuObject.SetActive(true);
        settingsObject.SetActive(false);
    }

    public void OnLevel1Button()
    {
        SceneManager.LoadScene("Level1Scene");
    }
    public void OnLevel2Button()
    {
        SceneManager.LoadScene("Level2Scene");
    }
}
