using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthP1 : MonoBehaviour
{
    public int maxHealth = 500; // vida total
    public int health; // vida actual
    public bool isDead = false;
    public Slider slider;
    private PlayerMovementSantoP2 Santo;
    private PlayerMovementKalimanP2 Kaliman;
    private SantoAttacks santoAttacks;
    private KalimanAttacks kalimanAttacks;
    //public AudioSource AudioSource;
    public Animator animator;
    public SonidosSanto soundsSanto;
    public SonidosKaliman soundsKaliman;

    private void Start()
    {
        animator = GetComponent<Animator>();
        soundsKaliman = GetComponent<SonidosKaliman>();
        soundsSanto = GetComponent<SonidosSanto>();
        Santo = GetComponent<PlayerMovementSantoP2>();
        Kaliman = GetComponent<PlayerMovementKalimanP2>();
        santoAttacks = GetComponent<SantoAttacks>();
        kalimanAttacks = GetComponent<KalimanAttacks>();
        slider = GameObject.FindGameObjectWithTag("healthbarP1").GetComponent<Slider>();
        slider.maxValue = maxHealth;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if (health <= 0 && isDead == false)
        {
            //animator.SetTrigger("Dead");
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        if (santoAttacks != null)
        {
            soundsSanto.death();
            santoAttacks.enabled = false;
        }
        if (kalimanAttacks != null)
        {
            soundsKaliman.death();
            kalimanAttacks.enabled = false;
        }
        animator.SetBool("ded", true);
        //AudioSource.Pause();
        //sound.bossEnd();
    }
}