using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public GameObject stop_menu;

    public void Menu_Btn_Click()
    {
        Time.timeScale = 0;
        stop_menu.SetActive(true);
    }

    public void Resume_Btn_Click()
    {
        Time.timeScale = 1;
        stop_menu.SetActive(false);
    }
    public void Restart_Btn_Click()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit_To_Menu_Btn_Click()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Exit_Btn_Click()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
