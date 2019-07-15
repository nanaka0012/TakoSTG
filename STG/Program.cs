using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class Program
    {


        static void Main(string[] args)
        { 
            // Altseedを初期化する。
            asd.Engine.Initialize("Tako_STG", 640, 480, new asd.EngineOption());

            //開発時はリソースフォルダまでのルートを指定してリソースを読み込む
            asd.Engine.File.AddRootDirectory("Resources/");

            //リリースする時はパッケージ化したリソースを読み込む
            //asd.Engine.File.AddRootPackageWithPassword("Resources.pack", "1234");

            var scene = new TitleScene();

            asd.Engine.ChangeScene(scene);

            // Altseedのウインドウが閉じられていないか確認する。
            while (asd.Engine.DoEvents())
            {
                // Altseedを更新する。
                asd.Engine.Update();

                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                {
                    break;
                }
            }

            // Altseedの終了処理をする。
            asd.Engine.Terminate();

        }
    }
}
