using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// メニューバーのオンオフ処理
// アタッチ対象: OVRInput MenuBar Togglerオブジェクト
public class OVRInputMenuBarToggler : MonoBehaviour
{
    private GameObject _menuBarCanvas;

    private void Start()
    {
        _menuBarCanvas = GameObject.FindWithTag(Tags.Get(TagID.MenuBarCanvas));
        if (_menuBarCanvas == null) Debug.LogError($"{Tags.Get(TagID.MenuBarCanvas)} が見つかりません");

    }

    private void Update()
    {
        ToggleMenuBar();
    }

    public void ToggleMenuBar()
    {
        // メニューバーのオンオフ処理(Startボタン)
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            GameObject obj = _menuBarCanvas;
            obj.SetActive(!obj.activeSelf);
        }
        
    }

}