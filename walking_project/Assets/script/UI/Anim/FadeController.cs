using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] string _fadeInClip;
    [SerializeField] string _fadeOutClip;

    void Start()
    {
        _animator.Play(_fadeInClip);
    }

    public void StartFadeIn()
    {
        GetComponent<Image>().enabled = true;
    }

    // �t�F�[�h�C���I����̏���
    public void EndFadeInAnimation()
    {
        gameObject.SetActive(false);
    }
}