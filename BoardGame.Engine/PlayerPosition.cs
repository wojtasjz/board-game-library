using System;

namespace BoardGame.Engine
{
    public class PlayerPosition
    {
        public int X { get; }

        public int Y { get; }

        public Direction Direction { get; }

        public PlayerPosition(int x, int y, Direction direction)
        {
            if (!Enum.IsDefined(typeof(Direction), direction))
            {
                throw new ArgumentException("Invalid direction");
            }

            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public override bool Equals(object obj)
        {
            return Equals(this, obj as PlayerPosition);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ this.X;
                result = (result * 397) ^ this.Y;
                result = (result * 397) ^ (int) this.Direction;
                return result;
            }
        }

        public static bool operator ==(PlayerPosition a, PlayerPosition b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(PlayerPosition a, PlayerPosition b)
        {
            return !Equals(a, b);
        }

        private static bool Equals(PlayerPosition position, PlayerPosition other)
        {
            if (ReferenceEquals(position, other))
            {
                return true;
            }

            if ((object)position == null || (object)other == null)
            {
                return false;
            }

            return position.X == other.X && position.Y == other.Y && position.Direction == other.Direction;
        }
    }
}
