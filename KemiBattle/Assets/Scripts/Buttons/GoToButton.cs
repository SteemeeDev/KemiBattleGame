using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToButton : Butto
{

    [SerializeField] GameObject enableObj;
    [SerializeField] GameObject disableObj;

    public override void Click()
    {
        base.Click();
        enableObj.SetActive(true);
        disableObj.SetActive(false);

        if (disableObj.GetComponent<MenuManager>() != null)
        {
            disableObj.GetComponent<MenuManager>().enabled = false;
        }
        if (enableObj.GetComponent<MenuManager>() != null)
        {
            enableObj.GetComponent<MenuManager>().enabled = true;
        }


    }
}
