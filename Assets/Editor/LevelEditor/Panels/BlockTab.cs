using System.Collections.Generic;
using System.Linq;

using Assets.Editor.Tabs;
using Assets.Scripts.Block;
using UnityEngine;

namespace Assets.Editor.LevelEditor.Panels {
    class BlockTab : Tab {
        private readonly Texture[] _textures;
        private List<BlockInfo> _blocks; 

        public BlockTab(Dictionary<BlockInfo.BlockType, Texture> blockTextures)
            : base("Blocks") {
                _textures = blockTextures.Select(x => x.Value).ToArray();
        }

        private int _brush = 0;

        public override void Draw() {
            _brush = GUILayout.SelectionGrid(_brush, _textures, 6, GUILayout.Height(100));
            if (GUILayout.Button("Add")) {
                _blocks.Add(new BlockInfo() { Type = (BlockInfo.BlockType)_brush });
            }
        }

        public void Init(List<BlockInfo> blocks) {
            _blocks = blocks;
        }
    }
}
