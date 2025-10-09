using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HealthEffect : MonoBehaviour //Maybe I want to make this 2 different scripts instead of doing a SpriteRenderer/Light check below, maybe
{
     [SerializeField] private List<HealthColor> healthColors;
     [SerializeField] private GameObject visuals;


    [SerializeField] private Damageable damageable;

    public void Awake()
    {
        damageable.OnHealthChanged += HealthEffect_OnHealthChanged;
    }

    public void HealthEffect_OnHealthChanged(object sender, Damageable.HealthChangedEventArgs e)
    {
        VisualManager.Instance.SpawnText($"{e.Damage}+", transform.position, TextType.Normal, Color.darkRed);
        HealthColor healthColor;
        string healthName = "";
        if (e.CurrentHealth >= e.MaxHealth / 2)
        {
            healthName = "High";
        }
        else if (e.CurrentHealth < e.MaxHealth / 2 && e.CurrentHealth > e.MaxHealth / 4)
        {
            healthName = "Medium";
        }
        else
        {
            healthName = "Low";
        }
        //Debug.Log(healthName);
        //healthColor = healthColors.Where(hc => hc.Name == healthName) as HealthColor;
        healthColor = healthColors.Find(hc => hc.Name == healthName);
        //Debug.Log(healthColor == null);
        //Debug.Log(innerObj.GetComponent<SpriteRenderer>() == null);

        if (visuals == null) return;
        if(visuals.GetComponent<SpriteRenderer>() != null)
        {
            visuals.GetComponent<SpriteRenderer>().color = healthColor.Color;
        }
        else if (visuals.GetComponent<Light2D>() != null)
        {
            visuals.GetComponent<Light2D>().color = healthColor.Color;
        }
        
    }
    private void OnDestroy()
    {
        damageable.OnHealthChanged += HealthEffect_OnHealthChanged;
    }
}
[System.Serializable]
public class HealthColor
{
    public string Name;
    public Color32 Color;
}