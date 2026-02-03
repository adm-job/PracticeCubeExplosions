using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCountChance : MonoBehaviour
{
    private float _chance = 1f;
    private float chance;

    public bool CreateChance(float chanse)
    {
        _chance = chanse;
        chance = Random.value;
        if (chance <= _chance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
