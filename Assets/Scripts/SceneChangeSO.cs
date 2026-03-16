using UnityEngine;

[CreateAssetMenu(fileName = "SceneChangeSO", menuName = "Scriptable Objects/SceneChange")]
public class SceneChangeSO : ScriptableObject
{
    [SerializeField] private string sceneName;
    public string SceneName { get { return sceneName; } }    
}
