using System.ComponentModel;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Util
{
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false) // 랩핑 클래스
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false) // 재귀적으로 탐색할지 여부 분기 처리
        {

            // 재귀적으로 탐색하지 않는경우 == 내 자식에 한해서만 탐색하겠다
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform tr = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || tr.name == name)
                {
                    T component = tr.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }

        }
        else
        {
            // 재귀적으로 탐색하는 경우 == 내 자손모두를 탐색하겠다
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null; // 탐색은 해봤지만 해당 컴퍼넌트가 없을경우
    }
}