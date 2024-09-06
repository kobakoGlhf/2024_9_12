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
// click�������̂̏����Ƃ���UI�ɕ\�������邽�߂̃C���^�[�t�F�C�X
// null�������UI������������.