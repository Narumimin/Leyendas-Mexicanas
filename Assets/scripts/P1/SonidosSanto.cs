using UnityEngine;

public class SonidosSanto : MonoBehaviour
{
    public AudioClip attackClip;
    public AudioClip whiffAttackClip;
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip damageClip;

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
}
