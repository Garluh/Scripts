using UnityEngine;
using System.Collections;

public enum EnemyType {Unknown, Animal, Bug, Humanoid, Undead }
public enum EnemyMobRarity { Unknown, Normal, Champion, Legendary, Boss }
public enum EnemyMobAttackType { Unknown, Range, CloseCombat, Mage }

public class EnemyManager : MonoBehaviour {

    public GameObject ExpSphere;
    public GameObject[] potions;
    public GameObject self;
    private Animator anim;
    public AudioClip death_clip;

    [SerializeField]
    private string e_name;
    public string damageDelta;
    public EnemyType type;
    public EnemyMobRarity rarity;
    public EnemyMobAttackType attackType;
    [SerializeField]
    [Range(1, 100)]
    private int e_level;

    private int e_curHealth;
    [SerializeField]
    private int e_maxHealth;
    [SerializeField]
    private int e_maxHealthBase = 100;
    private int e_curMana;
    public int e_maxMana;
    
    [SerializeField]
    private int e_spellPower;
    [SerializeField]
    private int e_damage;
    private float e_SpellDamage;
    [SerializeField]
    private float e_BaseDamage;
    [SerializeField]
    private int e_strenght;
    [SerializeField]
    private int e_intelligence;
    [SerializeField]
    private int e_constitution;
    [SerializeField]
    private int e_expGain;

    [SerializeField]
    private bool isDead = false;

    private int mult_damage;
    private int mult_health;
    private int mult_exp;

    private float e_minDamage;
    private float e_maxDamage;

    private float e_minDamageSpell;
    private float e_maxDamageSpell;

    




    public int health
    {
        get{return e_curHealth;}
        set{ e_curHealth = value;}
    }

    public int maxHealth
    {
        get { return e_maxHealthBase + (e_level + e_constitution)*mult_health ; }
        set { e_maxHealth = value; }
    }

    public int mana
    {
        get{return e_curMana;}
        set{e_curMana = value;}
    }

    public int level
    {get{return e_level; }}

    public EnemyType Type
    {
        get{return type;}
        set{type = value;}
    }

    public EnemyMobRarity Rarity
    {
        get{return rarity;}
        set{rarity = value;}
    }

    public int STR
    {
        get{return e_strenght;}
        set{e_strenght = value;}
    }

    public int INT
    {
        get{return e_intelligence;}
        set{e_intelligence = value;}
    }

    public int CONST
    {
        get{return e_constitution;}
        set{e_constitution = value;}
    }

    public int EXP
    {
        get{return (e_expGain + e_level) * mult_exp ; }
        set{e_expGain = value;}
    }

    public float MinDamage()
    {
        return e_damage + (STR+ level) * mult_damage * 1.2f;
    }

    public float MaxDamage()
    {
        return (MinDamage() * 0.2f) + MinDamage();
    }

    public float MinSpellDamage()
    {
        return e_spellPower + (INT + level) * mult_damage * 2.5f;
    }

    public float MaxSpellDamage()
    {
        return (MinSpellDamage() * 0.6f) + MinSpellDamage();
    }


    public int damage
    {
        //get {return Random.Range(e_damage + (e_strenght+ e_level) * mult_exp, (int)(damage*0.2)) ; }
        get { return Random.Range((int)MinDamage(), (int)MaxDamage()); }
        set { e_BaseDamage = value;}
        
    }

    public float spellDamage
    {
        get { return Random.Range(MinSpellDamage(), MaxSpellDamage()); }
        set { e_SpellDamage = value; }
    }

    public string MobName
    {
        get
        {
            return e_name;
        }
    }

    public EnemyMobAttackType AttackType
    {
        get{return attackType;}
        set{attackType = value;}
    }

    void Awake()
    {

        e_curHealth = maxHealth;
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        switch (rarity)
        {
            case EnemyMobRarity.Unknown:
                mult_damage = 1;
                mult_health = 1;
                mult_exp = 1;
                break;
            case EnemyMobRarity.Normal:
                mult_damage = 1;
                mult_health = 1;
                mult_exp = 1;
                break;
            case EnemyMobRarity.Champion:
                mult_damage = 5;
                mult_health = 5;
                mult_exp = 5;
                break;
            case EnemyMobRarity.Legendary:
                mult_damage = 7;
                mult_health = 7;
                mult_exp = 7;
                break;
            case EnemyMobRarity.Boss:
                mult_damage = 10;
                mult_health = 10;
                mult_exp = 10;
                break;
        }

        e_damage = damage;
        e_SpellDamage = spellDamage;

        switch (attackType)
        {
            case EnemyMobAttackType.Unknown:
                damageDelta = string.Empty;
                break;
            case EnemyMobAttackType.Range:
                damageDelta = string.Empty;
                break;
            case EnemyMobAttackType.CloseCombat:
                damageDelta = ((int)MinDamage()).ToString() + " - " + ((int)MaxDamage()).ToString(); 
                break;
            case EnemyMobAttackType.Mage:
                damageDelta = ((int)MinSpellDamage()).ToString() + " - " + ((int)MaxSpellDamage()).ToString();
                break;

        }


    }
	
	// Update is called once per frame
	void Update () {

        if (e_curHealth <=0)
        {
            isDead = true;
        }

        if (isDead)
        {
            StartCoroutine("ExpDrop");
        }

    }



    IEnumerator ExpDrop()
    {
        GameObject Exp;
        GameObject pots;
        anim.SetBool("Death", true);
        
        
        yield return new WaitForSeconds(3f);
        AudioSource.PlayClipAtPoint(death_clip, transform.position);
        pots = Instantiate(potions[Random.Range(0, potions.Length)], transform.position + new Vector3(Random.Range(1,2), 0.5f, Random.Range(1, 2)), transform.rotation) as GameObject;
        Exp = Instantiate(ExpSphere, transform.position + new Vector3(0,0.5f,0), transform.rotation) as GameObject;
        Exp.GetComponent<ExpDroper>().Exp_drop = EXP;
        StopAllCoroutines();
        Destroy(gameObject);

    }
}
