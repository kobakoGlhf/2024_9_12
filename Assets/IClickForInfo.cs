using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickForInfo
{
    Vector2 Pos { get;}
    Sprite Sprite { get;}
    Vector2 TargetPos { get;}
    string Name { get;}
}
// clickしたものの情報をとってUIに表示させるためのインターフェイス
// nullを入れるとUI部分が消える.