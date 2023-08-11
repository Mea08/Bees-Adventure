using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelManager : MonoBehaviour
{
    public GameObject endPanel;

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            endPanel.SetActive(true);
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


