using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SettingsButton : MenuButton
{
    [SerializeField] GameObject settingsObj;
    [SerializeField] GameObject mainMenuObj;

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        base.OnPointerClick(pointerEventData);
        settingsObj.SetActive(true);
        mainMenuObj.SetActive(false);
    }
}
