using System;
using System.Drawing;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DungeonsAndAlligators
{
    class TheGoodStuff
    {
        public enum GoodTypes
        {
            MainChar, SilverCoins, GoldBars, SecretMap, SecretExit
        }
        private int currentType;
        private Bitmap pieceImage;
        private Rectangle targetRectangle = new Rectangle(0, 0, 75, 75); 

        public TheGoodStuff(int type, int xLocation, int yLocation, Bitmap sourceImage) {
            currentType = type; 
            targetRectangle.X = xLocation;
            targetRectangle.Y = yLocation;
            
            pieceImage = sourceImage.Clone(new Rectangle(type*75, 0, 75, 75), System.Drawing.Imaging.PixelFormat.DontCare);
        }

        public void Draw(Graphics graphicsObject)
        {
            graphicsObject.DrawImage(pieceImage, targetRectangle);
        }

        public Rectangle GetBounds()
        {
            return targetRectangle;
        }

        public void SetLocation(int xLocation, int yLocation)
        {
            targetRectangle.X = xLocation;
            targetRectangle.Y = yLocation;
        }
    }
}
