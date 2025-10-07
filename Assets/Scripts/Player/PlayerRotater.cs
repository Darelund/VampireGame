using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    //[SerializeField] private Transform visuals;
    public void Rotate()
    {
        var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = (mouseInWorldSpace - gameObject.transform.position);

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(45f, 0, angle - 90);

        //var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //// mouseInWorldSpace.z = 0; 
        //var dir = (mouseInWorldSpace - transform.position);
        //// var normalizedDir = dir.normalized;

        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(56.06f, 0, angle - 90);

        //visuals.localRotation = Quaternion.Euler(0, 90, -45);

        //transform.LookAt(mouseInWorldSpace);
    }
  
}
