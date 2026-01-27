using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCountChance : MonoBehaviour
{
    private float _chance = 1f;
    float chance;
    
    public bool CreateChance()
    {
        chance = Random.value;
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
