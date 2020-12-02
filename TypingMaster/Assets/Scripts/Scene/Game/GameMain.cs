﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの切り替え等

public class GameMain : MainBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GameActionManager ga;
    [SerializeField] private GameConfig gc;
    [SerializeField] private InitGameMethod playerInit;    // PlayerInitGame(Player初期化処理)

    // ゲームシーンの状態
    public enum GAME_STATE {

        INIT,       // 初期化処理(オンライン時はここで相手の準備完了を待つ)
        COUNTDOWN,  // ゲームスタートカウントダウン
        TYPING,     // タイピングゲーム部分
        RESULT      // 結果画面
    };
    public GAME_STATE gState;

    //// Scene遷移時動作 ////
    protected override void Start(){

        // 全Scene共通部分
        base.Start();

        // タイピングシーンの状態初期化
        gState = GAME_STATE.INIT;

        // エフェクトのロード
        //effectManager.Load("ef001");

        // サウンドのロード
        //soundManager.Load(SOUND_TYPE.BGM, "bgm002");
        //soundManager.Load(SOUND_TYPE.BGM, "bgm101");

        // サウンドの再生
        //soundManager.Play(SOUND_TYPE.BGM, "bgm002", true);
    }

    void Update() {

        switch (status) {

            // 未フェードイン時(シーン遷移時)
            case SCENE_STATE.START:
                
                if(fadeManager.CheckFadeEnd() == true) {

                    status = SCENE_STATE.PLAY;
                }
                break;

            // シーン中動作
            case SCENE_STATE.PLAY:

                switch (gState) {

                    // 初期化処理
                    case GAME_STATE.INIT:

                        if(gc.gMode == GameConfig.GAME_MODE.SOLO) {

                            playerInit.InitSoloGame();
                            gState = GAME_STATE.COUNTDOWN;
                        }
                        else if (gc.gMode == GameConfig.GAME_MODE.MULTI) {

                            playerInit.InitMultiGame();

                            ///// 対戦相手の準備待ち /////
                            
                            gState = GAME_STATE.COUNTDOWN;
                        }
                        else {  // 大会モード(実装出来たら)

                            ///// 対戦相手の準備待ち /////

                            gState = GAME_STATE.COUNTDOWN;
                        }
                        break;
                    case GAME_STATE.COUNTDOWN:

                        ///// カウントダウン処理 /////
                        
                        // 遷移処理
                        ga.isInputValid = true;
                        gState = GAME_STATE.TYPING;
                        break;
                    case GAME_STATE.TYPING:

                        ga.GameSceneTypingCheck();
                        break;
                    case GAME_STATE.RESULT:

                        status = SCENE_STATE.CLEAR;
                        break;
                }
                break;

            // ゲームクリア時
            case SCENE_STATE.CLEAR:

                // ファンファーレが鳴り終わった時
                if(soundManager.IsPlayBGM() == false) {

                    fadeManager.FadeOutPlay();
                    status = SCENE_STATE.CHANGE_WAIT;
                }
                break;

            // Scene遷移待機時
            case SCENE_STATE.CHANGE_WAIT:

                if(fadeManager.CheckFadeEnd() == true) {

                    // GameScene用サウンドの破棄
                    Release();
                    // Scene遷移
                    SceneManager.LoadScene("ResultScene");
                }
                break;
        }

        //// GameSceneでのみ扱うResourceの破棄メソッド ////
        void Release() {

            soundManager.Release(SoundManager.SOUND_TYPE.BGM, "bgm002");
            soundManager.Release(SoundManager.SOUND_TYPE.BGM, "bgm101");

            // CreateEffectで生成したEffectの全消去
            effectManager.AllDestroyEffect();
            effectManager.Release("ef001");
        }
    }
}