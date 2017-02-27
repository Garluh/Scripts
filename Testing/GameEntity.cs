using UnityEngine;
using System.Collections;

public class GameEntity : MonoBehaviour {

    [SerializeField]
    private EntityLevel _entityLevel;

    public EntityLevel EntityLevel
    {
        get{return _entityLevel;}
        set{_entityLevel = value;}
    }

    private void Awake()
    {
        if (EntityLevel == null)
        {
            EntityLevel = GetComponent<EntityLevel>();
            if (EntityLevel == null)
            {
                Debug.LogWarning("No EntityLevel assigned to GameEntity");
            }
        }
    }
}
