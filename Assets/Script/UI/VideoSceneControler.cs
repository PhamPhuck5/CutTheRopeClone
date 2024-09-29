using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoSceneControler : MonoBehaviour
{
    [SerializeField] Button FeatureButton;
    [SerializeField] Button CollectionButton;
    [SerializeField] Button BackButton;
    [SerializeField] GameObject FeatureGroup;
    [SerializeField] GameObject CollectionGroup;

    private void Awake()
    {
        FeatureButton.onClick.AddListener(FeatureOn);
        CollectionButton.onClick.AddListener(CollectionOn);
        BackButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Start");
        });
    }
    private void FeatureOn()
    {
        FeatureGroup.SetActive(true);
        CollectionGroup.SetActive(false);
    }
    private void CollectionOn()
    {
        FeatureGroup.SetActive(false);
        CollectionGroup.SetActive(true);
    }
}
