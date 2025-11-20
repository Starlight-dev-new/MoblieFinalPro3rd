using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangSecn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "CutScen")
        {
           StartCoroutine(CountDownEndSecn());
        }       
        
    }

    // Update is called once per frame
    public IEnumerator CountDownEndSecn()
    {
        yield return new WaitForSeconds(8);
       SceneManager.LoadScene("MainGame");
        
    }
    public void PlayAgin()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void playMain()
    {
        SceneManager.LoadScene("CutScen");
    }
}
