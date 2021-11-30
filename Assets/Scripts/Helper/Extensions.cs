using UnityEngine;

namespace Cool_UI.Assets.Scripts.Helper
{
    public static class Extensions
    {
        /// <summary>
        /// Clears all sub game objects of the game object
        /// </summary>
        /// <param name="transform">Transform to clean</param>
        /// <returns></returns>
        public static Transform Clear(this Transform transform)
        {
            foreach (Transform child in transform)
                Object.Destroy(child.gameObject);

            return transform;
        }

    }
}