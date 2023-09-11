using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string SceneName;
public void loadscene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
