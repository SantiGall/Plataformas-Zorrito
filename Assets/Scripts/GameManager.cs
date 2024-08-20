using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int vidas = 1;
    public Text callateAriel;
    int i = 0;
    int t = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeScene("PlataformasZorrito"); 
            i = 1;
        }
        if (vidas < 1)
        {
            ChangeScene("L");
            i = 0;
            vidas = 1;
        }
        if (i == 1) callateAriel.text = "HP: " + vidas.ToString(); else callateAriel.text = "";
        if (Input.GetKeyDown(KeyCode.M)) ChangeScene("Menu");
    }

    public void HpDown(int damage)
    {
        if (t == 0)
        {
            StartCoroutine(wait());
            vidas =- damage;
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator wait()
    {
        t = 1;
        yield return new WaitForSeconds(3);
        t = 0;
    }
}
