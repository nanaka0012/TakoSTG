using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{

    class TamaEnemy : EnemyBase
    {
        readonly float speed = 2.0f;

        int fireCount = 0;

        asd.Vector2DF dir;

        bool HasEnteredWindow = false;

        public TamaEnemy(Player player, GameScene scene, asd.Vector2DF dir)
            : base(player, scene)
        {
            this.dir = dir;

            score = 150;
        }

        protected override void OnAdded()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Enemy2.png");
            SetRadius();
        }

        protected override void OnUpdate()
        {
            CollideWithBullet();
            Fire();
            Move();

            if(HasEnteredWindow)
            {
                if(OutOfWindow())
                {
                    Dispose();
                }
            }
            else
            {
                if(!OutOfWindow())
                {
                    HasEnteredWindow = true;
                }
            }
        }

        void Move()
        {
            Position += dir * speed;
        }

        void Fire()
        {
            if (player.IsAlive)
            {
                fireCount++;
                if (fireCount == 60)
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
