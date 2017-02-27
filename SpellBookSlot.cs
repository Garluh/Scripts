using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SpellBookSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
//public class SpellBookSlot : MonoBehaviour {
    public int id;
    public float _damage;
    public float _minDamage;
    public float _maxDamage;
    public string _name;
    public string _description;
    public int _level;
    public MagicType type;
    GameObject tooltip;
    SpellInfo sp;

    private SpellBook spellBook;
    void Start()
    {
        spellBook = GetComponent<SpellBook>();
        tooltip = GameObject.Find("Tooltip");
        sp = tooltip.GetComponent<SpellInfo>();
        //tooltip.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.SetActive(true);
        CostructToolTipInfo();
        //Debug.Log(_name);
        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
        //throw new NotImplementedException();
    }

    public int ID
    {
        get{return id;}
        set{id = value;}
    }

    public float Damage
    {
        get{return _damage;}
        set{ _damage = value;}
    }

    public float MinDamage
    {
        get { return _minDamage; }
        set { _minDamage = value; }
    }

    public float MaxDamage
    {
        get { return _maxDamage; }
        set { _maxDamage = value; }
    }

    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }

    public string Description
    {
        get{return _description;}
        set{_description = value;}
    }

    public int Level
    {
        get{return _level;}
        set{_level = value;}
    }

    public MagicType Type
    {
        get{return type;}
        set{type = value;}
    }

    void CostructToolTipInfo()
    {
        sp.ActiveTT();
        sp.Name = _name;
        sp.Level = _level;
        sp.MinDamage = _minDamage;
        sp.MaxDamage = _maxDamage;
    }


}
