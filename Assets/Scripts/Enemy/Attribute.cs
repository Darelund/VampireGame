using UnityEngine;


[System.Serializable]
public class Attribute
{
    //He also had an enemy field here. Maybe I will have a generic field in the future instead of passing in an object, maybe
    public virtual void UpdateAttribute(GameObject gameObject) { }
}
