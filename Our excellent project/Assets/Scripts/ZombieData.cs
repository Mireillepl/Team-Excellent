using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "ZombieData")]
public class ZombieData : ScriptableObject
{
    public float speed = 5.0f;
    public float rotSpeed = 30.0f;

    public float attackRange = 2.0f;
    public float lockRange = 4.0f;

    public float coolingDownTime = 3.0f;
    public float attackWindupTime = 2.0f;
}
