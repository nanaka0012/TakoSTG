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

        IEnumerator<object> coroutine;

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
            coroutine = Move();
        }

        protected override void OnUpdate()
        {
            CollideWithBullet();
            coroutine?.MoveNext();

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

        IEnumerator<object> Move()
        {
            asd.Vector2DF speed = new asd.Vector2DF(6, 0);
            for (int i = 0; i < 20; i++)
            {
                Position += speed;
                yield return null;
            }

            for (int i = 0; i < 75; i++)
            {
                yield return null;
            }

            for (int i = 0; i < 60; i++)
            {
                Angle = (float)Math.Sin(Math.PI * 0.5f * i / 1.5f) * 5;
                    yield return null;
            }

            for (int i = 0; i < 75; i++)
            {
                Position += speed;
                yield return null;
            }

            speed.Degree += 3;

            do
            {
                var g = speed / 64;
                g.Degree += 90;
                speed += g;
                Position += speed;
                yield return null;

            } while (Math.Abs(speed.Degree) > 3);

            while (true)
            {
                Position += speed;
                yield return null;
            }
        }

    }

}
