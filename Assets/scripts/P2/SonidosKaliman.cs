using UnityEngine;

public class SonidosKaliman : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip attackClip;
    public AudioClip whiffAttackClip;
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip damageClip;
    public AudioClip runClip;
    public AudioClip playerDeathClip;

    public void attack()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.8f);
    }
    public void WhiffAttack()
    {
        AudioSource.PlayClipAtPoint(whiffAttackClip, transform.position, 0.8f);
    }

    public void jump()
    {
        AudioSource.PlayClipAtPoint(jumpClip, transform.position, 1f);
    }

    public void death()
    {
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 1f);
    }

    public void damage()
    {
        AudioSource.PlayClipAtPoint(damageClip, transform.position, 1f);
    }

    public void run()
    {
        AudioSource.PlayClipAtPoint(runClip, transform.position, 1f);
    }

    public void playerDeath()
    {
        AudioSource.PlayClipAtPoint(playerDeathClip, transform.position, 1f);
    }
}
