using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    

    public void ChangeScene(string _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
