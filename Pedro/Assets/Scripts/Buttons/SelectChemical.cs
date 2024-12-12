using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChemical : Butto
{
    [SerializeField] Vector2 targetPos;
    [SerializeField] MixingMenu _MenuManager;
    public bool leftSide;

    public override void Click()
    {
        base.Click();
        StartCoroutine(moveTotarget(_MenuManager.easingTime));


    }

    IEnumerator moveTotarget(float smoothTime)
    {
        float elapsed = 0;

        if (_MenuManager.GO1 != null || _MenuManager.GO2 != null)
        {
            if (leftSide)
                _MenuManager.GO1.transform.position =
                     _MenuManager.GO1.GetComponent<Butto>().startPos;
            if (!leftSide)
                _MenuManager.GO2.transform.position =
                    _MenuManager.GO2.GetComponent<Butto>().startPos;
        }

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;
            transform.position = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }


        if (leftSide)
            _MenuManager.GO1 = gameObject;
        if (!leftSide)
            _MenuManager.GO2 = gameObject;
    }
}
