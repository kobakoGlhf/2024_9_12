using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    [SerializeField] CharacterControlle _character;
    FarmObject _farmObject;
    private void OnEnable()
    {
        _character=transform.GetComponentInParent<CharacterControlle>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ƒqƒbƒg");
        if(collision.TryGetComponent<FarmObject>(out _farmObject))
        {
            var newDistane= Vector2.Distance(collision.transform.position, transform.position);
            var oldDistance =_character.SetFarmObject? Vector2.Distance(_character.SetFarmObject.transform.
                position, transform.position):0;
            if (newDistane>oldDistance)
                _character.SetFarmObject = _farmObject;
        }
    }
}
