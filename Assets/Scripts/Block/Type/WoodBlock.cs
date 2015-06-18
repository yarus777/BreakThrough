using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Block.Type
{
    class WoodBlock : MultiStrikedBlock
    {
        public override BlockInfo.BlockType Type
        {
            get { return BlockInfo.BlockType.Wood; }
        }

        protected override int InitialLevel
        {
            get { return 0; }
        }
    }
}
