using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverControler : Singleton<LeverControler>
{
    public GameObject Knife;
    public GameObject AllGameOj;
    public int StarCounter = 0;

    public void Lose()
    {
        string SceneName = "Lever" + GameControler.Instance.LeverInfo.ToString();
        Debug.LogWarning("Thua");
        SceneManager.LoadScene(SceneName);
    }
}
