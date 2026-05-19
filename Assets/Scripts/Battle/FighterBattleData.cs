using UnityEngine;

//attached to every fighter
public class FighterBattleData : MonoBehaviour
{
    [SerializeField] FighterSO fighterData;

    //sets the fighter's stats
    public void SetupData(FighterSO battleData)
    {
        fighterData = battleData;
    }
}
