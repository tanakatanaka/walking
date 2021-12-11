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
        _animator.Play(_fadeInClip);
    }

    // �t�F�[�h�C���I����̏���
    public void EndFadeInAnimation()
    {
        gameObject.SetActive(false);
    }
}