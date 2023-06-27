using MonkeBadges.Behaviours;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace MonkeBadges.Utils
{
    internal class AssetbundleLoading : MonoBehaviour
    {
        public static void LoadBundle(GameObject Badge)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MonkeBadges.Resources.badgebundle");
            AssetBundle assetBundle = AssetBundle.LoadFromStream(manifestResourceStream);

            Badge = Instantiate<GameObject>(assetBundle.LoadAsset<GameObject>("BadgesMod"));
            assetBundle.Unload(false);

            Badge.transform.SetParent(GameObject.Find("rig/body/gorillachest").transform, false);
            Badge.AddComponent<ImagePlacer>();
        }
    }
}
