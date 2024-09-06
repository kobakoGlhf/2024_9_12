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
    [SerializeField] GameObject _text;
    GameObject _posTextParent;
    GameObject _targetTextParent;
    GameObject _spriteParent;
    GameObject _nameTextParent;
    Dictionary<Graphic, GameObject> _parent;
    IClickForInfo _info;
    private void OnEnable()
    {
        _parent.Add(_thisPosText, _thisPosText.transform.parent.gameObject);
        _parent.Add(_targetText, _targetText.transform.parent.gameObject);
        _parent.Add(_nameText, _nameText.transform.parent.gameObject) ;
        _parent.Add(_sprite, _sprite.transform.parent.gameObject);
        _posTextParent = _thisPosText.transform.parent.gameObject;
        _targetTextParent=_targetText.transform.parent.gameObject;
        _spriteParent=_sprite.transform.parent.gameObject;
        _nameTextParent= _nameText.transform.parent.gameObject;
    }

    void PanelActive(bool active)
    {
        _posTextParent.SetActive(false);
        _targetTextParent.SetActive(false);
        _spriteParent.SetActive(false);
        _nameTextParent.SetActive(false);
    }
    public IClickForInfo SetClicObj
    {
        set
        {
                _info = value;
                TextChange(value);
        }
    }
    void TextChange(IClickForInfo info)
    {
        PanelActive(false);
        if(info==null) return;
        TextParent(info.Pos, _parent, _thisPosText, $"現在地 {info.Pos.x} : {info.Pos.y}");
        TextParent(info.TargetPos, _parent, _targetText, $"目的地　{info.TargetPos.x} : {info.TargetPos.y}");
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
    }
    void TextParent<TInfo>(TInfo info, Dictionary<Graphic,GameObject> dic,Graphic kay, string str)
    {
        Debug.Log(dic[kay]);
        if (info != null)
        {
            Text text;
            dic[kay].gameObject.GetComponent<Text>().text = str;
        }
    }
    void SpriteParent<TInfo>(TInfo info, Image sprite, GameObject parent, Sprite infoSprite)
    {
        if (info != null)
        {
            parent.SetActive(true);
            sprite.sprite = infoSprite;
        }
    }
}
