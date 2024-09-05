using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager:MonoBehaviour
{
    public static ItemManager Instance;
    [SerializeField] Text _woodText;
    [SerializeField] Text _stoneText;
    [SerializeField] Text _moneyText;
    static int _wood;
    static int _stone;
    static int _money;
    private void Awake()
    {
        Instance = this;
        Debug.Log(Instance.name);
        Wood++;
    }
    public int Wood
    {
        get=>_wood;
        set
        {
            if(_wood!=value)
            {
                _wood = value;
                Debug.Log(_woodText);
                _woodText.text = value.ToString();
            }
        }
    }
    public int Stone
    {
        get=>_stone;
        set=>ItemUiChange(ref _stone, value,_stoneText);
    }
    public int Money
    {
        get=> _money;
        set=>ItemUiChange(ref _money, value,_moneyText);
    }
    void ItemUiChange(ref int setInt,int value,Text changeText)
    {
        if (setInt != value)
        {
            setInt= value;
            Debug.Log($"text{changeText.name} int {setInt}");
            changeText.text= value.ToString();
        }
    }
}

public enum ItemList
{
    Wood,
    Stone,
    Money
}