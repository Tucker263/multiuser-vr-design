/*using Oculus.Interaction;
using Oculus.Interaction.Surfaces;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;
using System;

public static class RayInteractableFactory
{
    /// <summary>
    /// 指定の GameObject に対し RayInteractable を構成し、イベント登録用コールバックを受け付ける。
    /// </summary>
    /// <param name="target">RayInteractable を付与する対象 GameObject</param>
    /// <param name="eventSetup">InteractableUnityEventWrapper に対してイベントを登録するためのコールバック</param>
    /// <returns>設定済み GameObject</returns>
    public static GameObject Create(GameObject target, Action<InteractableUnityEventWrapper> eventSetup = null)
    {
        if (target == null)
        {
            Debug.LogError("Target GameObject is null");
            return null;
        }

        // --- Collider ---
        BoxCollider boxCollider = target.GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider component not found on target");
            return null;
        }

        // --- ColliderSurface ---
        var surface = target.GetComponent<ColliderSurface>();
        if (surface == null)
        {
            surface = target.AddComponent<ColliderSurface>();
        }
        surface.InjectCollider(boxCollider);

        // --- RayInteractable ---
        var rayInteractable = target.GetComponent<RayInteractable>();
        if (rayInteractable == null)
        {
            rayInteractable = target.AddComponent<RayInteractable>();
        }

        SetPrivateField(rayInteractable, "_surface", surface);
        SetPrivateProperty(rayInteractable, "Surface", surface);

        // --- InteractableUnityEventWrapper ---
        var wrapper = target.GetComponent<InteractableUnityEventWrapper>();
        if (wrapper == null)
        {
            wrapper = target.AddComponent<InteractableUnityEventWrapper>();
        }

        SetPrivateField(wrapper, "_interactableView", rayInteractable);

        // --- Awake / Start を手動で呼び出し ---
        CallPrivateMethod(surface, "Awake");
        CallPrivateMethod(surface, "Start");

        CallPrivateMethod(rayInteractable, "Awake");
        CallPrivateMethod(rayInteractable, "Start");

        CallPrivateMethod(wrapper, "Awake");
        CallPrivateMethod(wrapper, "Start");

        // --- UnityEvent をすべて初期化 ---
        EnsureUnityEvent(wrapper, "_whenHover");
        EnsureUnityEvent(wrapper, "_whenUnhover");
        EnsureUnityEvent(wrapper, "_whenSelect");
        EnsureUnityEvent(wrapper, "_whenUnselect");
        EnsureUnityEvent(wrapper, "_whenInteractorViewAdded");
        EnsureUnityEvent(wrapper, "_whenInteractorViewRemoved");
        EnsureUnityEvent(wrapper, "_whenSelectingInteractorViewAdded");
        EnsureUnityEvent(wrapper, "_whenSelectingInteractorViewRemoved");

        // --- 外部から渡されたイベント登録処理を実行 ---
        eventSetup?.Invoke(wrapper);

        // OnEnable を呼ぶため enabled にする
        wrapper.enabled = true;

        return target;
    }

    private static void SetPrivateField(object obj, string fieldName, object value)
    {
        var field = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field == null)
        {
            Debug.LogWarning($"Field '{fieldName}' not found on {obj.GetType().Name}");
            return;
        }
        field.SetValue(obj, value);
    }

    private static void SetPrivateProperty(object obj, string propertyName, object value)
    {
        var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (prop != null && prop.CanWrite)
        {
            prop.SetValue(obj, value);
        }
    }

    private static void CallPrivateMethod(object obj, string methodName)
    {
        var method = obj.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (method != null)
        {
            method.Invoke(obj, null);
        }
        else
        {
            Debug.LogWarning($"{obj.GetType().Name} にメソッド {methodName} が見つかりません。");
        }
    }

    private static void EnsureUnityEvent(object obj, string fieldName)
    {
        var field = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field == null)
        {
            Debug.LogWarning($"Field '{fieldName}' not found on {obj.GetType().Name}");
            return;
        }

        var value = field.GetValue(obj);
        if (value == null)
        {
            var unityEventType = field.FieldType;
            var instance = Activator.CreateInstance(unityEventType);
            field.SetValue(obj, instance);
        }
    }
}*/
