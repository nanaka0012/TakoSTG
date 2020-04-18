using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class RareEnemy : EnemyBase
    {
        readonly float speed = 4.0f;

        asd.Vector2DF dir;

        bool HasEnteredWindow = false;

        public RareEnemy(Player player, GameScene scene, asd.Vector2DF dir)
            : base(player, scene)
        {
            this.dir = dir;

            score = 500;
        }

        protected override void OnAdded()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Enemy3.png");
            CenterPosition = Texture.Size.To2DF() / 2;
            SetRadius();
        }

        protected override void OnUpdate()
        {
            CollideWithBullet();
            Move();

            if (HasEnteredWindow)
            {
                if (OutOfWindow())
                {
                    Dispose();
                }
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
            Position += dir * speed;
        }

    }

}
