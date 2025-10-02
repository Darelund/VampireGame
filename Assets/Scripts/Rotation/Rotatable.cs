using UnityEngine;

public class Rotatable : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private CharacterType owner;
    public CharacterType GetOwner => owner;


    protected virtual void Awake()
    {
        if (owner == CharacterType.NonPlayer)
            target = GameObject.Find("Player");

        Debug.Log(target == null);
    }
    public void Rotate()
    {
        LookAt();
    }
    protected virtual void LookAt()
    {
        if (target == null && owner == CharacterType.NonPlayer)
        {
            Debug.Log("AM I THE NULL ONE? Rotatable");
        }

        if (owner == CharacterType.NonPlayer)
        {
            var playerDir = (target.transform.position - transform.position).normalized;
            var angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (owner == CharacterType.Player)
        {
            var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = (mouseInWorldSpace - transform.position);


            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(56.06f, 0, angle - 90); //I rotate character to this, it works. Magic numbers? Magically works
        }
    }
}
