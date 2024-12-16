using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.Windows;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Vector3 hoverSizeIncrease = new Vector3(0.5f,0.5f,0);
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] public float easingTime = 0.15f;

    public int selectedIndex = 0;


    public bool menuOpen;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !menuOpen)
        {
            SmoothExit(easingTime, Buttons, selectedIndex);
            selectedIndex = (selectedIndex - 1 + Buttons.Length) % Buttons.Length;
           // Debug.Log(Buttons[selectedIndex]);
            SmoothHover(easingTime, Buttons, selectedIndex);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !menuOpen)
        {
           SmoothExit(easingTime, Buttons, selectedIndex);
            selectedIndex = (selectedIndex + 1) % Buttons.Length; 
            //Debug.Log(Buttons[selectedIndex]);
            SmoothHover(easingTime, Buttons, selectedIndex);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            menuOpen = true;
            Buttons[selectedIndex].GetComponent<Butto>().Click();
        }
    }

    public async void SmoothHover(float smoothTime, GameObject[] _buttons, int index)
    {
        float elapsed = 0;
        float t;

        Vector3 startScale = Vector3.zero;
        try
        {
            startScale = _buttons[index].GetComponent<Butto>().startScale;

          //  Debug.Log("Scaling up object " + index);

            while (elapsed < smoothTime)
            {
                elapsed += Time.deltaTime;
                t = elapsed / smoothTime;
                // m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                _buttons[index].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                await Task.Yield();
            }
        }
        catch
        {
          //  Debug.Log("Object cant be scaled!");
            return;
        }

    }
    public async void SmoothExit(float smoothTime, GameObject[] _buttons, int index)
    {
        float elapsed = smoothTime;
        float t;
        Vector3 startScale = Vector3.zero;
        try
        {
            startScale = _buttons[index].GetComponent<Butto>().startScale;
          //  Debug.Log("Scaling down object " + index);

            while (elapsed > 0)
            {
                elapsed -= Time.deltaTime;
                t = elapsed / smoothTime;
                //m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                _buttons[index].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

                await Task.Yield();
            }
        }
        
        catch
        {
          //  Debug.Log("Object cant be scaled!");
            return;
        }
    }
}