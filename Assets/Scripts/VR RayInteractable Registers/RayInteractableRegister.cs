using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


// RayInteractableを登録するクラス
public static class RayInteractableRegister
{

    public static void Register()
    {
        // ドアのRayInteractableを登録
        DoorRayInteractableRegister.Register(Tags.Get(TagID.Door));
        // 窓のRayInteractableを登録
        WindowRayInteractableRegister.Register(Tags.Get(TagID.Window));
        // 家の照明のRayInteractableを登録
        HouseLightingRayInteractableRegister.Register(Tags.Get(TagID.HouseLighting));

        // 家の天井、内壁、床、階段、外壁、屋根、家具のRayInteractableを登録
        List<string> selectedTag = new List<string>()
        {
            Tags.Get(TagID.Ceiling),
            Tags.Get(TagID.InnerWall),
            Tags.Get(TagID.Floor),
            Tags.Get(TagID.Stairs),
            Tags.Get(TagID.OuterWall),
            Tags.Get(TagID.Roof),
            Tags.Get(TagID.Furniture)
        };
        foreach (string tag in selectedTag)
        {
            SelectedObjectRayInteractableRegister.Register(tag);
        }

    }

}
