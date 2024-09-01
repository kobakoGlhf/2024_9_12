using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CharacterControlle : MonoBehaviour,ITarget
{
    Action _interact;
    [SerializeField] GameObject _child;
    [SerializeField] float _interactSpees;
    [SerializeField] float _speed;
    [SerializeField] int _maxBackPackListCount;
    GameObject _home;
    Vector2 _movePos;
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
    public Action Interact {
        get { return _interact; }
        set { _interact = value;} 
    }
    public GameObject SetInteractObj
    {
        get { return _interactObj; }
        set { _interactObj = value; }
    }
    public Vector2 GoalPos
    {
        get
        {
            return _movePos;
        }
        set
        {
            if (_movePos != value)
            {
                _child?.SetActive(false);
            }
            _movePos = value;
            if (_movePos == (Vector2)_home.transform.position)
            {
                MoveState = CharacterMoveState.GoHorm;
            }
            else
            {
                MoveState= CharacterMoveState.GoFarm;
            }
        }
    }
    public FarmObject SetFarmObject
    {
        get { return _farmObject; }
        set
        {
            Debug.Log("setFarmObject");
            _farmObject = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (test)
        {
            GoalPos = _testTransform.position;
            _home = _testHome;
        }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, GoalPos)) < _interactSpees)
        {
            if (_farmObject != null&& BackPack.Count <= _maxBackPackListCount)
            {
                Farm();
            }
            else
            {
                //_child.SetActive(true);
                if (_home != null)
                {
                    GoalPos = _home.transform.position;
                }
                Debug.Log("操作終了");
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
        var distance = (GoalPos - (Vector2)transform.position).normalized;
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
    void Stand()
    {

    }
    void SetHomePos(GameObject home)
    {
        _home = home;
    }
    public void SetHome(GameObject home)
    {
        _home = home;
    }
}
public enum CharacterMoveState
{
    GoFarm,
    GoHorm
}
