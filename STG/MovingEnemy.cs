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

        int count = 0;

        public MovingEnemy(Player player, GameScene scene)
            : base(player, scene)
        {
            score = 100;
        }

        protected override void OnAdded()
        {
            dir = (player.Position - Position).Normal;
            Texture = asd.Engine.Graphics.CreateTexture2D("Enemy1.png");
            CenterPosition = Texture.Size.To2DF() / 2;
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
            count++;
        }

        void Move()
        {
            if (player.IsAlive)
            {
                var actuaryDir = dir;
                actuaryDir.Degree += (float)Math.Sin(count / 100f) * 30;
                Position += actuaryDir * speed;
            }
        }
    }
}
