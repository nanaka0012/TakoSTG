using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class EnemyBullet : CollidableObject
    {
        readonly float speed = 3.0f;

        asd.Vector2DF dir;

        public EnemyBullet(asd.Vector2DF dir)
        {
            this.dir = dir;
            this.dir.Normalize();
        }


        protected override void OnAdded()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyBullet.png");
            SetRadius();
            radius -= 1;
        }

        protected override void OnUpdate()
        {
            Move();
            if (OutOfWindow())
            {
                Dispose();
            }
        }

        private void Move()
        {
            Position += dir * speed;
        }

    }
}
