using UnityEngine;

public class Factory<T> where T : IAttributable, new()
{
    public Builder<T> builder;

    public Factory()
    {
        builder = new Builder<T>();
    }
    public void CreateEntity()
    {

    }
}
