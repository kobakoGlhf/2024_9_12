using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    CharacterController _character;
    private void OnEnable()
    {
        _character=transform.GetComponentInParent<CharacterController>();
        if (_character._characterState != CharacterState.Farming)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<FarmObject>()!=null)
        {
            _character._characterState = CharacterState.Farming;
        }
    }
}
