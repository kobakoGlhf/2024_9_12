using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�t�@�[���܂ł̎��ԁA�t�@�[���I�����ɓ���A�C�e���A�t�@�[���\��
public class FarmObject : MonoBehaviour
{
    [SerializeField] public float FarmSpeed;
    [SerializeField] public int ItemCount;
    [SerializeField] public ItemList _item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum ItemList
{
    Wood,
    Stone,
    Money,
}
