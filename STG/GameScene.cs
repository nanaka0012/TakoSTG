using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class GameScene : asd.Scene
    {
        asd.Layer2D backlayer;
        asd.Layer2D gameLayer;
        asd.Layer2D uiLayer;

        Player player;
        Random Random { get; } = new Random();

        asd.TextObject2D scoreText;

        int count = 0;
        int rareEnemyCount = 0;

        int score = 0;

        bool isSceneChanging = false;

        public void AddScore(int value)
        {
            score += value;
        }
        
        protected override void OnRegistered()
        {
            backlayer = new asd.Layer2D();
            AddLayer(backlayer);

            var back = new asd.TextureObject2D
            {
                Texture = asd.Engine.Graphics.CreateTexture2D("Back.png")
            };

            backlayer.AddObject(back);

            //敵と自分がいるレイヤーを追加
            gameLayer = new asd.Layer2D();
            AddLayer(gameLayer);

            //背景になるレイヤーを追加
            uiLayer = new asd.Layer2D();
            AddLayer(uiLayer);

            //プレイヤーのインスタンスを追加する
            player = new Player();
            gameLayer.AddObject(player);

            //スコア表示の為のテキスト仕様の定義
            scoreText = new asd.TextObject2D
            {
                Font = asd.Engine.Graphics.CreateDynamicFont(
                    "mplus-1m-medium.ttf", 30, new asd.Color(255, 255, 255), 
                    0, new asd.Color(0, 0, 0, 0)
                    )
            };

            //スコア表示を背景レイヤーに追加する
            uiLayer.AddObject(scoreText);

        }

        protected override void OnUpdated()
        {
            count++;
            rareEnemyCount++;

            AddEnemy();

            scoreText.Text = "Score: " + score.ToString();
            scoreText.Position = new asd.Vector2DF(10, 670);

        }


        void AddEnemy()
        {
            if (player.IsAlive)
            {
                if (count % 180 == 0)
                {
                    var enemy = new MovingEnemy(player, this)
                    {
                        Position = new asd.Vector2DF(1060, Random.Next(100, 620))
                    };
                    gameLayer.AddObject(enemy);
                }

                if (count % 180 == 0)
                {
                    var enemy = new MovingEnemy(player, this)
                    {
                        Position = new asd.Vector2DF(960, Random.Next(-100, -80))
                    };
                    gameLayer.AddObject(enemy);
                }

                if (count % 180 == 0)
                {
                    var enemy = new MovingEnemy(player, this)
                    {
                        Position = new asd.Vector2DF(960, Random.Next(820, 840))
                    };
                    gameLayer.AddObject(enemy);
                }

                if (count % 250 == 0)
                {
                    var enemy = new TamaEnemy(player, this)
                    {
                        Position = new asd.Vector2DF(Random.Next(900, 1060), Random.Next(-200, -100))
                    };
                    gameLayer.AddObject(enemy);
                }

                if (Random.Next(0, 500) == 0 && rareEnemyCount >= 720)
                {
                    var enemy = new RareEnemy(player, this, new asd.Vector2DF(0.0f, 1.0f))
                    {
                        Position = new asd.Vector2DF(-50.0f, 100.0f)
                    };
                    gameLayer.AddObject(enemy);
                    rareEnemyCount = 0;
                }

                if (count >= 900)
                {
                    count++;
                }
            }
            else
            {
                if (!isSceneChanging)
                {
                    isSceneChanging = true;
                    asd.Engine.ChangeSceneWithTransition(new GameoverScene(), new asd.TransitionFade(0.5f, 0.5f));
                }
            }

        }

    }
}
