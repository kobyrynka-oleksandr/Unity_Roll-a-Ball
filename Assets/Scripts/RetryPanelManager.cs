using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject retryPanelObject;
    [SerializeField] private TextMeshProUGUI scoreObject;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
    }

    public void OnToMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        gameManager.RestartGame();
    }

    public void GetScore(string score)
    {
        scoreObject.text = $"{score}";
    }

    public void RemovePanel()
    {
        retryPanelObject.SetActive(false);
    }

    public void ShowPanel()
    {
        retryPanelObject.SetActive(true);
    }
}
