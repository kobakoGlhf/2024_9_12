using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUIManager : MonoBehaviour
{
    [SerializeField] Text _thisPosText;
    [SerializeField] Text _targetText;
    [SerializeField] Image _sprite;
    [SerializeField] Text _nameText;
    IClickForInfo _info;
    IClickForInfo SetClicObj
    {
        set
        {
            if(value != null)
            {
                _info = value;
                TextChange(value);
            }
        }
    }
    void TextChange(IClickForInfo info)
    {
        _thisPosText.text = $"現在地 {info.Pos.x} : {info.Pos.y}";
        _targetText.text = $"目的地　{info.TargetPos.x} : {info.TargetPos.y}";
        _sprite.sprite = info.Sprite;
        _nameText.text = info.name;
    }
}
