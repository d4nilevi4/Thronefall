namespace Thronefall.Common
{
    public enum CollisionLayer
    {
        Ground = 8,
        Enemy = 9,
        Hero = 10,
    }
    
    public static class CollisionExtensions
    {
        public static int AsMask(this CollisionLayer layer) =>
            1 << (int)layer;
    }
}