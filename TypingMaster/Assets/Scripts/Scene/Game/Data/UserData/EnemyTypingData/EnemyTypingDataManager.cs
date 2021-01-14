﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

/// <summary>
/// 対戦相手のデータ管理クラス
/// </summary>
public class EnemyTypingDataManager : TypingDataBase {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private DownloadEnemyTypingData downloadETD;
    
    /*---------- ↓TypingDataBaseで設定 ----------*/
    /*----- Game中情報関連 -----*/
    // public string enteredSentence;      // 入力済み文字列(灰色表示部分)
    // public string notEnteredSentence;   // 未入力文字列(通常表示用)
    // public string jpSentence;           // 現在の問題の日本語文
    // public string hrSentence;           // 現在の問題のひらがな文
    /*----- Game中記録関連 -----*/
    // public int CorrectTypeNum;      // 正解タイプ数
    // public int MisTypeNum;          // ミスタイプ数
    // public int CorrectTaskNum;      // 正解問題数
    // public double TotalTypingTime;  // 総合経過時間
    // public double Kpm;              // KPM
    // public double Accuracy;         // 正答率
    // public bool isFinishedGame;     // ゲーム終了判定
    
    
    private void Start() {
        
        // 対戦相手のユーザーID
        if(PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1) == 1) {

            UserNum = 2;
        }
        else {

            UserNum = 1;
        }
    }

    public void DownloadEnemyTypingData() {
        
        ConnectServer(UserNum, roomId);
    }

    
    /// <summary>
    /// サーバに接続してデータを取得する処理
    /// </summary>
    /// <param name="userId">ユーザーID</param>
    /// <param name="roomId">部屋ID</param>
    private void ConnectServer(int userNum, string roomId) {
        
        StartCoroutine(downloadETD.DownloadETD(userNum, roomId));
    }
}