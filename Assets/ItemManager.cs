using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    [SerializeField] Text _woodText;
    [SerializeField] Text _stoneText;
    [SerializeField] Text _moneyText;
    [SerializeField] Text _foodText;
    [SerializeField] Sprite _woodSprite;
    [SerializeField] Sprite _stoneSprite;
    [SerializeField] Sprite _moneySprite;
    [SerializeField] Sprite _foodSprite;
    public static Dictionary<ItemList, Sprite> Items=new Dictionary<ItemList, Sprite>();
    static int _woodCount;
    static int _stoneCount;
    static int _moneyCount;
    private void Awake()
    {
        Items = new Dictionary<ItemList, Sprite>() {
            { ItemList.Wood, _woodSprite },
            {ItemList.Stone,_stoneSprite },
            {ItemList.Money, _moneySprite },
            {ItemList.Food, _foodSprite }
        };
        Instance = this;
        GetType().GetMembers();
    }
    public int Wood { get => _woodCount; set => ItemUiChange(ref _woodCount, value, _woodText); }
    public int Stone { get => _stoneCount; set => ItemUiChange(ref _stoneCount, value, _stoneText); }
    public int Money { get => _moneyCount; set => ItemUiChange(ref _moneyCount, value, _moneyText); }
    void ItemUiChange(ref int setInt, int value, Text changeText)
    {
        if (setInt == value) return;
        setInt = value;
        changeText.text = value.ToString("0000");
    }
}

public enum ItemList
{
    Wood,
    Stone,
    Money,
    Food
}