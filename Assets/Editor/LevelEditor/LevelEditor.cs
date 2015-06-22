using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Assets.Editor.LevelEditor.Panels;
using Assets.Scripts;
using Assets.Scripts.Block;
using Assets.Scripts.Serialization.Levels;
using UnityEditor;

using UnityEngine;

namespace Assets.Editor.LevelEditor {
    partial class LevelEditor : EditorWindow {
        [MenuItem("Arcanoid/Level Editor")]
   
        public static void Init() {
            GetWindow<LevelEditor>().title = "Level Editor";
        }

        private Serializer Serializer;
        #region Textures

        private Texture _fieldTexture;
        private Dictionary<BlockInfo.BlockType, Texture> _blockTextures;

        #endregion

        #region Drawing

        private Tabs.Tabs _tabs;
        private LevelInfo _level;

        private LevelInfo Level {
            get {
                return _level;
            }
            set {
                _level = value;
                OnLevelLoaded();
            }
        }

        private string _loadedFilename;
        private FieldPanel _field;
        private BlockTab _blockTab;
        private TaskTab _taskTab;
        private ParametersTab _parmsTab;

        #endregion

        protected void Load() {
            _fieldTexture = Resources.LoadAssetAtPath<Texture>(Consts.FIELD_TEXTURE_PATH);
            var types = Enum.GetValues(typeof(BlockInfo.BlockType)).Cast<BlockInfo.BlockType>();
            _blockTextures = types.ToDictionary(
                type => type,
                type => (Texture)AssetDatabase.LoadAssetAtPath(Consts.BLOCKS_TEXTURES_PATH + type + ".png", typeof(Texture))
            );

            _taskTab = new TaskTab();
            _blockTab = new BlockTab(_blockTextures);
            _parmsTab = new ParametersTab();

            _tabs = new Tabs.Tabs(_parmsTab, _blockTab, _taskTab);
            
            _field = new FieldPanel(Consts.FIELD_WIDTH, Consts.FIELD_HEIGHT, new Vector2(Consts.BLOCK_WIDTH, Consts.BLOCK_HEIGHT), _blockTextures);

            Level = new LevelInfo();
        }

        private void LoadLevel() {
            var filename = EditorUtility.OpenFilePanel("Open level", Consts.LEVELS_PATH, "xml");
            if (string.IsNullOrEmpty(filename)) {
                return;
            }
            try
            {
                _loadedFilename = filename;
               // _loadedFilename = filename.Replace(ROOT_PATH, "");
               // _loadedFilename = _loadedFilename.Replace(".xml", "");
                Level = Serializer.Deserialize<LevelInfo>(_loadedFilename);
            }
            catch (Exception e) {
                EditorUtility.DisplayDialog("Error", "Wrong data format", "OK");
            }
        }

        protected void Save() {
            if (string.IsNullOrEmpty(_loadedFilename)) {
                var filename = EditorUtility.SaveFilePanel("Save as", Consts.LEVELS_PATH, "0", "xml");
                if (string.IsNullOrEmpty(filename)) {
                    return;
                }
                _loadedFilename = filename;
                //_loadedFilename = filename.Replace(ROOT_PATH, "");
                //_loadedFilename = _loadedFilename.Replace(".xml", "");
            }
            Serializer.Serialize(Level, _loadedFilename);
        }

        private void OnLevelLoaded() {
            _field.Init(Level.Blocks);
            _blockTab.Init(Level.Blocks);
            _parmsTab.Init(Level);
        }
    }
}
