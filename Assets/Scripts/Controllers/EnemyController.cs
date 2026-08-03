using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls the enemy's behavior when the player collides with it, and sets up the battle scene with the correct data
public class EnemyController : MonoBehaviour
{
    [SerializeField] private FighterSO enemyData;
    private bool battleStarted = false;

    //when the player collides with the enemy, set up the battle scene, load player and enemy data into the encounter manager, and load the battle scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //using the bool to make sure the ontriggerenter2d doesn't ever trigger twice
        if (collision.CompareTag("Player") && battleStarted == false)
        {
            battleStarted = true;
            EncounterManager.instance.guaranteedEnemy = enemyData;
            EncounterManager.instance.playerData = PlayerController.instance.fighterInstance;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("FightStage");
        }
    }

    //when the scene is loaded, make the player disappear. TODO: don't let the player move
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.gameObject.SetActive(false);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
