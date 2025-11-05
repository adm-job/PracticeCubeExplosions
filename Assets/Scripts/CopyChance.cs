using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyChance : MonoBehaviour
{
    private float _chance = 1;
    public bool Chance()
    {
        float chance = Random.value;

        if (chance <= _chance)
        {
            _chance /= 2;
            return true;
        }
        else
        {
            return false;
        }
    }
}
