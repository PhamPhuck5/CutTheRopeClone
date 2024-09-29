using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] int QuantitiLinks;
    [SerializeField] GameObject LinkPrefab;
    private Rigidbody2D PreviousRb;
    private GameObject Link;
    private GameObject PreLink;
    [SerializeField] int NO;
    private void Awake()
    {
        PreLink = this.gameObject;
        PreviousRb = GetComponent<Rigidbody2D>();
        for (int i=0; i< QuantitiLinks; i++)
        {
            Link = Instantiate(LinkPrefab, transform);
            Link.transform.position = PreLink.transform.position+Vector3.down*0.12f;
            HingeJoint2D Joint = Link.GetComponent<HingeJoint2D>();
            Joint.connectedBody = PreviousRb;
            Joint.anchor = Vector2.up*0.7f;
            Joint.connectedAnchor = Vector2.zero;
            PreviousRb = Link.GetComponent<Rigidbody2D>();
            PreLink = Link;
        }
    }
    private void Start()
    {
        HingeJoint2D CandyHJ = Candy.Instance.CandyHJ[NO];
        CandyHJ.connectedBody = PreviousRb;
        CandyHJ.connectedAnchor = Vector2.zero;
        CandyHJ.anchor = Vector2.zero;
    }
    public void OnDestroyLink()
    {
        Candy.Instance.CandyHJ[NO].enabled = false;
    }
}
