namespace BoardGame.Engine
{
    public static class DirectionExtensions
    {
        public static Direction Next(this Direction direction)
        {
            var newDirection = (int)direction + 1;
            return newDirection > (int)Direction.West ? Direction.North : (Direction)newDirection;
        }

        public static Direction Previous(this Direction direction)
        {
            var newDirection = (int)direction - 1;
            return newDirection < (int)Direction.North ? Direction.West : (Direction)newDirection;
        } 

        public static string ToShortString(this Direction direction)
        {
            return direction.ToString().Substring(0, 1);
        }
    }
}
