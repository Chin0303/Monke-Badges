using UnityEngine;
using System.IO;

namespace MonkeBadges.Behaviours
{
    internal class ImagePlacer : MonoBehaviour
    {

        void Start()
        {
            PlaceImagesOnBadge();
        }

        public void PlaceImagesOnBadge()
        {
            GameObject squareBadge = GameObject.Find("PhotoSquare");
            GameObject circleBadge = GameObject.Find("PhotoCircle");

            string folderPath = Path.Combine(Path.GetDirectoryName(typeof(ImagePlacer).Assembly.Location), "BadgePhotos");
            string squareBadgeImagePath = Path.Combine(folderPath,"SquareBadge.png");
            string circleBadgeImagePath = Path.Combine(folderPath,"CircleBadge.png");

            Texture2D squareBadgeImage = LoadImage(squareBadgeImagePath);
            Texture2D circleBadgeImage = LoadImage(circleBadgeImagePath);

            PlaceImageOnBadge(squareBadge, squareBadgeImage);
            PlaceImageOnBadge(circleBadge, circleBadgeImage);
        }

        Texture2D LoadImage(string path)
        {
            byte[] imageData = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            return texture;
        }

        void PlaceImageOnBadge(GameObject badge, Texture2D image)
        {
            Renderer badgeRenderer = badge.GetComponent<Renderer>();
            Material badgeMaterial = badgeRenderer.material;
            badgeMaterial.mainTexture = image;
        }

    }
}
