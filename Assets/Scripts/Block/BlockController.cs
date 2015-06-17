using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Block
{
    public class BlockController : MonoBehaviour
    {

        public Block[] BlocksPrefabs;
        private List<Block> blockList; 

        private void Start()
        {

        }

        private void Update()
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
            }
        }
    }
}
