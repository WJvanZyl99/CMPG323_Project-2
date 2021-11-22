using Database.Models;

namespace WebApp.Pages.LoggedInViews.SharedParts
{
    public class Block
    {
        public Image img;
        public string path;
        public bool hasDelete = false;
        public bool showShared = false;
        public bool hasShare = false;
        public bool hasSharedWith = false;
        public bool hasShareDelete = false;

        public Block(Image image, string path)
        {
            this.img = image;
            this.path = path;
        }
    }
}
