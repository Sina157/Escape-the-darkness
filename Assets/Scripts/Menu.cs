using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button template_btn;
    public Transform parentTransform;


    public void btn_click(string level)
    {
        SceneManager.LoadScene(level);
    }

void Start()
{
    int sceneCount = SceneManager.sceneCountInBuildSettings;
    int unlockedLevel = PlayerPrefs.GetInt("Level");

    for (int i = 0; i < sceneCount; i++)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        if (sceneName.StartsWith("Level_"))
        {
            string levelNumberStr = sceneName.Replace("Level_", "");
            int levelNumber;

            if (int.TryParse(levelNumberStr, out levelNumber))
            {
                if (levelNumber <= unlockedLevel)
                {
                    var newButton = Instantiate(template_btn, parentTransform);
                    newButton.transform.localScale = Vector3.one * 7;

                    int sceneIndex = i; // مهم، جلو باگ کلیک رو می‌گیره
                    newButton.onClick.AddListener(() =>
                        SceneManager.LoadScene(sceneIndex)
                    );

                    newButton.transform.GetChild(0)
                        .GetComponent<Text>().text = sceneName;
                }
            }
        }
    }

    Destroy(template_btn.gameObject);
}

    void Update()
    {
        
    }
}
