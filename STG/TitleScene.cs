using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class TitleScene : asd.Scene
    {
        asd.Layer2D layer;

        bool isSceneChanging = false;

        protected override void OnRegistered()
        {
            layer = new asd.Layer2D();
            AddLayer(layer);

            var titleImage = new asd.TextureObject2D
            {
                Texture = asd.Engine.Graphics.CreateTexture2D("Title.png")
            };

            layer.AddObject(titleImage);

            // Play BGM
            asd.SoundSource bgm = asd.Engine.Sound.CreateSoundSource("Bgm.ogg", true);

            int id_bgm = asd.Engine.Sound.Play(bgm);

        }

        protected override void OnUpdated()
        {
            if(!isSceneChanging)
            {
                if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                {
                    isSceneChanging = true;
                    asd.Engine.ChangeSceneWithTransition(new GameScene(), new asd.TransitionFade(0.5f, 0.5f));
                }
            }
        }
    }
}
