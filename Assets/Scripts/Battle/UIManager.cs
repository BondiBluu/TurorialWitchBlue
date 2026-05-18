using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject uIContainerPrefab;
    [SerializeField] Transform enemyContainer;
    [SerializeField] GameObject diamondPrefab;
    [SerializeField] GameObject emptyDiamondPrefab;
    [SerializeField] Transform playerMPContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void CreateUIStations(GameObject prefab, Transform container)
    {
        Instantiate(prefab, container);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
