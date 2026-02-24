/*using Oculus.Interaction;
using Oculus.Interaction.Surfaces;
using UnityEngine;
using UnityEngine.Events; // ← 必須
using System.Reflection;

public static class RayInteractableFactory
{
    public static GameObject Create(GameObject target)
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

        // Inject InteractableView
        SetPrivateField(wrapper, "_interactableView", rayInteractable);

        // --- Awake / Start を手動で呼ぶ ---
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

        // --- イベントリスナー登録（例）---
        wrapper.WhenSelect.AddListener(() =>
        {
            Debug.Log($"🟥 RayInteractable selected on '{target.name}'");
            target.GetComponent<Renderer>().material.color = Color.red;

        });

        // --- OnEnable を発火させるため enabled にする ---
        wrapper.enabled = true;

        return target;
    }

    // private フィールドに値を設定
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

    // private プロパティに値を設定
    private static void SetPrivateProperty(object obj, string propertyName, object value)
    {
        var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (prop != null && prop.CanWrite)
        {
            prop.SetValue(obj, value);
        }
    }

    // private メソッドを呼び出す
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

    // UnityEvent が null の場合は初期化
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
            var instance = System.Activator.CreateInstance(unityEventType);
            field.SetValue(obj, instance);
        }
    }
}
*/