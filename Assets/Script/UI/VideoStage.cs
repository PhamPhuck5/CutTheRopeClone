using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoStage : MonoBehaviour
{
    public Text Collection;
    public Text Featured;
    [SerializeField] Button CollectionButton;
    [SerializeField] Button FeaturedButton;
    [SerializeField] GameObject CollectionInfo;
    [SerializeField] GameObject FeaturedInfo;

    private void Awake()
    {
        LanguageSO temp = GameControler.Instance.CurLanguage;
        Collection.text = temp.Collection;
        Featured.text = temp.Featured;
        CollectionButton.onClick.AddListener(OpenCollection);
        FeaturedButton.onClick.AddListener(OpenFeatured);
    }
    private void OpenCollection()
    {
        CollectionInfo.SetActive(true);
        FeaturedInfo.SetActive(false);
    }
    private void OpenFeatured()
    {
        CollectionInfo.SetActive(false);
        FeaturedInfo.SetActive(true);
    }
}
