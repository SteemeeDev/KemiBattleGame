using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SelectChemical : Butto
{


    [SerializeField] Transform targetPos;
    [SerializeField] MixingMenu _MenuManager;
    public bool leftSide;

    public override void Click()
    {
        base.Click();
        MoveTotarget(0.3f);
    }

    async void MoveTotarget(float smoothTime)
    {
        float elapsed = 0;


        if (leftSide)
        {
            _MenuManager.GO1 = gameObject;
            _MenuManager.leftButtons[_MenuManager.leftIndex] = null;
            _MenuManager.leftIndex = (_MenuManager.leftIndex + _MenuManager.up + _MenuManager.leftButtons.Length) % _MenuManager.leftButtons.Length;
        }
        if (!leftSide)
        {
            _MenuManager.GO2 = gameObject;
            _MenuManager.rightButtons[_MenuManager.rightIndex] = null;
            _MenuManager.rightIndex = (_MenuManager.rightIndex + _MenuManager.up + _MenuManager.rightButtons.Length) % _MenuManager.rightButtons.Length;
        }

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;
            transform.position = Vector2.Lerp(startPos, targetPos.position, 1 - Mathf.Pow(1 - t, 4));
            transform.localScale = startScale;
            await Task.Yield();
        }
    }

    public IEnumerator MoveToStartPos(float smoothTime)
    {
        float elapsed = 0;

        while (elapsed < smoothTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / smoothTime;
            transform.position = Vector2.Lerp(targetPos.position, startPos, 1 - Mathf.Pow(1 - t, 4));
            transform.localScale = startScale;
            yield return null;
        }
    }
}
