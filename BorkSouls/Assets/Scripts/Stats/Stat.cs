using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int baseValue;
    private int finalValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x); //add values from every modifier to the final value
        return finalValue; //get the final value
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0) modifiers.Add(modifier); //if a modifier is not 0 add it to the list
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0) modifiers.Remove(modifier); //if the modifier is not 0 remove it from the list
    }
}
