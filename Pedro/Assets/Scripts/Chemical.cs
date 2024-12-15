using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chemical", menuName = "ScriptableObjects/ChemicalObject", order = 1)]
public class Chemical : ScriptableObject
{
    //Which 2 chemicals you need to mix in order to make the object
    public string leftChem;
    public string rightChem;

    public float stink;
}
