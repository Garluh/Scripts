using UnityEngine;
using System.Collections;

public enum RarityType { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY, ARTIFACT }

public class Items : MonoBehaviour {

    private string _name;
    private int _value;
    private RarityType _raity;
    private int _curDur;
    private int _maxDur;

    public Items()
    {
        _name = "Need Name";
        _value = 0;
        _raity = RarityType.COMMON;
        _maxDur = 50;
        _curDur = _maxDur;
    }

    public Items(string name, int value, RarityType rare, int maxDur, int curDur)
    {
        _name = name;
        _value = value;
        _raity = rare;
        _maxDur = maxDur;
        _curDur = curDur;
    }


    public string Name
    {
        get{return _name;}
        set{_name = value;}
    }

    public int Value
    {
        get{return _value;}
        set{_value = value;}
    }

    public RarityType Rarity
    {
        get{return _raity;}
        set{_raity = value;}
    }

    public int MaxDurability
    {
        get{return _maxDur;}
        set{_maxDur = value;}
    }

    public int CurDurability
    {
        get { return _curDur; }
        set { _curDur = value; }
    }
}
