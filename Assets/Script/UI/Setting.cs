using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Setting : MonoBehaviour
{
    [SerializeField] Button ReturnToMenu;
    [SerializeField] Button Video;
    [SerializeField] Button Continues;
    [SerializeField] Button buy;
    private GameObject Knife;
    [SerializeField] GameObject BuyPhase;
    [SerializeField] GameObject AllGameObject;

    private void Awake()
    {
        ReturnToMenu.onClick.AddListener(ReturnMenu);
        Video.onClick.AddListener(Collection);
        Continues.onClick.AddListener(ContinuesGame);
        buy.onClick.AddListener(BuyPower);
    }
    private void Start()
    {
        Knife = LeverControler.Instance.Knife;
        AllGameObject = LeverControler.Instance.AllGameOj;
    }
    private void ReturnMenu()
    {
        string MenuName = "BoxS" + GameControler.Instance.Season.ToString();
        SceneManager.LoadScene(MenuName);
    }
    private void ContinuesGame()
    {
        Knife.SetActive(true);
        gameObject.SetActive(false);
        AllGameObject.SetActive(true);
    }
    private void Collection()
    {
        SceneManager.LoadScene("Collection");
    }
    private void BuyPower()
    {
        BuyPhase.SetActive(true);
        gameObject.SetActive(false);
    }

}
