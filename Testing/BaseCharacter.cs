using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BaseCharacter : MonoBehaviour
{

    public Image hpBar_v;
    public Image mpBar_v;
    public Image hpBar_h;
    public Image mpBar_h;
    public Text HP_Potion_counter;
    public Text MP_Potion_counter;

    private int maxHPPotion = 10;
    private int maxMPPotion = 10;
    private int curHPPotion = 1;
    private int curMPPotion = 1;


    private float c_curHealt;
    public float c_maxHealth;

    private float c_curMana;
    public float c_maxMana;

    private float c_ManaRegainRate = 1;
    [SerializeField]
    private float manaRegainMulti = 10;

    private float c_spellPower = 3;
    public float c_damage = 3;
    public float c_strenght;
    public float c_dexterity;
    public float c_intelligence;
    public float c_constitution;
    public float c_defence;

    //public int curExp;
    //public int maxExp;
    public int _level = 1;
    //public float timeToShowLevelUp = 3f;
    //public float timeTillNotShowLevelUp = 0f;
    //public bool levelUp;


    public int c_skillPoint;
    public int c_statsPoint;

    void Awake()
    {
        c_strenght = 1;
        c_dexterity = 1;
        c_intelligence = 1;
        c_constitution = 1;
        c_maxHealth = 100;

        c_maxMana = 100;
        c_curMana = maxMana;
        c_statsPoint = 5;
        c_skillPoint = 0;
        //curExp = 0;
        c_curHealt = 100;
        c_curHealt = maxHealth;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHUDVital();
        //if (curExp >= maxExp)
        //{
        //    LevelUp();
        //}
        //if (levelUp)
        //{
        //    if (Time.time > timeTillNotShowLevelUp)
        //    {
        //        levelUp = false;
        //    }
        //}

        if (health <= 0)
        {
            health = 0;
        }


        

    }

    


    public float DEF
    {
        get { return (int)(c_defence + CONST * 0.5 + DEX * 0.6) + (int)(_level*0.4); }
        set { c_defence = value; }
    }

    /// <summary>
    /// Получаем опыт или ставим.
    /// </summary>
    /// <value>кол-во опытв.</value>
    //public int gainExp
    //{
    //    get { return curExp; }
    //    set { curExp = value; }

    //}

    /// <summary>
    /// Получаем или ставим текущие здоровье.
    /// </summary>
    /// <value>кол-во здоровья.</value>
    public float health
    {
        get { return c_curHealt; }
        set { c_curHealt = value; }
    }

    /// <summary>
    /// Gets or sets the максимального здоровья.
    /// </summary>
    /// <value>The max health.</value>
    public float maxHealth
    {
        get { return c_maxHealth + _level + CONST * 12; }
        set { c_maxHealth = value; }
    }

    public float mana
    {
        get { return c_curMana; }
        set { c_curMana = value; }
    }

    public float maxMana
    {
        get { return c_maxMana + _level + INT * 4; }
        set { c_maxMana = value; }
    }

    /// <summary>
    /// Gets or sets the порказатель силы.
    /// </summary>
    /// <value>The ST.</value>
    public float STR
    {
        get { return c_strenght; }
        set { c_strenght = value; }
    }

    /// <summary>
    /// Gets or sets показатель ловкости.
    /// </summary>
    /// <value>The DE.</value>
    public float DEX
    {
        get { return c_dexterity; }
        set { c_dexterity = value; }
    }

    /// <summary>
    /// Gets or sets показатель интеллекта.
    /// </summary>
    /// <value>The IN.</value>
    public float INT
    {
        get { return c_intelligence; }
        set { c_intelligence = value; }
    }

    /// <summary>
    /// Gets or sets показатель выносливости.
    /// </summary>
    /// <value>The CONS.</value>
    public float CONST
    {
        get { return c_constitution; }
        set { c_constitution = value; }
    }

    /// <summary>
    /// Gets or sets силы заклинаний.
    /// </summary>
    /// <value>The spell power.</value>
    public float spellPower
    {
        get { return c_spellPower + INT * 3; }
        set { c_spellPower = value; }
    }

    /// <summary>
    /// Gets or sets мелишного урона.
    /// </summary>
    /// <value>The damage.</value>
    public float damage
    {
        get { return c_damage + STR * 3; }
        set { c_damage = value; }
    }


    /// <summary>
    /// Gets or sets очков навыков.
    /// </summary>
    /// <value>The skill point.</value>
    public int skillPoint
    {
        get { return c_skillPoint; }
        set { c_skillPoint = value; }
    }

    /// <summary>
    /// Gets or sets очков статистики.
    /// </summary>
    /// <value>The stats point.</value>
    public int statsPoint
    {
        get { return c_statsPoint; }
        set { c_statsPoint = value; }
    }

    public float ManaRegainRate
    {
        get{return c_ManaRegainRate * _level + c_intelligence;}
        set{c_ManaRegainRate = value;}
    }



    /// <summary>
    /// Лечение.
    /// </summary>
    /// <param name="adj">Adj.</param>
    public void AdjHP(int adj)
    {
        health += adj;
    }

    /// <summary>
    /// Уваличение маны(банки с маной к примеру)
    /// </summary>
    /// <param name="adj"></param>
    public void AdjMP(float adj)
    {
        mana += (int)adj;
    }

    public void DamageTake(int damage)
    {
        health -= damage - DEF;
    }

    /// <summary>
    /// Уваличение регена маны
    /// </summary>
    /// <param name="adj"></param>
    public void AdjManaRgain(int adj)
    {
        manaRegainMulti += adj;
    }

    /// <summary>
    /// Увеличение урона.
    /// </summary>
    /// <param name="adj">Adj.</param>
    public void AdgDamage(int adj)
    {
        damage += adj;
    }

    public void AdjSpellPower(int adj)
    {
        spellPower += adj;
    }

    public void AdjSTRStatsPoint(int point)
    {
        STR += point;
        statsPoint -= point;
    }

    public void AdjDEXStatsPoint(int point)
    {
        DEX += point;
        statsPoint -= point;
    }

    public void AdjINTStatsPoint(int point)
    {
        INT += point;
        statsPoint -= point;
    }
    public void AdjCONSTStatsPoint(int point)
    {
        CONST += point;
        statsPoint -= point;
    }

    public void AdjHPPotion(int adj)
    {
        curHPPotion += adj;
    }

    public void AdjMPPotion(int adj)
    {
        curMPPotion += adj;
    }

    //public void LevelUp()
    //{
    //    curExp = 0;
    //    maxExp = maxExp + 100;
    //    skillPoint += 5;
    //    statsPoint += 10;
    //    level++;
    //    levelUp = true;
    //    timeTillNotShowLevelUp = Time.time + timeToShowLevelUp;

    //}

    void UpdateHUDVital()
    {

        hpBar_v.fillAmount = (float)c_curHealt/(float)c_maxHealth;
        hpBar_h.fillAmount = (float)c_curHealt / (float)c_maxHealth;
        mpBar_v.fillAmount = (float)c_curMana / (float)c_maxMana;
        mpBar_h.fillAmount = (float)c_curMana / (float)c_maxMana;

        mana += (Time.deltaTime / c_ManaRegainRate * manaRegainMulti);

        HP_Potion_counter.text = curHPPotion.ToString();
        MP_Potion_counter.text = curMPPotion.ToString();

    }



}
