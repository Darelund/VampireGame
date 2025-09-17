using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }
    private void RotatePlayer()
    {
        var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInWorldSpace.z = 0; //Ignore depth
        var dir = (mouseInWorldSpace - transform.position);
        var normalizedDir = dir.normalized;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
