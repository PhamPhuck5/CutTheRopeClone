using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoseSeason : MonoBehaviour
{
    [SerializeField] Button Season1;
    [SerializeField] Button Season2;
    [SerializeField] Button Season3;
    [SerializeField] Button BackButton;
    [SerializeField] GameObject Notice;
    [SerializeField] Button NoticeButton;
    [SerializeField] Button LoadVidButton;

    private void Start()
    {
        Season1.onClick.AddListener(GoSeason1);
        Season2.onClick.AddListener(UpNotice);
        Season3.onClick.AddListener(UpNotice);
        BackButton.onClick.AddListener(Back);
        NoticeButton.onClick.AddListener(OffNotice);
        LoadVidButton.onClick.AddListener(LoadVid);
    }
    private void GoSeason1()
    {
        GameControler.Instance.Season = 1;
        SceneManager.LoadScene("Season1");
    }
    private void UpNotice()
    {
        Notice.SetActive(true);
    }
    private void Back()
    {
        SceneManager.LoadScene("Start");
    }
    private void OffNotice()
    {
        Notice.SetActive(false);
    }
    private void LoadVid()
    {
        SceneManager.LoadScene("Video");
    }
}
