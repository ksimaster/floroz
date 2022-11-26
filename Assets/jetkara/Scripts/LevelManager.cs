using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void Load()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
