using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IntroWindow : MonoBehaviour
{

    [SerializeField] 
    private Button enterMainViewButton;
    [SerializeField] 
    private TextMeshProUGUI infoMessage;
    [SerializeField] 
    private Image virtuplexLogo;
    [SerializeField] 
    private Image fadeOutImage;


    private void Start()
    {
        enterMainViewButton.onClick.AddListener(OnClickEnterMainViewButton);


        Sequence s = DOTween.Sequence();
        s.Append(infoMessage.transform.DOShakeScale(1, new Vector3(0.15f, 0.1f, 0),1, 90, true));
        s.SetLoops(-1, LoopType.Restart);

        Sequence logoSeq = DOTween.Sequence();
        logoSeq.Append(virtuplexLogo.DOFade(0.2f, 1f));
        logoSeq.SetLoops(-1, LoopType.Yoyo);

    }
    

    private void OnClickEnterMainViewButton()
    {
        fadeOutImage.DOColor(Color.black, 0.6f).OnComplete(OnCompleteFadeOut);
    }

    private void OnCompleteFadeOut ()
    {
        Destroy(gameObject);
    }
}
