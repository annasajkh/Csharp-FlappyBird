using System;
namespace FlappyBird
{
    public class Rect
    {
        public float X { set; get; }
        public float Y { set; get; }
        public float Width { set; get; }
        public float Height { set; get; }
        float rightSide, leftSide, topSide, bottomSide;

        public Rect(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void UpdateBounds()
        {
            rightSide = X + Width * 0.5f;
            leftSide = X - Width * 0.5f;
            topSide = Y + Height * 0.5f;
            bottomSide = Y - Height * 0.5f;
        }

        public bool Intersects(Rect otherRect)
        {
            UpdateBounds();
            otherRect.UpdateBounds();
            return (rightSide > otherRect.leftSide &&
                leftSide < otherRect.rightSide &&
                bottomSide < otherRect.topSide &&
                topSide > otherRect.bottomSide);

        }
    }
}
