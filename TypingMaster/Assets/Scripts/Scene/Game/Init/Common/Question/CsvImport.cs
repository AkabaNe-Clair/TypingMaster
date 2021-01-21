﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// CSVファイルから問題文を呼び出すクラス
/// </summary>
public class CsvImport : MonoBehaviour {
    
    TextAsset csvFile;  //　CSVファイル

    /// <summary>
    /// 問題文データセットのCSVファイルを読み込みListの形で返すメソッド
    /// </summary>
    /// <param name="datasetName">取得データセット名</param>
    /// <returns>問題文データセット</returns>
    public List<(string jp, string h)> datasetImport(string datasetName) {

        var tmpList = new List<(string jp, string h)>();

        // ResourceフォルダからCSVファイルの読み込み
        csvFile = Resources.Load("Sentences/" + datasetName) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        // "," で分割しつつ一行ずつ読み込み
        // リストに追加
        while (reader.Peek() != -1) {

            string line = reader.ReadLine();    // 一行ずつ読み込み
            var tmp = line.Split(',');          // "," 区切り(配列の形)
            tmpList.Add((tmp[0], tmp[1]));
        }

        //Debug.Log(tmpList[0]);

        return tmpList;
    }

    /// <summary>
    /// CSV形式のテキストをListの形に変換する処理
    /// </summary>
    /// <param name="csvText">csv形式の文</param>
    /// <returns>問題文データセット</returns>
    public List<(string jp, string h)> CsvtextToList(string csvText) {

        var tmpList = new List<(string jp, string h)>();

        // "\n"(不安があったので"|パイプ"に変更) で分割
        var line = csvText.Split('|');
        for(var i = 0; i < line.Length; i++) {

            var tmp = line[i].Split(',');          // "," 区切り(配列の形)
            tmpList.Add((tmp[0], tmp[1]));
        }

        return tmpList;
    }
}
