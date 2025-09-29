using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionState : State
{
    [SerializeField] private List<GameObject> optionPanels = new List<GameObject>();
    [SerializeField] private List<GameObject> optionBtns = new List<GameObject>();
    [SerializeField] private Color activeColor;
    [SerializeField] private Color disabledColor;



    public void SetActivePanel(int index)
    {
        optionPanels.ForEach(p => { 
            p.SetActive(false);
        });
        optionBtns.ForEach(b => {
            b.GetComponent<Image>().color = disabledColor;
        });

        optionBtns[index].GetComponent<Image>().color = activeColor;
        optionPanels[index].SetActive(true);
    }

    public void CloseOptionPanel()
    {
        optionPanels.ForEach(p => {
            p.SetActive(false);
        });
        //The first panel that should be active when you enter settings
        optionPanels[0].SetActive(true); 
    }
   
}
