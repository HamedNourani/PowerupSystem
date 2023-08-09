namespace PowerupSystem
{
    public class Vector2
    {
        private float _x;
        private float _y;

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}