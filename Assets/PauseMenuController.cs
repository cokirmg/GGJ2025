using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject optionsMenu;

    private GameObject activeUIScreen;

    public enum ActivePanels
    {
        PauseMenu = 0,
        OptionsMenu,
        ControlesMenu
    }


    private void Start()
    {
        activeUIScreen = pauseMenu;
        activeUIScreen.SetActive(false);    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleActiveMenu();
        }

        if (activeUIScreen.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void ChangeActiveUI(int index)
    {
        ActivePanels newActivePanel = (ActivePanels)index;

        switch (newActivePanel)
        {
            case ActivePanels.PauseMenu:
                activeUIScreen = pauseMenu;
                break;
            case ActivePanels.OptionsMenu:
                activeUIScreen = optionsMenu;
                break;
            case ActivePanels.ControlesMenu:
                activeUIScreen = controlsMenu;
                break;
            default:
                break;
        }
    }

    public void ToggleActiveMenu()
    {
        activeUIScreen.SetActive(!activeUIScreen.activeInHierarchy);

        activeUIScreen = pauseMenu;
    }

    public void GoToMainMenu()
    {

    }

    public void ExitGame()
    {

    }
}
