using System;
using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{
    public GameObject spawnP1;
    public GameObject spawnP2;
    public AudioClip kalimanIntro;
    public AudioClip santoIntro;
    public AudioClip dingDing;
    public AudioSource BG;

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
        StartCoroutine(IntroduccionP1());
    }

    private IEnumerator IntroduccionP1()
    {
        if (Toggle_Character.instance.CheckChar0() == true)
        {
            AudioSource.PlayClipAtPoint(santoIntro, transform.position, 1f);
        }
        else if (Toggle_Character.instance.CheckChar1() == true)
        {
            AudioSource.PlayClipAtPoint(kalimanIntro, transform.position, 1f);
        }
        yield return new WaitForSeconds(4f);
        StartCoroutine(IntroduccionP2());
    }

    private IEnumerator IntroduccionP2()
    {
        if (Toggle_Character.instance.CheckChar2() == true)
        {
            AudioSource.PlayClipAtPoint(santoIntro, transform.position, 1f);
        }
        else if (Toggle_Character.instance.CheckChar3() == true)
        {
            AudioSource.PlayClipAtPoint(kalimanIntro, transform.position, 1f);
        }
        yield return new WaitForSeconds(4f);
        AudioSource.PlayClipAtPoint(dingDing, transform.position, 1f);
        yield return new WaitForSeconds(0.8f);
        BG.enabled = true;
    }
}
