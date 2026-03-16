using UnityEngine.SceneManagement;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    [SerializeField] private SceneChangeSO sceneChange;
    [SerializeField] private string sceneName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneChange.SceneName);
        }
    }
}
