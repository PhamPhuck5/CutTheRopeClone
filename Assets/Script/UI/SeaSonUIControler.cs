using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeaSonUIControler : MonoBehaviour
{
    [SerializeField] Button ShopButton;
    [SerializeField] Button VipMembershipButton;
    [SerializeField] Button CollectionButton;
    [SerializeField] Button BackButton;
    private void Awake()
    {
        ShopButton.onClick.AddListener(Shop);
        VipMembershipButton.onClick.AddListener(VipMembership);
        CollectionButton.onClick.AddListener(Collection);
        BackButton.onClick.AddListener(Back);
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
