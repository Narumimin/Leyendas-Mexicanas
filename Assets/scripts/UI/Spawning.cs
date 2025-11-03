using System;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject spawnP1;
    public GameObject spawnP2;

    public GameObject santoP1;
    public GameObject santoP2;
    public GameObject kalimanP1;
    public GameObject kalimanP2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        if (Toggle_Character.instance.CheckChar0() == true)
        {
            Instantiate(santoP1, spawnP1.transform.position, Quaternion.identity);
        }

        else if (Toggle_Character.instance.CheckChar1() == true)
        {
            Instantiate(kalimanP1, spawnP1.transform.position, Quaternion.identity);
        }

        if (Toggle_Character.instance.CheckChar2() == true)
        {
            Instantiate(santoP2, spawnP2.transform.position, Quaternion.identity);
        }

        else if (Toggle_Character.instance.CheckChar3() == true)
        {
            Instantiate(kalimanP2, spawnP2.transform.position, Quaternion.identity);
        }
        
    }
}
