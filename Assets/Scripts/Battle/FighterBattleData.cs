using UnityEngine;

public class FighterBattleData : MonoBehaviour
{
    [SerializeField] FighterSO fighterData;

    public void SetupData(FighterSO battleData)
    {
        fighterData = battleData;
    }
}
