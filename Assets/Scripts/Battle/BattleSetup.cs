using System.Collections.Generic;
using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    public List<FighterSO> familiarList;

    [Header(" Stations")]
    [SerializeField] Transform[] playerStations;

    [SerializeField] Transform[] enemyStations;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    /*create a random number of enemies
    first enemy's fighter data will always be the guaranteed attribute player ran into
    all enemy fighter data will be random*/
    public void CreateNumberOfEnemies(List<FighterSO> enemyList, FighterSO guaranteedEnemy)
    {
        int numberOfEnemies = Random.Range(1, 4);
        Debug.Log("Number of enemies: " + numberOfEnemies);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            FighterSO data = i == 0 ? guaranteedEnemy : enemyList[Random.Range(0, enemyList.Count)];

            InstantiateAndSetUp(enemyPrefab, enemyStations[i], data);
        }
    }

    public void InstantiatePlayerAndAlly(FighterSO fighter)
    {
        switch (fighter.Alignment)
        {
            case CharacterAlliance.Player:
                InstantiateAndSetUp(playerPrefab, playerStations[0], fighter);
                break;
            case CharacterAlliance.Familiar:
                CreateFamiliar();
                break;
        }
        Debug.Log("Instantiating friendly fighters");
    }

    //instantiate and set up fighter data for familiars for each familiar made
    //TODO: see if any player station is full. If not, make that  where the next familiar goes
    public void CreateFamiliar()
    {
        foreach (Transform station in playerStations)
        {
            if (station != null && station.childCount == 0)
            {
                InstantiateAndSetUp(playerPrefab, station, familiarList[Random.Range(0, familiarList.Count)]);
                break;
            }
        }
    }

    //instantiates prefabs to their position and TODO sets up their stats
    private void InstantiateAndSetUp(GameObject fighter, Transform fighterPosition, FighterSO data)
    {
        Debug.Log("Instantiating");
        GameObject go = Instantiate(fighter, fighterPosition.position, Quaternion.identity, fighterPosition);
        go.GetComponent<FighterBattleData>().SetupData(data);
    }

}
