using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private string gameObjectTag;

    public virtual string GetGameObjectTag()
    {
        return gameObjectTag;
    }

    public virtual void SetGameObjectTag(string _tag)
    {
        gameObjectTag = _tag;
    }
}
