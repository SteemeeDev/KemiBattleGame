using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MixingMenu : MenuManager
{
    public GameObject GO1;
    public GameObject GO2;

    public  GameObject[] leftButtons;
    public  GameObject[] rightButtons;

    public int leftIndex = 0;
    public int rightIndex = 0;

    public int leftSelectedIndex;
    public int rightSelectedIndex;

    public int up;
    bool leftSide = true;

    
    // This may be the worst code i have ever written, i apologize to anyone reading - Tore

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            up = -1;
            if (leftSide)
            {
                SmoothExit(easingTime, leftButtons, leftIndex);
                leftIndex = (leftIndex - 1 + leftButtons.Length) % leftButtons.Length;
                if (leftButtons[leftIndex] == null) leftIndex = (leftIndex - 1 + leftButtons.Length) % leftButtons.Length;
                SmoothHover(easingTime, leftButtons, leftIndex);
            }
            else if (!leftSide)
            {
                SmoothExit(easingTime, rightButtons, rightIndex);
                rightIndex = (rightIndex - 1 + rightButtons.Length) % rightButtons.Length;
                if (rightButtons[rightIndex] == null) rightIndex = (rightIndex - 1 + rightButtons.Length) % rightButtons.Length;
                SmoothHover(easingTime, rightButtons, rightIndex);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            up = 1;
            if (leftSide)
            {
                SmoothExit(easingTime, leftButtons, leftIndex);
                leftIndex = (leftIndex + 1 + leftButtons.Length) % leftButtons.Length;
                if (leftButtons[leftIndex] == null) leftIndex = (leftIndex + 1 + leftButtons.Length) % leftButtons.Length;
                SmoothHover(easingTime, leftButtons, leftIndex);
            }
            else if (!leftSide)
            {
                SmoothExit(easingTime, rightButtons, rightIndex);
                rightIndex = (rightIndex + 1 + rightButtons.Length) % rightButtons.Length;
                if (rightButtons[rightIndex] == null) rightIndex = (rightIndex + 1 + rightButtons.Length) % rightButtons.Length;
                SmoothHover(easingTime, rightButtons, rightIndex);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leftSide = false;
            SmoothHover(easingTime, rightButtons, rightIndex);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftSide = true;
            SmoothHover(easingTime, leftButtons, leftIndex);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!leftSide)
            {

                if (GO2 != null)
                {
                    rightButtons[rightSelectedIndex] = GO2;
                    GO2.transform.position = GO2.GetComponent<Butto>().startPos;
                }

                rightSelectedIndex = rightIndex;
                rightButtons[rightIndex].GetComponent<Butto>().Click();
            }
            if (leftSide)
            {
                if (GO1 != null)
                {
                    //Debug.Log("Setting " + leftButtons[leftSelectedIndex]);
                    leftButtons[leftSelectedIndex] = GO1;
                    GO1.transform.position = GO1.GetComponent<Butto>().startPos;
                }
                leftSelectedIndex = leftIndex;
                leftButtons[leftIndex].GetComponent<Butto>().Click();
                //Debug.Log("Setting left selectedIndex");
            }
        }
    }
}
