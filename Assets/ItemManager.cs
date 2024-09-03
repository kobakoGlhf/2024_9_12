using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] int Wood=CountItem.Wood;
    [SerializeField] int Stone=CountItem.Stone;
    [SerializeField] int Money=CountItem.Money;
    private void Update()
    {
        Wood = CountItem.Wood; Stone = CountItem.Stone; Money = CountItem.Money;
    }
}
public static class CountItem
{
    public static int Wood=0;
    public static int Stone=0;
    public static int Money=0;
}

public enum ItemList
{
    Wood,
    Stone,
    Money
}