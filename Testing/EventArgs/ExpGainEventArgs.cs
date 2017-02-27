using UnityEngine;
using System;
using System.Collections;

public class ExpGainEventArgs : EventArgs {
    public int ExpGained { get; private set; }

    public ExpGainEventArgs(int expGained)
    {
        ExpGained = expGained;
    }
}
