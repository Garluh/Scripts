using UnityEngine;
using System.Collections;
using System;

public class DefaultLevel : EntityLevel
{
    public override int GetExpRequiredForLevel(int level)
    {
        return (int)(Mathf.Pow(Level, 2f) * 100) + 100;
    }
}
