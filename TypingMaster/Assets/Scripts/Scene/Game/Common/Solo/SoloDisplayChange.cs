﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloDisplayChange : MonoBehaviour {

    /*----- Objectの取得(Inspectorで設定) -----*/
    [SerializeField] private GameObject init;
    [SerializeField] private GameObject CountDown;
    [SerializeField] private GameObject Typing;
    [SerializeField] private GameObject Result;
    /*----- Scriptの取得(Inspectorで設定) -----*/
    [SerializeField] private SoloMain sm;

    /// <summary>
    /// 画面の遷移処理
    /// </summary>
    public void SoloDisplayChangeMethod() {

        switch (sm.gState) {

            case SoloMain.GAME_STATE.INIT:
                Debug.Log("GAME_STATE:INIT Start");

                init.SetActive(true);
                CountDown.SetActive(false);
                Typing.SetActive(false);
                Result.SetActive(false);
                break;

            case SoloMain.GAME_STATE.COUNTDOWN:
                Debug.Log("GAME_STATE:COUNTDOWN Start");

                init.SetActive(false);
                CountDown.SetActive(true);
                Typing.SetActive(false);
                Result.SetActive(false);
                break;

            case SoloMain.GAME_STATE.TYPING:
                Debug.Log("GAME_STATE:TYPING Start");

                init.SetActive(false);
                CountDown.SetActive(false);
                Typing.SetActive(true);
                Result.SetActive(false);
                break;

            case SoloMain.GAME_STATE.RESULT:
                Debug.Log("GAME_STATE:RESULT Start");

                init.SetActive(false);
                CountDown.SetActive(false);
                Typing.SetActive(false);
                Result.SetActive(true);
                break;

            default:
                break;
        }

        sm.isChanged = true;
    }
}