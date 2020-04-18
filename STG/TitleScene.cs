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
            // 音声ファイルを読み込む。BGMの場合、第２引数を false に設定することで、再生しながらファイルを解凍することが推奨されている。
            asd.SoundSource bgm1 = asd.Engine.Sound.CreateSoundSource("bgm.ogg", false);

            // 音声のループを有効にする。
            bgm1.IsLoopingMode = true;

            // 音声のループ始端を1秒に、ループ終端を6秒に設定する。
            bgm1.LoopStartingPoint = 0f;
            bgm1.LoopEndPoint = bgm1.Length;

            // 音声を再生する。
            int id_bgm1 = asd.Engine.Sound.Play(bgm1);

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
