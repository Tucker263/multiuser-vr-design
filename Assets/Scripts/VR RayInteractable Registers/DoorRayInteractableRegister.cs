using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


// ドアのRayInteractableを登録するクラス
public static class DoorRayInteractableRegister
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
        DoorClickHandler doorClickHandler = obj.GetComponent<DoorClickHandler>();

        RayInteractableFactory.Create(obj, wrapper =>
        {
            wrapper.WhenSelect.AddListener(() =>
            {
                doorClickHandler.Trigger();
            });

        });

    }

}
