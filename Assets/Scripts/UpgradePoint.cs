using UnityEngine;

public class UpgradePoint : MonoBehaviour
{
    private int points;

    public int GetPoints() => points;
    public void InitializeUpgradePoint(int points) => this.points = points;
}
