using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// 移動方式をスムーズ移動に切り替えるクラス
// アタッチ対象: UIのボタン
public class SmoothModeChanger : MonoBehaviour
{
    public GameObject smoothLocomotionScript;
    public GameObject teleportInteractorLeft;
    public GameObject teleportInteractorRight;


    public void OnClickChangeStickMode()
    {
        Debug.Log("スムーズ移動に切り替わりました");

        smoothLocomotionScript.SetActive(true);
        teleportInteractorLeft.SetActive(false);
        teleportInteractorRight.SetActive(false);

        // selected状態を解除,この処理がないとメニューバーの表示で二重で動く
        EventSystem.current.SetSelectedGameObject(null);
    }
}
