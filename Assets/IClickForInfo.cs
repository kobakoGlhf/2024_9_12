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
// click�������̂̏����Ƃ���UI�ɕ\�������邽�߂̃C���^�[�t�F�C�X
// null�������UI������������.