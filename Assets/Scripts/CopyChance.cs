using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyChance : MonoBehaviour
{
    private float _chance = 1;
    public bool Chance()
    {
        if (Random.value < _chance)
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
