namespace PowerupSystem
{
    public class Vector2
    {
        private float _x;
        private float _y;

        public float X => _x;
        public float Y => _y;

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}