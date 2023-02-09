using System.Collections;
using UnityEngine;

namespace KalkuzSystems.Gameplay
{
  public sealed class Hitstop : MonoBehaviour
  {
    private static Hitstop instance;
    public static Hitstop Instance => instance;

    private Coroutine doCoroutine;
    private float timePreviously;

    private void Awake()
    {
      if (instance == null) instance = this;
      else Destroy(this);
    }

    public void Do(float duration, float timeScale)
    {
      if (doCoroutine != null)
      {
        StopCoroutine(doCoroutine);
        Time.timeScale = timePreviously;
      }

      doCoroutine = StartCoroutine(DoCoroutine(duration, timeScale));
    }

    private IEnumerator DoCoroutine(float duration, float timeScale)
    {
      timePreviously = Time.timeScale;

      Time.timeScale = timeScale;
      yield return new WaitForSeconds(duration);
      Time.timeScale = timePreviously;

      doCoroutine = null;
    }
  }
}