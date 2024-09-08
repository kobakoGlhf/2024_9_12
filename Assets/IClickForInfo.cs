using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickForInfo : IAllObjectInfo
{
    Vector2 TargetPos { get;}
    Dictionary<GameObject,SpriteDate> HaveList { get; }
    
}
public class SpriteDate
{
    public Sprite Sprite;
    public string Name;
    public SpriteDate(Sprite sprite,string name)
    {
        Sprite = sprite;
        Name = name;
    }
}
public interface IAllObjectInfo
{
    Vector2 Pos { get;}
    Sprite Sprite { get;}
    string Name { get;}
}
// clickしたものの情報をとってUIに表示させるためのインターフェイス
// nullを入れるとUI部分が消える.