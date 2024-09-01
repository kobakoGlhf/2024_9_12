using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterHome : MonoBehaviour
{
    [SerializeField] int _maxCharacter;
    CharacterControlle _character;
    List<CharacterControlle> _charactersList=new List<CharacterControlle>();
    [SerializeField] Vector2 target;
    [SerializeField] GameObject _characterPrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddCharacter();
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
        }
        else
        {
            Debug.Log("これ以上増やせません");
        }
    }
    public Vector2 SearchGoalPos(GameObject obj)
    {
        var targetObj = GameObject.FindObjectsOfType<FarmObject>();
        return targetObj.OrderBy(i => Vector2.Distance(i.transform.position, obj.transform.position))
            .FirstOrDefault().gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CharacterControlle>(out _character))
        {
            if (_character.MoveState == CharacterMoveState.GoHorm)
            {
                foreach (var item in _character.BackPack)
                {
                    switch (item)
                    {
                        case ItemList.Wood:
                            break;
                        case ItemList.Stone:
                            break;
                        case ItemList.Money:
                            break;
                    }
                }
                _character.BackPack.Clear();
            }
        }
    }
}
