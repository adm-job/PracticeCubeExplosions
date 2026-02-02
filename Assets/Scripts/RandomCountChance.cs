using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCountChance : MonoBehaviour
{
    private float _chance = 1f;
    private float chance;
    private float divider = 2f;

    //public RandomCountChance()
    //{
    //    CreateChance();
    //}

    public bool CreateChance()
    {
        chance = Random.value;
        if (chance <= _chance)
        {
            _chance /= divider;
            return true;
        }
        else
        {
            return false;
        }
    }
}
