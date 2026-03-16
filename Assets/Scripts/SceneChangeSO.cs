using UnityEngine;

[CreateAssetMenu(fileName = "SceneChangeSO", menuName = "Scriptable Objects/SceneChange")]
public class SceneChangeSO : ScriptableObject
{
    [SerializeField] private string sceneName;
    [SerializeField] private Vector2 playerPosition;

    public string SceneName{get;}
    public Vector2 PlayerPosition{get;}
    
}
