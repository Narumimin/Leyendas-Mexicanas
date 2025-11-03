using System;
using UnityEngine;
using System.Collections;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Spawning : MonoBehaviour
{
    public GameObject spawnP1;
    public GameObject spawnP2;
    public AudioClip kalimanIntro;
    public AudioClip santoIntro;
    public AudioClip dingDing;
    public AudioClip Versus;
    public AudioSource BG;

    public GameObject santoP1;
    public GameObject santoP2;
    public GameObject kalimanP1;
    public GameObject kalimanP2;

    private PlayerMovementKalimanP1 playerKalimanP1;
    private PlayerMovementKalimanP2 playerKalimanP2;
    private PlayerMovementSantoP1 playerSantoP1;
    private PlayerMovementSantoP2 playerSantoP2;
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
        
        playerKalimanP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementKalimanP1>();
        playerKalimanP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementKalimanP2>();
        playerSantoP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementSantoP1>();
        playerSantoP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementSantoP2>();
        StartCoroutine(IntroduccionP1());
    }

    private IEnumerator IntroduccionP1()
    {
        if (playerKalimanP1 != null)
        {
            playerKalimanP1.enabled = false;
        }
        if (playerKalimanP2 != null)
        {
            playerKalimanP2.enabled = false;
        }
        if (playerSantoP1 != null)
        {
            playerSantoP1.enabled = false;
        }
        if (playerSantoP2 != null)
        {
            playerSantoP2.enabled = false;
        }

        if (Toggle_Character.instance.CheckChar0() == true)
        {
            AudioSource.PlayClipAtPoint(santoIntro, transform.position, 1f);
        }
        else if (Toggle_Character.instance.CheckChar1() == true)
        {
            AudioSource.PlayClipAtPoint(kalimanIntro, transform.position, 1f);
        }
        yield return new WaitForSeconds(4f);
        AudioSource.PlayClipAtPoint(Versus, transform.position, 1f);
        yield return new WaitForSeconds(1f);
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

        if (playerKalimanP1 != null)
        {
            playerKalimanP1.enabled = true;
        }
        if (playerKalimanP2 != null)
        {
            playerKalimanP2.enabled = true;
        }
        if (playerSantoP1 != null)
        {
            playerSantoP1.enabled = true;
        }
        if (playerSantoP2 != null)
        {
            playerSantoP2.enabled = true;
        }
    }
}
