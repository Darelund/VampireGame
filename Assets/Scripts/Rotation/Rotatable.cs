using UnityEngine;

public class Rotatable : Attribute
{
    private GameObject _target;
    private CharacterType _owner;

    public Rotatable()
    {
        _owner = CharacterType.NonPlayer;

        if (_owner == CharacterType.NonPlayer)
            _target = GameManager.Instance.Player;

    }
    public override void UpdateAttribute(GameObject gameObject)
    {
        LookAt(gameObject);
    }
   
    protected virtual void LookAt(GameObject gameObject)
    {
        if (_target == null && _owner == CharacterType.NonPlayer)
        {
            Debug.Log("AM I THE NULL ONE? Rotatable");
        }

        if (_owner == CharacterType.NonPlayer)
        {
            var playerDir = (_target.transform.position - gameObject.transform.position).normalized;
            var angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(45f, 0, angle - 90);
        }
        else if (_owner == CharacterType.Player)
        {
            var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (mouseInWorldSpace - gameObject.transform.position);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(45f, 0, angle - 90); //I rotate character to this, it works. Magic numbers? Magically works
           // transform.rotation = Quaternion.Euler(0, 0, angle); //I rotate character to this, it works. Magic numbers? Magically works

        }
    }

   
}
