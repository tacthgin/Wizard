﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType { Helmet, Shoulders, Chest, Gloves, Feet, MainHand, OffHand, TwoHand }

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 2)]
public class Armor : Item
{
    [SerializeField]
    private ArmorType armorType;

    [SerializeField]
    private int intellect = 0;

    [SerializeField]
    private int strength = 0;

    [SerializeField]
    private int stamina = 0;

    public override string GetDescription()
    {
        string stats = string.Empty;

        if (intellect > 0)
        {
            stats += string.Format("\n +{0} intellect", intellect);
        }

        if (strength > 0)
        {
            stats += string.Format("\n +{0} strength", strength);
        }

        if (stamina > 0)
        {
            stats += string.Format("\n +{0} stamina", stamina);
        }

        return base.GetDescription() + stats;
    }
}