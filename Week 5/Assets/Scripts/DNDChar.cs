using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DNDChar : MonoBehaviour
{
    public enum Stats
    {
        STR,
        DEX,
        CON,
        INT,
        WIS,
        CHA
    }

    public TMP_InputField nameDisplay;
    private string charName;

    private Dictionary<Stats, int> stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = new();

        foreach(Stats s in System.Enum.GetValues(typeof(Stats)))
        {
            stats[s] = -1;
        }
    }

    public void SetName(string newName)
    {
        charName = newName;
        Debug.Log(string.Format("Set character name to {0}.", charName));
    }

    public string GetName()
    {
        return charName;
    }

    public void SetStat(Stats s, int value)
    {
        stats[s] = value;
        Debug.Log(string.Format("Set {0} to {1}.", s, value));
    }
}
