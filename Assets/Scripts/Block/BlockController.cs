using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Block
{
    public class BlockController : MonoBehaviour
    {

        public Block[] BlocksPrefabs;
        private List<Block> blockList = new List<Block>();
        private ScoreHandler scorenum;

        void Start()
        {
            
        }

        public void Create(IEnumerable<BlockInfo> blocks)
        {
            foreach (var blockInfo in blocks)
            {
                var prefab = BlocksPrefabs.FirstOrDefault(pref => pref.Type == blockInfo.Type);
                if (prefab == null)
                {
                    continue;
                }
                var blockObject = Instantiate(prefab.gameObject) as GameObject;
                blockObject.transform.parent = transform;
                var block = blockObject.GetComponent<Block>();
                block.Init(blockInfo);

                block.transform.localScale = new Vector3(1, 1, 1);
                blockList.Add(block);
                block.Striked += OnBlockStriked;
                block.Touched += OnBlockTouched;
            }
        }

        private void OnBlockTouched(Block block)
        {
            if (BlockTouched != null)
            {
                BlockTouched(block);
            }
        }


        private void OnBlockStriked(Block block)
        {
            blockList.Remove(block);
            Destroy(block.gameObject);
            if (BlockStriked != null)
            {
                BlockStriked(block);
            }
         
        }

        public event Block.OnStrikedDelegate BlockStriked;
        public event Block.OnStrikedDelegate BlockTouched;
     
    }
}
