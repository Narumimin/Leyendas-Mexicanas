using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinnerController : MonoBehaviour
{
    private HealthP1 healthP1;
    private HealthP2 healthP2;
    public GameObject P1won;
    public GameObject P2won;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<HealthP1>();
        healthP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<HealthP2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthP1 != null && healthP1.isDead)
        {
            P1won.SetActive(true);
            StartCoroutine(LoadMainMenu());

        }
        else if (healthP2 != null && healthP2.isDead)
        {
            P2won.SetActive(true);
            StartCoroutine(LoadMainMenu());
        }
    }

    private IEnumerator LoadMainMenu() 
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
