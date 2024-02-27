using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
}
