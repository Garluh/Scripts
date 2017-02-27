using UnityEngine;
using System;
using System.Collections;

public class LevelChangeArgs : EventArgs {

    public int NewLevel { get; private set; }
    public int OldLevel { get; private set; }

    public LevelChangeArgs(int newLevel, int oldLevel)
    {
        NewLevel = newLevel;
        OldLevel = oldLevel;
    }

}
