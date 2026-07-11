using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressStart()
    {
        //GameManager.Instance.Score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void OnPressSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SettingsScene");
    }

    public void OnPressCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }

    public void OnPressBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void OnPressQuit()
    {
        Application.Quit();
    }
}
