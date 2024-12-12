using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingMenu : MenuManager
{
    public GameObject GO1;
    public GameObject GO2;

    int leftSideButtons = 3;
    int rightSideButtons = 3;

    public override void Start()
    {
        base.Start();
    }

    bool menuOpen;

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !menuOpen)
        {
            StartCoroutine(smoothExit(easingTime));
            selectedIndex = (selectedIndex - 1 + Buttons.Length) % Buttons.Length;
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(easingTime));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !menuOpen)
        {
            StartCoroutine(smoothExit(easingTime));
            selectedIndex = (selectedIndex + 1) % Buttons.Length;
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(easingTime));
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && !menuOpen)
        {
            StartCoroutine(smoothExit(easingTime));
            selectedIndex = ((selectedIndex - 1 + Buttons.Length) + leftSideButtons) % Buttons.Length;
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(easingTime));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !menuOpen)
        {
            StartCoroutine(smoothExit(easingTime));
            selectedIndex = ((selectedIndex + 1) + rightSideButtons) % Buttons.Length;
            Debug.Log(Buttons[selectedIndex]);
            StartCoroutine(smoothHover(easingTime));
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            menuOpen = true;
            Buttons[selectedIndex].GetComponent<Butto>().Click();
        }
    }
}
