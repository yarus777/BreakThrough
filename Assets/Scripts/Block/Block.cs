using UnityEngine;

namespace Assets.Scripts.Block
{
    public abstract class Block : MonoBehaviour {
        void Start () {
	
        }

        void Update () {
	
        }

        protected virtual void OnBallTouched()
        {
            OnBlockStriked();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.GetComponent<Ball.Ball>() != null)
                OnBallTouched();
        }

        public delegate void OnStrikedDelegate(Block block);

        public event OnStrikedDelegate Striked;
        protected void OnBlockStriked()
        {
            if (Striked != null)
            {
                Striked(this);
            }
        }

        public  abstract BlockInfo.BlockType Type { get; }

        public virtual void Init(BlockInfo blockInfo)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(blockInfo.X, blockInfo.Y);
        }
    }

}
