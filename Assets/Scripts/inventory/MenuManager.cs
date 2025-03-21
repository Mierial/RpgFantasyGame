using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    public GameObject resolutionPanel;

    private void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); 
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitResolution()
    {
        settingsPanel.SetActive(true);
        resolutionPanel.SetActive(false);
    }
    public void ShowResolution()
    {
        resolutionPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    public void HidePanel()
    {
        mainMenuPanel.SetActive(false);
    }
}
