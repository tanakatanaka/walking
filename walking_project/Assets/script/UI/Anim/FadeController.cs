using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] string _fadeInClip;
    [SerializeField] string _fadeOutClip;

    public void StartFadeIn()
    {
        this.gameObject.SetActive(true);
        _animator.Play(_fadeInClip);
    }

    public void StartFadeOut()
    {
        this.gameObject.SetActive(true);
        _animator.Play(_fadeOutClip);
    }

    // �t�F�[�h�C���I����̏���
    public void EndFadeInAnimation()
    {
        gameObject.SetActive(false);
    }
}