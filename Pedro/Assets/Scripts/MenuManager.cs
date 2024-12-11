using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Vector3 hoverSizeIncrease = new Vector3(0.5f,0.5f,0);
    [SerializeField] GameObject[] Buttons;
    [SerializeField] float easingTime = 0.15f;

    Vector3 startScale = Vector3.zero;
    Vector3 startScale2 = Vector3.zero;
    int selectedIndex = 0;
    int selectedIndex2 = 0;
    int selectedIndex3 = 0;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(smoothExit(0.1f));
            selectedIndex = (selectedIndex - 1 + Buttons.Length) % Buttons.Length;
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(0.1f));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(smoothExit(0.1f));
            selectedIndex = (selectedIndex + 1) % Buttons.Length; 
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(0.1f));
        }
    }

    IEnumerator smoothHover(float smoothTime)
    {
        float elapsed = 0;
        float t;

        selectedIndex2 = selectedIndex;
        startScale = Buttons[selectedIndex].GetComponent<Butto>().startScale;

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            t = elapsed / smoothTime;
            // m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));

            Buttons[selectedIndex2].transform.localScale = Vector3.Lerp(startScale, startScale + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));


            yield return null;
        }
    }
    IEnumerator smoothExit(float smoothTime)
    {
        float elapsed = smoothTime;
        float t;


        selectedIndex3 = selectedIndex;
        startScale2 = Buttons[selectedIndex3].GetComponent<Butto>().startScale;

        while (elapsed > 0)
        {
            elapsed -= Time.deltaTime;
            t = elapsed / smoothTime;
            //m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));
            Buttons[selectedIndex3].transform.localScale = Vector3.Lerp(startScale2, startScale2 + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));
            yield return null;
        }
    }
}