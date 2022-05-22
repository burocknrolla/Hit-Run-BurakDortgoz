using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="bullet type")]
public class bulletScriptable : ScriptableObject
{

    public float bulletSpeed;
    public float damage;
    public float pushForce;
    public Material mat;


}
