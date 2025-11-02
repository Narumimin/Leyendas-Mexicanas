using System.Collections.Generic;
using UnityEngine;

public class Toggle_Character : MonoBehaviour
{
    public static Toggle_Character instance;
    public static bool santoP1;
    public static bool kalimanP1;
    public static bool santoP2;
    public static bool kalimanP2;

    private void Awake()
    {

        instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
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

    public bool CheckChar0()
    {
        return santoP1;
    }

    public bool CheckChar1()
    {
        return kalimanP1;
    }

    public bool CheckChar2()
    {
        return santoP2;
    }

    public bool CheckChar3()
    {
        return kalimanP2;
    }

}
