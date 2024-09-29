using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [SerializeField] GameObject UnlockedLever;
    [SerializeField] GameObject LockedLever;
    [SerializeField] Transform ChoseLeverBroad;
    [SerializeField] Sprite EmptyStar;
    [SerializeField] Button ShopButton;
    [SerializeField] Button VipMembershipButton;
    [SerializeField] Button CollectionButton;
    [SerializeField] Button BackButton;
    [SerializeField] Sprite[] BoxCoverImage = new Sprite[3];
    [SerializeField] Image CoverImage;
    private void Awake()
    {
        ShopButton.onClick.AddListener(Shop);
        VipMembershipButton.onClick.AddListener(VipMembership);
        CollectionButton.onClick.AddListener(Collection);
        BackButton.onClick.AddListener(Back);
    }
    private void Start()
    {
        CoverImage.sprite = BoxCoverImage[GameControler.Instance.BoxNO - 1];
        List<int> Temp = SaveLoad.Instance.Log.Progess.StarNumberinLever[GameControler.Instance.Season - 1, GameControler.Instance.BoxNO - 1];
        Temp.Add(0);
        for(int i=0; i < Temp.Count; i++)
        {
            GameObject Item = Instantiate(UnlockedLever, ChoseLeverBroad);
            Item.GetComponent<ChooseLever>().Init(i + 1, Temp[i], EmptyStar);
        }
        for(int j = Temp.Count; j< 16; j++)
        {
            GameObject Item = Instantiate(LockedLever, ChoseLeverBroad);
        }
    }
    private void Shop() { }
    private void VipMembership()
    {
        SceneManager.LoadScene("BuyVipMembership");
    }
    private void Collection()
    {
        SceneManager.LoadScene("Collection");
    }
    private void Back()
    {
        SceneManager.LoadScene("ChoseSeason");
    }
}
