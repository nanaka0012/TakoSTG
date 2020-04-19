using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class PlayerBullet : CollidableObject
    {
        readonly float speed = 6.0f;

        protected override void OnAdded()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("PlayerBullet.png");
            SetRadius();

        }

        protected override void OnUpdate()
        {
            Move();

            if (Position.Y < -Texture.Size.Y/2.0f)
            {
                Dispose();
            }
        }

        private void Move()
        {
            Position += new asd.Vector2DF(1.0f, 0.0f) * speed;
        }

    }
}
