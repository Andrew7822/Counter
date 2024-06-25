using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnClicked : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    private Coroutine _coroutine;

    private int _count;
    private bool _isWorking;

    private void Awake()
    {
        _isWorking = false;
        _count = 0;
        _text.text = _count.ToString();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ButClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ButClick);
    }

    private IEnumerator Counting()
    {
        while (_isWorking)
        {
            _count++;
            _text.text = _count.ToString();

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ButClick()
    {
        if (_isWorking == false)
        {
            _isWorking = true;
            _coroutine = StartCoroutine(Counting());
        }
        else
        {
            _isWorking = false;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }
}