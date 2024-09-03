using UnityEngine;

//ファームまでの時間、ファーム終了時に得るアイテム、ファーム可能回数
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
            Debug.Log("_itemCountが操作されました。");
            _itemCount = value;
            if (_itemCount <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
