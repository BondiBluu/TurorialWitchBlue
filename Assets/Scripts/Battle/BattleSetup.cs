using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//sets up all data from UI to where fighters should stand at the beginning of the match

public class BattleSetup : MonoBehaviour
{
    CharacterStatusManager characterStatusManager;
    public List<FighterSO> familiarList;
    [SerializeField] FighterSO guaranteedEnemy;


    [Header(" Stations")]
    [SerializeField] Transform[] playerStations;
    [SerializeField] Transform[] enemyStations;
    [SerializeField] Transform enemyContainer;
    [SerializeField] Transform playerMPContainer;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    [SerializeField] GameObject uIPrefab;
    [SerializeField] GameObject diamondPrefab;
    [SerializeField] GameObject emptyDiamondPrefab;

    [Header("To be deleted when testing is over")]
    public List<FighterSO> enemyList;
    public FighterSO playerStats;

    void Awake()
    {
        characterStatusManager = FindAnyObjectByType<CharacterStatusManager>();
    }

    public void SetUpAll()
    {
        CreateNumberOfEnemies(enemyList, guaranteedEnemy);
        InstantiatePlayerAndAlly(playerStats);
        SetUpCharacterStats();
    }


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
                //TODO: change random range to the actual familiar that's supposed to be there
                InstantiateAndSetUp(playerPrefab, station, familiarList[Random.Range(0, familiarList.Count)]);
                break;
            }
        }
    }

    public void SetUpCharacterStats()
    {
        characterStatusManager.BattleStartStats(playerStats);
    }

    //instantiates prefabs to their position 
    // If the object being instantiated is a fighter (has the FighterBattleData script), sets up their stats.  
    private void InstantiateAndSetUp(GameObject prefab, Transform position, FighterSO data)
    {
        Debug.Log("Instantiating");
        GameObject go = Instantiate(prefab, position.position, Quaternion.identity, position);

        if (go.TryGetComponent(out FighterBattleData fightersData))
        {
            fightersData.SetupData(data);
            Debug.Log("This is a fighter");
        }
        else
        {
            //TODO: Instantiate UIs

        }
    }

    private void InstantiateUI(FighterSO fighterData, GameObject uiContainer)
    {
    }
}
