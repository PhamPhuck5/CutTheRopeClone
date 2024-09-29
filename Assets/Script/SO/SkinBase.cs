using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CandySkin", menuName = "ScriptableObject/Candy", order = 2)]
public class SkinBase : ScriptableObject
{
    public Sprite _Image;
    public int _Price;
}
