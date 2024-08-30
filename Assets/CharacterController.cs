using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] float _interactSpees;
    [SerializeField] float _speed;
    [SerializeField] int _maxBackPackList;
    public List<ItemList> BackPack;
    public CharacterState _characterState;
    GameObject _home;
    Vector2 _goalPos;
    FarmObject _farmObject;
    GameObject _interactObj;
    //この下のものはテスト様だったり改善の余地がありそうなもの
    [SerializeField] Transform _testTransform;
    [SerializeField] bool test;
    float _timer = 0f;
    public GameObject SetInteractOnj
    {
        get { return _interactObj; }
        set { _interactObj = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (test) _goalPos = _testTransform.position;
        else _goalPos = SearchGoalPos();
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, _goalPos)) < _interactSpees)
        {
            Farm();
        }
        else
        {
            Move();
        }
    }
    private void Move()
    {
        //移動処理
        var distance = (_goalPos - (Vector2)transform.position).normalized;
        Debug.Log(_goalPos - (Vector2)transform.position);
        transform.localPosition += (Vector3)distance * _speed * Time.deltaTime;
    }
    private void Farm()
    {
        _timer += Time.deltaTime;
        if (_timer > _farmObject.FarmSpeed)
        {
            _farmObject.ItemCount--;
            BackPack.Add(_farmObject._item);
            if (BackPack.Count == _maxBackPackList)
            {
                _goalPos = _home.transform.position;
            }
            _timer = 0f;
        }
    }
    Vector2 SearchGoalPos()
    {
        var obj = GameObject.FindObjectsOfType<FarmObject>();
        return obj.OrderBy(i => Vector2.Distance(i.transform.position, this.transform.position))
            .FirstOrDefault().gameObject.transform.position;
    }
    void SetHomePos(GameObject home)
    {
        _home = home;
    }
}
public enum CharacterState
{
    Moving,
    Farming,
}
