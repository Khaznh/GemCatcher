using DG.Tweening;
using UnityEngine;

public class IntroMove : MonoBehaviour
{
    [SerializeField] private RectTransform introText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sequence se = DOTween.Sequence();
        se.Append(introText.DOAnchorPos(new Vector3(0, 0, 0), 2f));
        se.Append(introText.DOAnchorPos(new Vector3(901, 0, 0), 2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
