﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// URL保管用クラス
/// </summary>
public static class ServerUrl {

    //*----- 基本URL -----*//
    public const string BASE_URL = "http://ec2-18-181-251-215.ap-northeast-1.compute.amazonaws.com/";
    //*----- サーバ接続判定用 -----*//
    public const string JUDGE_CONECTION_URL   = BASE_URL + "API/judgeConnection.php";
    //*----- タイトルシーン内 -----*//
    public const string SIGNIN_URL = BASE_URL + "API/signIn.php";
    public const string SIGNUP_URL = BASE_URL + "API/signUp.php";
    //*----- メニューシーン用 -----*//
    public const string MAKE_FRIENDROOM_URL = BASE_URL + "MATCHING/mkFriendRoom.php";
    public const string ROOM_SEARCH_URL = BASE_URL + "MATCHING/searchFriendRoom.php";
    //*----- ゲーム内 -----*//
    public const string ENEMY_SYNC_URL        = BASE_URL + "REALTIME/sendTypingData.php";
    public const string PLAYER_TYPINGDATA_URL = BASE_URL + "REALTIME/uploadPlayerData.php";
    public const string PLAYER_RESULT_URL     = BASE_URL + "";
    //*----- ランキング用 -----*//
}
