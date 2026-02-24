using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


// 窓のRayInteractableを登録するクラス
public static class WindowRayInteractableRegister
{

    public static void Register(string registerTag)
    {
        List<GameObject> objList = PhotonObjectFinder.FindObjectsWithTag(registerTag);

        foreach (GameObject obj in objList)
        {
            AddWhenSelect(obj);
        }
    }


    // WhenSelectイベントを登録
    private static void AddWhenSelect(GameObject obj)
    {
        WindowClickHandler windowClickHandler = obj.GetComponent<WindowClickHandler>();

        RayInteractableFactory.Create(obj, wrapper =>
        {
            wrapper.WhenSelect.AddListener(() =>

            {
                windowClickHandler.Trigger();
            });

        });

    }

}
