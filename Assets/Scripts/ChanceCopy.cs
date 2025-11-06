using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceCopy : MonoBehaviour
{
    private float _chance = 1f;
    float chance;
    
    public bool Chance()
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
