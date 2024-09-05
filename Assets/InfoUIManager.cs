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
    GameObject _posTextParent;
    GameObject _targetTextParent;
    GameObject _spriteParent;
    GameObject _nameTextParent;
    IClickForInfo _info;
    private void OnEnable()
    {
        _posTextParent = _thisPosText.transform.parent.gameObject;
        _targetTextParent=_targetText.transform.parent.gameObject;
        _spriteParent=_sprite.transform.parent.gameObject;
        _nameTextParent= _nameText.transform.parent.gameObject;
    }
    public IClickForInfo SetClicObj
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
        TextParent(info.Pos, _thisPosText,_posTextParent, $"現在地 {info.Pos.x} : {info.Pos.y}");
        TextParent(info.TargetPos,_targetText,_targetTextParent,$"目的地　{info.TargetPos.x} : {info.TargetPos.y}");
        SpriteParent(info.Sprite, _sprite, _spriteParent, info.Sprite);        
        TextParent(info.Name, _nameText, _nameTextParent, info.Name);
    }
    void TextParent<TInfo>(TInfo info,Text text, GameObject parent, string str)
    {
        Debug.Log(text);
        if(info != null)
        {
            parent.SetActive(true);
            text.text = str;
        }
        else parent.SetActive(false);
    }
    void SpriteParent<TInfo>(TInfo info, Image sprite, GameObject parent, Sprite infoSprite)
    {
        if (info != null)
        {
            parent.SetActive(true);
            sprite.sprite = infoSprite;
        }
        else parent.SetActive(false);
    }
}
