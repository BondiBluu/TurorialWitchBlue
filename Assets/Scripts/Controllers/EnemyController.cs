using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public List<FighterSO> enemyList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("FightStage");
        }
    }

    //when the scene is loaded, make the player disappear, don't let the player move (TODO)  
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.gameObject.SetActive(false);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
