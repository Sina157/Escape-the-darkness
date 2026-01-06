using UnityEngine;

public class autoRun : MonoBehaviour
{


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnGameStart()
    {
        Debug.Log("This runs in every scene load");
    }
}
