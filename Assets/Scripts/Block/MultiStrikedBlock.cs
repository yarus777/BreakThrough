using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Assets.Scripts.Block;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Block
{
   abstract class MultiStrikedBlock : Block
    {
       [Serializable]

       public class BlockLevelData
       {
           public int Level;
           public Sprite Texture;
       }

       public BlockLevelData[] LevelsData;

       private int level;

       private int Level
       {
           get { return level; }
           set
           {
               level = value;
               var sprite = LevelsData.FirstOrDefault(x => x.Level == level);
               if (sprite !=null)
               {
                  texture.sprite = sprite.Texture; 
               }
               
           }
       }

       private Image texture;

       protected abstract int InitialLevel { get; }

       public override void Init(BlockInfo blockInfo)
       {
           base.Init(blockInfo);
           texture = GetComponent<Image>();
           Level = InitialLevel;
           
       }

       protected override void OnBallTouched()
       {
           Level--;
           if (Level < 0)
           {
               OnBlockStriked();
           }

       }
    }
}
