using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesData : MonoBehaviour
{
    public enum ClothesType
    {
        Classic_Classic=1000,
        Classic_UV=1001,
        Classic_Thunder=1002,
        Classic_Rainbow=1003
    }
    public ClothesType clothesType = ClothesType.Classic_Classic;
}
