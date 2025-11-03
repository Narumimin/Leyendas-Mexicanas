using UnityEngine;

public class testestes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            var healthComponent = collision.GetComponent<HealthP1>();
            if (healthComponent != null)
            {
                healthComponent.health -= 100;
            }
        }
    }
}
