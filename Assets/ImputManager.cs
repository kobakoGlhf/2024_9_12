using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputManager : MonoBehaviour
{
    GameObject _clickObj;
    [SerializeField] InfoUIManager _uIManager;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IClickForInfo info=CreatRay<IClickForInfo>();
            _uIManager.SetClicObj = info;
        }
    }
#nullable enable
    public T? CreatRay<T>()
    {
        T? hitGameObject=default(T);
#nullable disable
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            hitGameObject = hit.collider.gameObject.GetComponent<T>();
            Debug.Log(hit.collider.gameObject.name);
        }
        return hitGameObject;
    }
}
