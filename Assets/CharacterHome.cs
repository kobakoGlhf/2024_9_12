using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHome : MonoBehaviour
{
    [SerializeField] int _maxCharacter;
    CharacterControlle _character;
    [SerializeField] Vector2 target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<CharacterControlle>(out _character))
        {
            if (_character.MoveState == CharacterMoveState.GoHorm)
            {
                foreach(var item in _character.BackPack)
                {
                    switch(item)
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
