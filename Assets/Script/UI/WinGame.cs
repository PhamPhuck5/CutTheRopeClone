using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    [SerializeField] Button SkinButton;
    [SerializeField] Button CollectionButton;
    [SerializeField] Button ReloadButton;
    [SerializeField] Button NextLeverButton;

    [SerializeField] Text RewardMoney;
    [SerializeField] Text CurMoney;

    private Sprite StarExist;
    [SerializeField] Transform StarGroup;
    [SerializeField] GameObject AllUI;
    [SerializeField] GameObject LeftCarton;
    [SerializeField] GameObject RightCarton;


    private void Awake()
    {
        SkinButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SkinManager");
        });
        CollectionButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Collection");
        });
        ReloadButton.onClick.AddListener(() =>
        {
            string ThisSceneName = "Lever" + GameControler.Instance.LeverInfo.ToString();
            SceneManager.LoadScene(ThisSceneName);

        });
        NextLeverButton.onClick.AddListener(() =>
        {
            if (GameControler.Instance.lever == 16)
            {
                SceneManager.LoadScene("BoxS1");
            }
            else
            {
                GameControler.Instance.lever++;
                string ThisSceneName = "Lever" + GameControler.Instance.LeverInfo.ToString();
                SceneManager.LoadScene(ThisSceneName);
            }
        });
        int Reward = 50 * LeverControler.Instance.StarCounter;
        RewardMoney.text = Reward.ToString();
        CurMoney.text=(SaveLoad.Instance.Log.Money += Reward).ToString();
        StarExist = Resources.Load<Sprite>("Sprite/Star");
        for(int i = 0; i < LeverControler.Instance.StarCounter; i++)
        {
            StarGroup.GetChild(i).GetComponent<Image>().sprite = StarExist;
        }
    }
    private void Start()
    {
        SaveLoad.Instance.Log.Progess.UpdateStarsLog(LeverControler.Instance.StarCounter, GameControler.Instance);
        AllUI.SetActive(false);
        StartCoroutine(InitCatton());
    }
    IEnumerator InitCatton()
    {
        RectTransform LeftRT = LeftCarton.GetComponent<RectTransform>();
        RectTransform RightRT = RightCarton.GetComponent<RectTransform>();
        int Temp = Screen.width;
        while (true)
        {
            LeftRT.anchoredPosition += Vector2.right * Temp * Time.deltaTime;
            RightRT.anchoredPosition += Vector2.left * Temp * Time.deltaTime;
            if (LeftRT.anchoredPosition.x >= RightRT.anchoredPosition.x)
            {
                LeftRT.anchoredPosition = Vector2.zero;
                RightRT.anchoredPosition = Vector2.zero;
                AllUI.SetActive(true);
                yield break;
            }
            yield return null;
        }
    }
}
