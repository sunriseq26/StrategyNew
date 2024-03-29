﻿using TMPro;
using UnityEngine;
using Zenject;
using UniRx;
using System;
using Abstractions;
using UnityEngine.UI;

namespace UserControlSystem.UI.Presenter
{
    public class TopPanelPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuGo;

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
            {
                var t = TimeSpan.FromSeconds(seconds);
                _inputField.text = string.Format("{0:D2}:{1:D2}",
                    t.Minutes,
                    t.Seconds);
            });

            _menuButton.OnClickAsObservable().Subscribe(_ => _menuGo.SetActive(true));
        }
    }

}