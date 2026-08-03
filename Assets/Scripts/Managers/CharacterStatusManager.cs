using TMPro;
using UnityEngine;

//displays the character's stats in the battle scene
public class CharacterStatusManager : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text lvlText;
    [SerializeField] TMP_Text hPText;
    [SerializeField] TMP_Text mPText;
    [SerializeField] TMP_Text atkText;
    [SerializeField] TMP_Text defText;
    [SerializeField] TMP_Text spdText;

    //sets the initial stats of the character at the start of the battle
    public void BattleStartStats(FighterSO fighterData)
    {
        nameText.text = fighterData.CharacterName;
        lvlText.text = $"Level {fighterData.Level}";
        hPText.text = $"HP: {fighterData.HP}/{fighterData.HP}";
        mPText.text = $"MP: {fighterData.MP}/{fighterData.MP}";
        atkText.text = $"Attack: {fighterData.Attack} (+ 0)";
        defText.text = $"Defense: {fighterData.Defense} (+ 0)";
        spdText.text = $"Speed: {fighterData.Speed} (+ 0)";

    }
}
