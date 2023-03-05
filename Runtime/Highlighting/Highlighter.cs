using System.Collections;
using UnityEngine;

namespace KalkuzSystems.Gameplay
{
    /// <summary>
    ///   Base class for indicating objects.
    /// </summary>
    public abstract class Highlighter : MonoBehaviour
    {
        protected Coroutine highlightCoroutine;

        [ColorUsage(true, true)] [SerializeField]
        protected Color highlightColor = Color.white;
        
        [SerializeField, Header("Emission")] protected bool useEmissionColor;
        [SerializeField] protected string emissionEnabledKeyword = "_EMISSION";
        [SerializeField] protected string emissionColorName = "_EmissionColor";

        public void Highlight()
        {
            if (highlightCoroutine != null) StopCoroutine(highlightCoroutine);
            highlightCoroutine = StartCoroutine(HighlightCoroutine());
        }
        
        public void StopHighlight()
        {
            if (highlightCoroutine != null) StopCoroutine(highlightCoroutine);
            highlightCoroutine = null;
        }

        protected abstract IEnumerator HighlightCoroutine();
    }
}