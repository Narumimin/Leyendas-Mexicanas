using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    private static Toggle_Character instance;
    public static bool santoP1;
    public static bool kalimanP1;
    public static bool santoP2;
    public static bool kalimanP2;
    public List<GameObject> checkList;

    void Start()
    {
        santoP1 = false;
        santoP2 = false;
        kalimanP1 = false;
        kalimanP2 = false;

        if (!PlayerPrefs.HasKey("char0"))
        {
            santoP1 = true;
        }

        if (!PlayerPrefs.HasKey("char2"))
        {
            kalimanP2 = true;
        }
    }

    public void SelectChar0()
    {
        //select character 0
        santoP1 = true;
        kalimanP1 = false;
    }

    public void SelectChar1()
    {
        //select character 1
        santoP1 = false;
        kalimanP1 = true;
    }

    public void SelectChar2()
    {
        //select character 1
        santoP2 = true;
        kalimanP2 = false;
    }

    public void SelectChar3()
    {
        //select character 1
        santoP2 = false;
        kalimanP2 = true;
    }

    private void Update()
    {
        if (santoP1 == true)
        {
            checkList[0].SetActive(true);
        }
        else
        {
            checkList[0].SetActive(false);
        }

        if (kalimanP1 == true)
        {
            checkList[1].SetActive(true);
        }
        else
        {
            checkList[1].SetActive(false);
        }

        if (santoP2 == true)
        {
            checkList[2].SetActive(true);
        }
        else
        {
            checkList[2].SetActive(false);
        }

        if (kalimanP2 == true)
        {
            checkList[3].SetActive(true);
        }
        else
        {
            checkList[3].SetActive(false);
        }
    }
}
