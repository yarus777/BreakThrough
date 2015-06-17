using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Block.Type
{
    class MetalBlock : Block
    {
        public override BlockInfo.BlockType Type
        {
            get { return BlockInfo.BlockType.Metal;}
        }
    }
}
