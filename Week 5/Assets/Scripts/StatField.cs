using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatField : MonoBehaviour
{
    public string statName;

    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI valueLabel;

    public DNDChar.Stats stat;
    public DNDChar character;

    // Start is called before the first frame update
    void Start()
    {
        nameLabel.text = statName;
    }

    public void RollStat()
    {
        int value = DiceRoller.RollD20();
        valueLabel.text = value.ToString();

        character.SetStat(stat, value);
    }

}
