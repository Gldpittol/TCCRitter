using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _mpdBGClips;
    [SerializeField] private AudioClip[] _dgBGClips;

    [SerializeField] private AudioSource _bgSound;
    [SerializeField] private AudioSource _fxSound;

    private IEnumerator _bgCoroutine;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        _bgSound = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MagePoliceDepartment")
        {
            PlayMPDMusic();
        }
        else
        {
            PlayDGMusic();
        }
    }

    public void PlayFX(AudioClip clip)
    {
        _fxSound.PlayOneShot(clip);
    }

    public void PlayMPDMusic()
    {
        if (_bgCoroutine != null)
        {
            StopCoroutine(_bgCoroutine);
        }

        _bgCoroutine = PlayMPDBG();
        StartCoroutine(_bgCoroutine);
    }

    private IEnumerator PlayMPDBG()
    {
        _bgSound.clip = _mpdBGClips[0];
        _bgSound.Play();
        while (true)
        {
            if (!_bgSound.isPlaying)
            {
                _bgSound.clip = _mpdBGClips[UnityEngine.Random.Range(1, _mpdBGClips.Length)];
                _bgSound.Play();
            }

            yield return null;
        }
    }

    public void PlayDGMusic()
    {
        if (_bgCoroutine != null)
        {
            StopCoroutine(_bgCoroutine);
        }
        _bgCoroutine = PlayDGBG();
        StartCoroutine(_bgCoroutine);
    }

    private IEnumerator PlayDGBG()
    {
        _bgSound.clip = _dgBGClips[0];
        _bgSound.Play();
        while (true)
        {
            if (!_bgSound.isPlaying)
            {
                _bgSound.clip = _dgBGClips[UnityEngine.Random.Range(1, _dgBGClips.Length)];
                _bgSound.Play();
            }

            yield return null;
        }
    }

}
