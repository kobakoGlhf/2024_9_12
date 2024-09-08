using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CharacterControlle : MonoBehaviour, IClickForInfo
{
    Action _interact;
    [SerializeField] GameObject _child;
    [SerializeField] float _interactSpees;
    [SerializeField] float _speed;
    [SerializeField] int _maxBackPackListCount;
    Vector2 _movePos;
    GameObject _home;
    FarmObject _farmObject;
    GameObject _interactObj;
    //家から操作する部分
    public CharacterMoveState MoveState;
    public List<ItemList> BackPack;
    //この下のものはテスト様だったり改善の余地がありそうなもの
    [SerializeField] Transform _testTransform;
    [SerializeField] bool test;
    [SerializeField] GameObject _testHome;
    float _timer = 0f;
    public GameObject Home { get => _home; private set => _home = value; }
    public Action Interact { get => _interact; set => _interact = value; }
    public GameObject SetInteractObj { get => _interactObj; set => _interactObj = value; }
    public Vector2 MovePos
    {
        get => _movePos;
        set
        {
            if (_movePos != value)
            {
                //_child?.SetActive(false);
            }
            _movePos = value;
            if (_movePos == (Vector2)_home.transform.position)
            {
                MoveState = CharacterMoveState.GoHorm;
            }
            else
            {
                MoveState = CharacterMoveState.GoFarm;
            }
        }
    }
    public FarmObject SetFarmObject
    {
        get { return _farmObject; }
        set
        {
            _farmObject = value;
        }
    }
    //インターフェイス関連
    public string Name { get => gameObject.name; }
    public Sprite Sprite { get => gameObject.GetComponent<Sprite>(); }
    public Vector2 Pos { get => transform.position; }
    public Vector2 TargetPos { get => _movePos; }
    public Dictionary<GameObject, SpriteDate> HaveList
    {
        get
        {
            return BackPack.ToDictionary(backPack => gameObject, 
                backPack => new SpriteDate(ItemManager.Items[backPack], backPack.ToString()));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (test)
        {
            MovePos = _testTransform.position;
            _home = _testHome;
        }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, MovePos)) < _interactSpees)
        {
            if (_farmObject != null && BackPack.Count <= _maxBackPackListCount)
            {
                Farm();
            }
            else
            {
                //_child.SetActive(true);
                if (_home != null)
                {
                    MovePos = _home.transform.position;
                }
            }
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        //移動処理
        var distance = (MovePos - (Vector2)transform.position).normalized;
        transform.localPosition += (Vector3)distance * _speed * Time.deltaTime;
    }
    private void Farm()
    {
        _timer += Time.deltaTime;
        if (_timer > _farmObject.FarmSpeed)
        {
            _farmObject.ItemCount--;
            BackPack.Add(_farmObject._item);
            _timer = 0f;
        }
    }
    public void SetHome(GameObject obj)
    {
        Home = obj;
    }
}
public enum CharacterMoveState
{
    GoFarm,
    GoHorm
}
