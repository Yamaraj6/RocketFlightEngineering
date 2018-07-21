using UnityEngine;

namespace Extensions
{
    public static class TransformExtensions
    {
        public static void SetActiveAllChildren(this Transform transform, bool value)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(value);

                SetActiveAllChildren(child, value);
            }
        }
    }
}