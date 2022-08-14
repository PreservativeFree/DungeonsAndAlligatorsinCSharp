using System;
using System.Drawing;

namespace DungeonsAndAlligators
{
    class TheBadStuff
    {
        public enum BadTypes
        {
            BlackAlligator, DarkAlligator
        }
        private int currentType;
        private Bitmap pieceImage;
        private Rectangle targetRectangle = new Rectangle(0, 0, 75, 75); 

        public TheBadStuff(int type, int xLocation, int yLocation, Bitmap sourceImage) {
            currentType = type; 
            targetRectangle.X = xLocation;
            targetRectangle.Y = yLocation;
            //Alligator Image will be at position 0.
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
