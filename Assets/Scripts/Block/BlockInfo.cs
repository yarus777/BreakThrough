

using UnityEngine;

namespace Assets.Scripts.Block
{
    public class BlockInfo: MonoBehaviour
    {
        public enum BlockType
        {   
            Metal,
            Stone,
            Wood
        }

        public BlockType Type;
        public int X;
        public int Y;

    }
}
