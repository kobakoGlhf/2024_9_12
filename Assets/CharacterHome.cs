using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterHome : MonoBehaviour
{
    [SerializeField] int _maxCharacter;
    CharacterControlle _character;
    [SerializeField]List<CharacterControlle> _charactersList=new List<CharacterControlle>();
    [SerializeField] GameObject _targetObj;//Serializeはデバック用
    GameObject Target
    {
        get=>_targetObj;
        set
        {
            Debug.Log("target変更Home");
            _targetObj = value;
            foreach (CharacterControlle character in _charactersList)
            {
                if (character.MoveState == CharacterMoveState.GoFarm)
                {
                    character.MovePos = _targetObj.transform.position;
                }
            }
        }
    }
    [SerializeField] GameObject _characterPrefab;
    private void OnEnable()
    {
        Target=SearchGoalObj(this.gameObject);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddCharacter();
        }
    }
    private void FixedUpdate()
    {
        if (_targetObj == null)
        {
            _targetObj= SearchGoalObj(gameObject);
        }
    }
    void AddCharacter()
    {
        if (_charactersList.Count < _maxCharacter)
        {
            Debug.Log("キャラクターが増えました。");
            var obj = Instantiate(_characterPrefab, transform.position, Quaternion.identity);
            var characterControlle = obj.GetComponent<CharacterControlle>();
            _charactersList.Add(characterControlle);
            characterControlle.SetHome(gameObject);
            characterControlle.MovePos= Target.transform.position;
        }
        else
        {
            Debug.Log("これ以上増やせません");
        }
    }
    public GameObject SearchGoalObj(GameObject obj)
    {
        var targetObj = FindObjectsOfType<FarmObject>();
        Debug.Log(targetObj.Length);
        if (targetObj.Length>0)
        {
            return targetObj.OrderBy(i => Vector2.Distance(i.transform.position, obj.transform.position))
                .FirstOrDefault().gameObject;
        }
        else return gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HitHome");
        if (collision.TryGetComponent(out _character))
        {
            if (_character.MoveState == CharacterMoveState.GoHorm)
            {
                Debug.Log($"アイテム精査 {_character.BackPack}");
                foreach (var item in _character.BackPack)
                {
                    switch (item)
                    {
                        case ItemList.Wood:
                            CountItem.Wood++;
                            break;
                        case ItemList.Stone:
                            CountItem.Stone++;
                            break;
                        case ItemList.Money:
                            CountItem.Money++;
                            break;
                        default:
                            Debug.LogWarning("未設定項目が存在します");
                            break;
                    }
                }
                _character.BackPack.Clear();
                _character.MovePos = Target.transform.position;
            }
        }
    }
}
