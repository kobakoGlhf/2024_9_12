using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickForInfo
{
    Vector2 Pos { get; set; }
    Sprite Sprite { get; set; }
    Vector2 TargetPos { get; set;}
    string name { get; set; }

}
