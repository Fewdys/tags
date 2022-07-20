﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using VRC;
using FewTags;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine.UI;

namespace FewTags
{
    internal class Plate
    {
        public TMPro.TextMeshProUGUI Text4 { get; set; }
        public TMPro.TextMeshProUGUI Text3 { get; set; }
        public TMPro.TextMeshProUGUI Text2 { get; set; }
        public TMPro.TextMeshProUGUI Text { get; set; }
        private GameObject _gameObject4 { get; set; }
        private GameObject _gameObject3 { get; set; }
        private GameObject _gameObject2 { get; set; }
        private GameObject _gameObject { get; set; }
        private RectTransform[] _rectTransforms4 { get; set; }
        private RectTransform[] _rectTransforms3 { get; set; }
        private RectTransform[] _rectTransforms2 { get; set; }
        private RectTransform[] _rectTransforms { get; set; }

        ~Plate() { _rectTransforms = null; _gameObject = null; }
        //This Is A Kinda Aids To Read
        //Theres Definitely Better Ways To Do This But This Should Be Fine For Now
        public Plate(VRC.Player player)
        {
            _gameObject = GameObject.Instantiate(player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_5, player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_0.transform).gameObject;
            _gameObject2 = GameObject.Instantiate(player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_5, player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_0.transform).gameObject;
            _gameObject3 = GameObject.Instantiate(player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_5, player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_0.transform).gameObject;
            _gameObject4 = GameObject.Instantiate(player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_5, player._vrcplayer.field_Public_PlayerNameplate_0.field_Public_GameObject_0.transform).gameObject;
            _gameObject.name = "FewTagsPlate";
            _gameObject2.name = "FewTagsPlate2";
            _gameObject3.name = "FewTagsPlate3";
            _gameObject4.name = "FewTagsPlate4";
            _rectTransforms = _gameObject.GetComponentsInChildren<RectTransform>().Where(x => x.name != "Trust Text" && x.name != "FewTagsPlate").ToArray();
            _rectTransforms2 = _gameObject2.GetComponentsInChildren<RectTransform>().Where(x => x.name != "Trust Text" && x.name != "FewTagsPlate2").ToArray();
            _rectTransforms3 = _gameObject3.GetComponentsInChildren<RectTransform>().Where(x => x.name != "Trust Text" && x.name != "FewTagsPlate3").ToArray();
            _rectTransforms4 = _gameObject4.GetComponentsInChildren<RectTransform>().Where(x => x.name != "Trust Text" && x.name != "FewTagsPlate4").ToArray();
            for (int i = 0; i < _rectTransforms.Length; i++)
            {
                try
                {
                    GameObject.DestroyImmediate(_rectTransforms[i].gameObject);
                    GameObject.DestroyImmediate(_rectTransforms2[i].gameObject);
                    GameObject.DestroyImmediate(_rectTransforms3[i].gameObject);
                    GameObject.DestroyImmediate(_rectTransforms4[i].gameObject);
                }
                catch { }
            }
            _gameObject.SetActive(true);
            _gameObject2.SetActive(true);
            _gameObject3.SetActive(true);
            _gameObject4.SetActive(true);
            _gameObject.transform.localPosition = new Vector3(0, Main.Position, 0);
            _gameObject2.transform.localPosition = new Vector3(0, Main.Position2, 0);
            _gameObject3.transform.localPosition = new Vector3(0, Main.Position3, 0);
            _gameObject4.transform.localPosition = new Vector3(0, Main.PositionMalicious, 0);
            Text = _gameObject.transform.Find("Trust Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            Text2 = _gameObject2.transform.Find("Trust Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            Text3 = _gameObject3.transform.Find("Trust Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            Text4 = _gameObject4.transform.Find("Trust Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            Text.text = "";
            Text2.text = "";
            Text3.text = "";
            Text4.text = "";
        }
    }
}