using UnityEngine;
using System;
using System.Collections;

public abstract class EntityLevel : MonoBehaviour {

    //----LEVEL
    [Header("Level Varibale")]
    [SerializeField]
    private int _level = 0;
    [SerializeField]
    private int _leveleMin = 0;
    [SerializeField]
    private int _levelMax = 100;
    private int _expCurrent = 0;
    private int _expRequired = 0;

    public event EventHandler<ExpGainEventArgs> OnEntityExpGain;
    public event EventHandler<LevelChangeArgs> OnEntityLevelChange;
    public event EventHandler<LevelChangeArgs> OnEntityLevelUp;
    public event EventHandler<LevelChangeArgs> OnEntityLevelDown;

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int LevelMin
    {
        get { return _leveleMin; }
        set { _leveleMin = value; }
    }

    public int LevelMax
    {
        get { return _levelMax; }
        set { _levelMax = value; }
    }

    public int ExpCurrent
    {
        get { return _expCurrent; }
        set { _expCurrent = value; }
    }

    public int ExpRequire
    {
        get { return _expRequired; }
        set { _expRequired = value; }
    }

    public abstract int GetExpRequiredForLevel(int level);

    public void Awake()
    {
        ExpRequire = GetExpRequiredForLevel(Level);
    }

    public void ModifyExp(int amount)
    {
        ExpCurrent += amount;

        if (OnEntityExpGain != null)
        {
            OnEntityExpGain(this, new ExpGainEventArgs(amount));
        }

        CheckCurrentExp();
    }

    public void SetCurrentExp(int value)
    {
        int expGained = value - ExpCurrent;
        ExpCurrent = value;

        if (OnEntityExpGain != null)
        {
            OnEntityExpGain(this, new ExpGainEventArgs(expGained));
        }

        CheckCurrentExp();
    }

    public void CheckCurrentExp()
    {
        int oldLevel = Level;
        InteralCheckCurrentExp();
        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeArgs(Level, oldLevel));
        }
    }

    private void InteralCheckCurrentExp()
    {
        while (true)
        {
            if (ExpCurrent > ExpRequire)
            {
                ExpCurrent -= ExpRequire;
                InteralIncreaseCurrentLevel();
            }
            else if (ExpCurrent < 0)
            {
                ExpCurrent += GetExpRequiredForLevel(Level - 1);
                InteralIncreaseCurrentLevel();
            }
            else
            {
                break;
            }
        }
    }


    public void IncreaseCurrentLevel()
    {
        int oldLevel = Level;
        InteralIncreaseCurrentLevel();
        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeArgs(Level, oldLevel));
        }
    }

    private void InteralIncreaseCurrentLevel()
    {
        int oldLevel = Level++;

        if (Level > LevelMax)
        {
            Level = LevelMax;
            ExpCurrent = GetExpRequiredForLevel(Level);
        }

        ExpRequire = GetExpRequiredForLevel(Level);
        if (oldLevel != Level && OnEntityLevelUp != null)
        {
            OnEntityLevelUp(this, new LevelChangeArgs(Level, oldLevel));
        }
    }

    public void DecreaseCurrentLevel()
    {
        int oldLevel = Level;
        InteralDecreaseCurrentLevel();
        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeArgs(Level, oldLevel));
        }
    }

    private void InteralDecreaseCurrentLevel()
    {
        int oldLevel = Level--;
        if (Level > LevelMin)
        {
            Level = LevelMin;
            ExpCurrent = 0;
        }
        ExpRequire = GetExpRequiredForLevel(Level);
        if (oldLevel != Level && OnEntityLevelDown != null)
        {
            OnEntityLevelDown(this, new LevelChangeArgs(Level, oldLevel));
        }
    }

    private void SetLevel(int targetLevel)
    {
        SetLevel(targetLevel, true);
    }

    private void SetLevel(int targetLevel, bool clearExp)
    {
        int oldLevel = Level;
        Level = targetLevel;
        ExpRequire = GetExpRequiredForLevel(Level);
        if (clearExp)
        {
            SetCurrentExp(0);
        }
        else
        {
            InteralCheckCurrentExp();
        }

        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeArgs(Level, oldLevel));
        }
    }

}
