using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.Windows;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Vector3 hoverSizeIncrease = new Vector3(0.5f,0.5f,0);
    [SerializeField] public GameObject[] Buttons;
    [SerializeField] public float easingTime = 0.15f;

    public int selectedIndex = 0;

    public virtual void Start()
    {
        StartCoroutine(smoothHover(easingTime));
    }


    bool menuOpen;
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !menuOpen)
        {
            StartCoroutine(smoothExit(easingTime));
            selectedIndex = (selectedIndex - 1 + Buttons.Length) % Buttons.Length;
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(easingTime));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !menuOpen)
        {
            StartCoroutine(smoothExit(easingTime));
            selectedIndex = (selectedIndex + 1) % Buttons.Length; 
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(easingTime));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            menuOpen = true;
            Buttons[selectedIndex].GetComponent<Butto>().Click();
        }
    }

    public IEnumerator smoothHover(float smoothTime)
    {
        float elapsed = 0;
        float t;

        int _selectedIndex = selectedIndex;
        Vector3 startScale = Buttons[_selectedIndex].GetComponent<Butto>().startScale;

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            t = elapsed / smoothTime;
            // m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            Buttons[_selectedIndex].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            yield return null;
        }
    }
    public IEnumerator smoothExit(float smoothTime)
    {
        float elapsed = smoothTime;
        float t;

        int _selectedIndex = selectedIndex;
        Vector3 startScale = Buttons[_selectedIndex].GetComponent<Butto>().startScale;

        while (elapsed > 0)
        {
            elapsed -= Time.deltaTime;
            t = elapsed / smoothTime;
            //m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            Buttons[_selectedIndex].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            yield return null;
        }
    }
}