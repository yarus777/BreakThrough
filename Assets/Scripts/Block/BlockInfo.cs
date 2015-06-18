

namespace Assets.Scripts.Block
{
    public class BlockInfo
    {
        public enum BlockType
        {   Metal,
            Stone,
            Wood
        }

        public BlockType Type;
        public int X;
        public int Y;

        /*public BlockInfo(int x, int y, BlockType type)
        {
          X = x;
          Y = y;
          Type = type;
        }*/
    }
}
