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
            //firing this once the scene is loaded
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneChange.SceneName);
        }
    }

    //when the scene is loaded, move the player's position to the playerPosition
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerPosition;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
