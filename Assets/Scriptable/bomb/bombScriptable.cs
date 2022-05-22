using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bomb Type")]
public class bombScriptable : ScriptableObject
{
    public float rad;
    public float boomForce;
    public float bombSpeed;
    public float damage;
}
