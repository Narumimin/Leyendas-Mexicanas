using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    private static Toggle_Character instance;
    public static bool char0;
    public static bool char1;
    public static bool char2;
    public static bool char3;
    public List<GameObject> checkList;

    void Start()
    {
        if (!PlayerPrefs.HasKey("char0"))
        {
            char0 = true;
        }

        if (!PlayerPrefs.HasKey("char2"))
        {
            char3 = true;
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

    public void SelectChar2()
    {
        //select character 1
        char2 = true;
        char3 = false;
    }

    public void SelectChar3()
    {
        //select character 1
        char2 = false;
        char3 = true;
    }

    private void Update()
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

        if (char2 == true)
        {
            checkList[2].SetActive(true);
        }
        else
        {
            checkList[2].SetActive(false);
        }

        if (char3 == true)
        {
            checkList[3].SetActive(true);
        }
        else
        {
            checkList[3].SetActive(false);
        }
    }
}
