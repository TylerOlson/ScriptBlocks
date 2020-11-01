using Microsoft.Xna.Framework;
using ScriptBlocks.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace ScriptBlocks
{
	public class ScriptBlocks : Mod
	{
        public static ScriptBlocks instance;
        public static bool scriptUiVisibility = false;

        internal UserInterface scriptInterface;
        internal ScriptUI scriptUI;

        private GameTime _lastUpdateUiGameTime;

        public override void Load()
        {
            instance = this;
            if (!Main.dedServ)
            {
                scriptInterface = new UserInterface();

                scriptUI = new ScriptUI();
                scriptUI.Activate();
            }
        }

        public override void Unload()
        {
            //scriptUI?.SomeKindOfUnload(); // If you hold data that needs to be unloaded, call it in OO-fashion
            scriptUI = null;
            base.Unload();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (scriptInterface?.CurrentState != null)
            {
                scriptInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && scriptInterface?.CurrentState != null)
                        {
                            scriptInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }

        internal void ShowScriptUI()
        {
            scriptInterface?.SetState(scriptUI);
            scriptUiVisibility = true;
        }

        internal void HideScriptUI()
        {
            scriptInterface?.SetState(null);
            scriptUiVisibility = false;
        }
    }
}