using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

//動的追加の実験用スクリプト
public class RayInteractableSpawner : MonoBehaviour
{
    void Start()
    {
        GameObject target = GameObject.Find("Cube2"); // 対象のGameObject

        RayInteractableFactory.Create(target, wrapper =>
        {
            wrapper.WhenSelect.AddListener(() =>
            {
                Debug.Log("Selected!");
            });

            wrapper.WhenUnselect.AddListener(() =>
            {
                Debug.Log("Unselected!");
            });

            wrapper.WhenHover.AddListener(() =>
            {
                Debug.Log("Hovered!");
            });
        });

    }

}