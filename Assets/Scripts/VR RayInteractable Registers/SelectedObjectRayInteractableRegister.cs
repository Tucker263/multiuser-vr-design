using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


// SlectedObjectのRayInteractableを登録するクラス
public static class SelectedObjectRayInteractableRegister
{

    public static void Register(string registerTag)
    {
        List<GameObject> objList = PhotonObjectFinder.FindObjectsWithTag(registerTag);

        foreach (GameObject obj in objList)
        {
            AddWhenSelect(obj);
        }
    }


    public static void RegisterFromObj(GameObject obj)
    {
        AddWhenSelect(obj);
    }


    // WhenSelectイベントを登録
    private static void AddWhenSelect(GameObject obj)
    {
        SelectedObjectClickHandler selectedObjectClickHandler = obj.GetComponent<SelectedObjectClickHandler>();

        RayInteractableFactory.Create(obj, wrapper =>
        {
            wrapper.WhenSelect.AddListener(() =>
            {
                selectedObjectClickHandler.Trigger();
            });

        });

    }

}
