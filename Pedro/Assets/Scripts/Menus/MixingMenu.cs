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

    public Chemical[] chemicals;
    private Chemical madeChemical;

    [SerializeField] GameObject fightMenu;

    
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
                    StartCoroutine(GO2.GetComponent<SelectChemical>().MoveToStartPos(0.15f));
                }

                rightSelectedIndex = rightIndex;
                rightButtons[rightIndex].GetComponent<Butto>().Click();
                
                SmoothHover(easingTime, rightButtons, rightIndex);
            }
            if (leftSide)
            {
                if (GO1 != null)
                {
                    //Debug.Log("Setting " + leftButtons[leftSelectedIndex]);
                    leftButtons[leftSelectedIndex] = GO1;
                    StartCoroutine(GO1.GetComponent<SelectChemical>().MoveToStartPos(0.15f));
                }

                leftSelectedIndex = leftIndex;
                leftButtons[leftIndex].GetComponent<Butto>().Click();
                
                SmoothHover(easingTime, leftButtons, leftIndex);
                //Debug.Log("Setting left selectedIndex");
            }
        }

        if (Input.GetKeyDown (KeyCode.Return))
        {
            Debug.Log("Mixing " + GO1.name + " with " + GO2.name);

            madeChemical = null;

            foreach (Chemical chem in chemicals)
            {
                if (chem.leftChem == GO1.name)
                {
                    if (chem.rightChem == GO2.name)
                    {
                        madeChemical = chem;
                    }
                }
            }

            if (madeChemical != null)
            {
                Debug.Log(madeChemical.name);

                fightMenu.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Chemical doesnt exist yet!");
            }
        }
    }
}
