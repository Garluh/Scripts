using UnityEngine;
using System.Collections;

public enum MagicType {
    Fire,
    Water,
    Lightning,
    Black,
    Body,
    Force
}

public class SpellDatabase : MonoBehaviour {
    [Header("Magic Settings")]
    public int ID;
    public string itemName;
    public MagicType type;
    public string description;

    [SerializeField]
    private float delayToCast;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float minDamage;
    [SerializeField]
    private float maxDamage;
    [SerializeField]
    private float healing;
    [SerializeField]
    private float manaConsumption;
    public int spellLevel;

    
    [Header("Visual Settings")]
    public Sprite icon;
    public GameObject prefab;

    private BaseCharacter bc;


    // Use this for initialization
    void Awake () {
        bc = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BaseCharacter>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public float MinDamage
    //{
    //    get { return minDamage = damage * spellLevel + bc.spellPower; }
        
    //}

    //public float MaxDamage
    //{
    //    get { return maxDamage = (MinDamage * 1.2f) + MinDamage; }
    //}

    public float Damage
    {
        get { return Random.Range(MinDamage,MaxDamage); }
        set { damage = value; }
        
    }

    public float Healing
    {
        get { return healing * spellLevel + bc.spellPower/2; }
        set { healing = value; }
    }

    public float ManaConsumption
    {
        get { return manaConsumption * 1.5f * spellLevel; }
        set { manaConsumption = value; }
    }

    public float DelayToCast
    {
        get { return delayToCast; }
        set { delayToCast = value; }
    }

    public int SpellLevel
    {
        get{return spellLevel;}
        set{spellLevel = value;}
    }

    public float MinDamage
    {
        get
        {
            return minDamage;
        }

        set
        {
            minDamage = value;
        }
    }

    public float MaxDamage
    {
        get
        {
            return maxDamage;
        }

        set
        {
            maxDamage = value;
        }
    }
}
