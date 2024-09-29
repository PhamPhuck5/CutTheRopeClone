using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class InGameUI : Singleton<InGameUI>
{
    [SerializeField] Button SettingButton;
    [SerializeField] Button ReloadButton;
    [SerializeField] Button PB_Magnet;
    [SerializeField] Button PB_Power;

    private GameObject InGameStarGroup;
    private Sprite StarExist;

    [SerializeField] GameObject Setting;
    private GameObject Knife;
    [SerializeField] GameObject SuperPowerPrefab;
    [SerializeField] GameObject AllGameOJ;
    public GameObject StarCounter;
    private bool IsUsingPower = false;
    [HideInInspector] public GameObject WinningObject;

    protected override void Awake()
    {
        base.Awake();
        SettingButton.onClick.AddListener(TurnOnSetting);
        ReloadButton.onClick.AddListener(Reload);
        PB_Magnet.onClick.AddListener(Magnet);
        PB_Power.onClick.AddListener(SupperPower);
        WinningObject = transform.parent.GetChild(3).gameObject;
    }
    private void Start()
    {
        Knife = LeverControler.Instance.Knife;
        AllGameOJ = LeverControler.Instance.AllGameOj;
        StarExist = Resources.Load<Sprite>("Sprite/Star");
        InGameStarGroup = Candy.Instance.transform.parent.Find("StarGroup").gameObject;
    }
    private void TurnOnSetting()
    {
        Setting.SetActive(true);
        Knife.SetActive(false);
        AllGameOJ.SetActive(false);
    }
    private void Reload()
    {
        LeverControler.Instance.Lose();
    }
    private void Magnet()
    {
        if (!IsUsingPower)
        {
            for (int i = 0; i < 3; i++)
            {
                InGameStarGroup.transform.GetChild(i).GetComponent<CircleCollider2D>().radius *= 3;
            }
            Transform MagnetEffect = Candy.Instance.gameObject.transform.GetChild(0);
            MagnetEffect.gameObject.SetActive(true);
            IsUsingPower = true;
        }
    }
    private void SupperPower()
    {
        if (!IsUsingPower)
        {
            Transform FitGameTF = Candy.Instance.transform.parent.parent;
            FitGameTF.gameObject.GetComponent<Collider2D>().isTrigger = false;
            Instantiate(SuperPowerPrefab);
            IsUsingPower = true;
        }
    }
    public void AddStar()
    {
        Transform Star = StarCounter.transform.GetChild(LeverControler.Instance.StarCounter++);
        Image temp = Star.GetComponent<Image>();
        temp.sprite = StarExist;
    }

}
