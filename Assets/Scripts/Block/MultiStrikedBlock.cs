﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Block
{
   abstract class MultiStrikedBlock : Block
    {
       [SerializeField]

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
               texture.sprite = LevelsData.FirstOrDefault(x => x.Level == level).Texture;
           }
       }

       private Image texture;

       protected abstract int InitialLevel { get; }

       public override void Init(BlockInfo blockInfo)
       {
           base.Init(blockInfo);
           Level = InitialLevel;
           texture = GetComponent<Image>();
       }

       protected override void OnBallTouched()
       {
           Level--;
           if (Level == 0)
           {
               OnBlockStriked();
           }

       }
    }
}
