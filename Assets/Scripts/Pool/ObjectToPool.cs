using UnityEngine;

public class ObjectToPool : MonoBehaviour
{
    private ObjectPool _pool;
    public ObjectPool Pool
    {
        get { return _pool; }
        set { _pool = value; }
    }
    public void GiveBackToPool()
    {
        _pool.GiveBackToPool(this);
    }
}
