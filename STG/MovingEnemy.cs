using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class MovingEnemy : EnemyBase
    {

        readonly float power = 0.5f;
        readonly float speed = 2.0f;

        asd.Vector2DF velocity = new asd.Vector2DF(0.0f, 0.0f);

        asd.Vector2DF dir;

        public MovingEnemy(Player player, GameScene scene)
            : base(player, scene)
        {
            score = 100;
        }

        protected override void OnAdded()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Enemy1.png");
            SetRadius();
        }

        protected override void OnUpdate()
        {
            Move();
            CollideWithBullet();


            if ((Position.Y > Texture.Size.Y / 2.0f) && OutOfWindow())
            {
                Dispose();
            }
        }

        void Move()
        {
            if (player.IsAlive)
            {
                if (Position.Y < player.Position.Y)
                {
                    dir = (player.Position - Position);
                    dir.Normalize();
                }

                velocity += dir * power;

                var v = velocity;
                v.Normalize();

                Position += v * speed;
            }
        }
    }
}
