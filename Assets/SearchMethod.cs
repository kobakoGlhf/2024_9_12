using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SearchMethod
{
    // Start is called before the first frame update

    public static Vector2 SearchGoalPos(GameObject obj)
    {
        var targetObj = GameObject.FindObjectsOfType<FarmObject>();
        return targetObj.OrderBy(i => Vector2.Distance(i.transform.position, obj.transform.position))
            .FirstOrDefault().gameObject.transform.position;
    }
    public static T CreatRay<T>()
    {
#nullable enable
        T? hitGameObject;
#nullable disable
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        return hit.collider.gameObject.GetComponent<T>();
    }
}
