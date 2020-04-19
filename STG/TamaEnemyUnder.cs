using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{

    class TamaEnemyUnder : EnemyBase
    {
        readonly float speed = 2.0f;

        int fireCount = 0;
        float count = (float)Math.PI / 2;

        asd.Vector2DF dir;

        bool HasEnteredWindow = false;

        public TamaEnemyUnder(Player player, GameScene scene)
            : base(player, scene)
        {
            score = 150;
        }

        protected override void OnAdded()
        {
            dir = new asd.Vector2DF(0, 1);
            Texture = asd.Engine.Graphics.CreateTexture2D("Enemy2.png");
            CenterPosition = Texture.Size.To2DF() / 2;
            SetRadius();
        }

        protected override void OnUpdate()
        {
            CollideWithBullet();
            Fire();
            Move();

            if (HasEnteredWindow)
            {
                if (OutOfWindow())
                {
                    Dispose();
                }
                count += 0.006f;
            }
            else
            {
                if (!OutOfWindow())
                {
                    HasEnteredWindow = true;
                }
            }
        }

        void Move()
        {
            var actuaryDir = dir;
            actuaryDir.Degree -= (float)Math.Sin(count) * 30;
            Position -= actuaryDir * speed;
        }

        void Fire()
        {
            if (player.IsAlive)
            {
                fireCount++;
                if (fireCount == 180)
                {
                    fireCount = 0;

                    var dir = player.Position - Position;

                    var bullet = new EnemyBullet(dir)
                    {
                        Position = Position
                    };

                    Layer.AddObject(bullet);

                }
            }
        }


    }
}
