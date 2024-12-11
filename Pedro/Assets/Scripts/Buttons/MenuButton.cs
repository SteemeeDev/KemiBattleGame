using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Vector3 hoverSizeIncrease = new Vector3(0.5f,0.5f,0);
    [SerializeField] float easingTime = 0.15f;


    TMP_Text m_text;
    float startFontSize;
    Vector3 startTransform;

    Vector3 scale = Vector3.zero;
    public void Awake()
    {
        m_text = GetComponent<TMP_Text>();
        //startFontSize = m_text.fontSize;
        startTransform = transform.localScale;
    }

    public virtual void OnPointerClick(PointerEventData pointerEventData)
    {
        //Some basic button functionality
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        StartCoroutine(smoothHover(easingTime));
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        StartCoroutine(smoothExit(easingTime));
    }

    IEnumerator smoothHover(float smoothTime)
    {
        float elapsed = 0;
        float t;
        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            t = elapsed / smoothTime;
            // m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));
           
            transform.localScale = Vector3.Lerp(startTransform, startTransform + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));
            yield return null;
        }
    }
    IEnumerator smoothExit(float smoothTime)
    {
        float elapsed = smoothTime;
        float t;
        while (elapsed > 0)
        {
            elapsed -= Time.deltaTime;
            t = elapsed / smoothTime;
            //m_text.fontSize = Mathf.Lerp(startFontSize, startFontSize + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));
            transform.localScale = Vector3.Lerp(startTransform, startTransform + hoverSizeIncrease, 1 - Mathf.Pow(1 - t, 4));
            yield return null;
        }
    }
}