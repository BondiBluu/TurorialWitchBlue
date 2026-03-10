using UnityEngine;

[System.Serializable]
public struct DialogueLines
{
    public string speaker;
    [TextArea(2,5)]
    public string dialogueText;
    public Sprite characterSprite1;
    public Sprite characterSprite2;
}

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public DialogueLines[] dialogueLines;
}
