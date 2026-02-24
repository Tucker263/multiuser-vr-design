using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


// 家の照明のRayInteractableを登録するクラス
public static class HouseLightingRayInteractableRegister
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
        HouseLightingClickHandler houseLightingClickHandler = obj.GetComponent<HouseLightingClickHandler>();

        RayInteractableFactory.Create(obj, wrapper =>
        {
            wrapper.WhenSelect.AddListener(() =>
            {
                houseLightingClickHandler.Trigger();
            });

        });

    }

}
