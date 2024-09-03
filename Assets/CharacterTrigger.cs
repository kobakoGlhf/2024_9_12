using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    [SerializeField] CharacterControlle _character;
    FarmObject _farmObject;
    GameObject _closestObj;
    Vector2 _closestObjPos;
    private void OnEnable()
    {
        _character=transform.GetComponentInParent<CharacterControlle>();
        Debug.Log(_character);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ƒqƒbƒg");
        if (collision.TryGetComponent(out _farmObject))
        {
            var collisionPos = collision.transform.position;
            var newDistane = Vector2.Distance(collisionPos, transform.position);
            var oldDistance = Vector2.Distance(_closestObjPos, transform.position);
            if (newDistane < oldDistance||_closestObj==null)
            {
                Debug.Log($"targetchange:newDistane");
                _closestObjPos = collisionPos;
                _closestObj = _farmObject.gameObject;
                _character.SetFarmObject = _farmObject;
            }
        }
    }
}
