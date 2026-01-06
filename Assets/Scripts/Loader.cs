using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Level") == 0){
            PlayerPrefs.SetInt("Level", 1);
        }
        SceneManager.LoadScene("Level_"+ PlayerPrefs.GetInt("Level").ToString());
    }

}

