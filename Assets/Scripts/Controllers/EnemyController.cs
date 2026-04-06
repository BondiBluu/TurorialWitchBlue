using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private FighterSO enemyData;
    private bool battleStarted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //using the bool to make sure the ontriggerenter2d doesn't ever trigger twice
        if (collision.CompareTag("Player") && battleStarted == false)
        {
            battleStarted = true;
            EncounterManager.instance.guaranteedEnemy = enemyData;
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
