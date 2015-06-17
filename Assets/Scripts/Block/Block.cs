using UnityEngine;

namespace Assets.Scripts.Block
{
    public abstract class Block : MonoBehaviour {
        void Start () {
	
        }

        void Update () {
	
        }

        public  abstract BlockInfo.BlockType Type { get; }

        public void Init(BlockInfo blockInfo)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(blockInfo.X, blockInfo.Y);
        }
    }

}
