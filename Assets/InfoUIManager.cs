using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfoUIManager : MonoBehaviour
{
    [SerializeField] Text _thisPosText;
    [SerializeField] Text _targetText;
    [SerializeField] Image _sprite;
    [SerializeField] Text _nameText;
    [SerializeField] GameObject _text;
    [SerializeField] Transform _listAnchorObj;
    [SerializeField] GameObject _emptyPrefab;
    Dictionary<Graphic, GameObject> _parentList=new Dictionary<Graphic, GameObject>();
    IClickForInfo _info;
    private void OnEnable()
    {
        Debug.Log(_thisPosText);
        _parentList.Add(_thisPosText, _thisPosText.transform.parent.gameObject);
        _parentList.Add(_targetText, _targetText.transform.parent.gameObject);
        _parentList.Add(_nameText, _nameText.transform.parent.gameObject);
        _parentList.Add(_sprite, _sprite.transform.parent.gameObject);
        UIReset();
    }

    void UIReset()
    {
        foreach (var i in _parentList.Values)
        {
            i.SetActive(false);
        }
        foreach(Transform child in _listAnchorObj)
        {
            Destroy(child.gameObject);
        }
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
        UIReset();
        if (info == null) return;
        Debug.Log($"{info.Pos} {_thisPosText} {_parentList}");
        ChangeUi(info.Pos, _parentList, _thisPosText, $"現在地 {info.Pos.x} : {info.Pos.y}");
        ChangeUi(info.TargetPos, _parentList, _targetText, $"目的地　{info.TargetPos.x} : {info.TargetPos.y}");
        ChangeUi(info.Sprite, _parentList, _sprite, info.Sprite);
        ChangeUi(info.Name, _parentList, _nameText, info.Name);
        CreateListUI(info.HaveList, _emptyPrefab);
    }
    void CreateListUI(Dictionary<GameObject, SpriteDate> dic,GameObject prefab)
    {
        if(dic == null||prefab==null)return;
        foreach(var erement in dic)
        {
            var gameObj=Instantiate(_emptyPrefab, _listAnchorObj);
            gameObj.transform.GetChild(0).
                gameObject.GetComponent<Image>().sprite=erement.Value.Sprite;
            gameObj.transform.GetChild(1).
                gameObject.GetComponent<Text>().text = erement.Value.Name;
        }
    }
    void ChangeUi<TInfo>(TInfo info, Dictionary<Graphic, GameObject> dic, Graphic kay, string str)
    {
        if (info == null) return;
        dic[kay].SetActive(true);
        Debug.Log(dic[kay].gameObject);
        kay.gameObject.GetComponent<Text>().text = str;
    }
    void ChangeUi<TInfo>(TInfo info, Dictionary<Graphic, GameObject> dic, Graphic kay, Sprite infoSprite)
    {
        if (info == null)return;
            dic[kay].SetActive(true);
            kay.GetComponent<Image>().sprite = infoSprite;
    }
}
