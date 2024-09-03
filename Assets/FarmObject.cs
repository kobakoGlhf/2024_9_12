using UnityEngine;

//�t�@�[���܂ł̎��ԁA�t�@�[���I�����ɓ���A�C�e���A�t�@�[���\��
public class FarmObject : MonoBehaviour
{
    [SerializeField] public float FarmSpeed;
    [SerializeField] int _itemCount;
    [SerializeField] public ItemList _item;
    public int ItemCount
    {
        get { return _itemCount; }
        set
        {
            Debug.Log("_itemCount�����삳��܂����B");
            _itemCount = value;
            if (_itemCount <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
