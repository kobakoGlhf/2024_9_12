using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickForInfo : IAllInfo
{
    Vector2 Pos { get;}
    Vector2 TargetPos { get;}
    List<string> GetListString {  get; }

}
public interface IAllInfo
{
    Sprite Sprite { get;}
    string Name { get;}
}
// clickしたものの情報をとってUIに表示させるためのインターフェイス
// nullを入れるとUI部分が消える.