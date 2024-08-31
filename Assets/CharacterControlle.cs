using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CharacterControlle : MonoBehaviour
{
    [SerializeField] GameObject _child;
    [SerializeField] float _interactSpees;
    [SerializeField] float _speed;
    [SerializeField] int _maxBackPackListCount;
    GameObject _home;
    Vector2 _movePos;
    FarmObject _farmObject;
    GameObject _interactObj;
    //�Ƃ��瑀�삷�镔��
    public CharacterMoveState MoveState;
    public List<ItemList> BackPack;
    //���̉��̂��̂̓e�X�g�l����������P�̗]�n�����肻���Ȃ���
    [SerializeField] Transform _testTransform;
    [SerializeField] bool test;
    [SerializeField] GameObject _testHome;
    float _timer = 0f;
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
        _home = _testHome;
        if (test)
        {
            GoalPos = _testTransform.position;
        }
        else GoalPos =SearchMethod.SearchGoalPos(gameObject);
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
                _child.SetActive(true);
                if (_home != null&&_farmObject==null)
                {
                    GoalPos = _home.transform.position;
                }
                Debug.Log("����I��");
            }
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        //�ړ�����
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
    void SetHomePos(GameObject home)
    {
        _home = home;
    }
}
public enum CharacterMoveState
{
    GoFarm,
    GoHorm
}
