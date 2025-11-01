using System.Collections.Generic;
using UnityEngine;

public class Toggle_Character : MonoBehaviour
{

    public bool char0;
    public bool char1;
    public bool isSelectorCheck;
    public List<GameObject> checkList;

    void Start()
    {
        if (!PlayerPrefs.HasKey("char0"))
        {
            char0 = true;
        }
    }

    public void SelectChar0()
    {
        //select character 0
        char0 = true;
        char1 = false;
    }

    public void SelectChar1()
    {
        //select character 1
        char0 = false;
        char1 = true;
    }

    private void Update()
    {
        if (isSelectorCheck == true)
        {
            if (char0 == true)
            {
                checkList[0].SetActive(true);
            }
            else
            {
                checkList[0].SetActive(false);
            }

            if (char1 == true)
            {
                checkList[1].SetActive(true);
            }
            else
            {
                checkList[1].SetActive(false);
            }
        }
    }
}
