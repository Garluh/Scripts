using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellInfo : MonoBehaviour {
    public GameObject toolTip;


    public Text textData;
    MagicType type;

    private string _name;
    private int _level;
    private float _minDamage;
    private float _maxDamage;

    string color = string.Empty;
    string info = string.Empty;
    string newLine = "\n";


    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public float MinDamage
    {
        get
        {
            return _minDamage;
        }

        set
        {
            _minDamage = value;
        }
    }

    public float MaxDamage
    {
        get
        {
            return _maxDamage;
        }

        set
        {
            _maxDamage = value;
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }

    public MagicType Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public void ActiveTT()
    {
        string data = string.Format("{0}"+newLine+"Уровень заклинания: {1}" + newLine + "Урон: {2}-{3}", Name, Level.ToString(), MinDamage.ToString(),MaxDamage.ToString());
        textData.text = data;
    }

    void Update()
    {
        if (toolTip.activeSelf)
        {
            toolTip.transform.position = Input.mousePosition;
        }
    }
}
