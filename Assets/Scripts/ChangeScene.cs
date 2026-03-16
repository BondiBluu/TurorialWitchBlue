using UnityEngine.SceneManagement;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    [SerializeField] private SceneChangeSO sceneChange;
    [SerializeField] private Vector2 playerPosition;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneChange.SceneName);
        }
    }
}
