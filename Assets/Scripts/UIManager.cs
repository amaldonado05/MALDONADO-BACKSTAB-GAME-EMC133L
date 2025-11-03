using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public Text toast;
    Coroutine routine;

    public void ShowToast(string msg)
    {
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(Show(msg));
    }

    IEnumerator Show(string msg)
    {
        toast.text = msg;
        toast.canvasRenderer.SetAlpha(1f);
        yield return new WaitForSeconds(1f);
        toast.CrossFadeAlpha(0f, 0.5f, false);
    }
}
