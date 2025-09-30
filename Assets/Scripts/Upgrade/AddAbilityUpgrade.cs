using UnityEngine;

public class AddAbilityUpgrade : Upgrade
{
    public GameObject NewAbilityPrefab;

    public override void Awake()
    {
        base.Awake();
    }
    public override void ActivateAbility()
    {
        Instantiate(NewAbilityPrefab, playerController.transform);
        GameManager.Instance.SwitchState<PlayingState>();
        Debug.Log("Added ability");

    }
}
