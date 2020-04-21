using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class Player : CollidableObject
    {
        readonly float speed = 3.0f;

        int fireCount = 0;

        public Player()
        {
            Position = new asd.Vector2DF(asd.Engine.WindowSize.X / 3, asd.Engine.WindowSize.Y / 2);
        }

        protected override void OnAdded()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Player.png");
            CenterPosition = Texture.Size.To2DF() / 2.0f;
            SetRadius();
            radius -= 15;
        }

        protected override void OnUpdate()
        {
            Move();
            Fire();

            CollideWithEnemy();

            CollideWithBullet();
        }

        private void Move()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(1.2f, 0.0f) * speed;
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(-1.2f, 0.0f) * speed;
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(0.0f, -1.2f) * speed;
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(0.0f, 1.2f) * speed;
            }

            var ws = asd.Engine.WindowSize.To2DF();
            var size = Texture.Size.To2DF();

            var pos = Position;

            pos.X = asd.MathHelper.Clamp(pos.X, ws.X-size.X/2.0f, size.X/2.0f);
            pos.Y = asd.MathHelper.Clamp(pos.Y, ws.Y-size.Y/2.0f, size.Y/2.0f);

            Position = pos;

        }

        private void Fire()
        {
            fireCount++;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push && fireCount > 20)
            {
                // Play SE
                asd.SoundSource shot = asd.Engine.Sound.CreateSoundSource("shot.wav", true);

                int id_shot = asd.Engine.Sound.Play(shot);

                var bullet = new PlayerBullet
                {
                    Position = Position + new asd.Vector2DF(40, 0)
                };

                Layer.AddObject(bullet);
                fireCount = 0;
            }
        }

        protected void CollideWithEnemy()
        {
            foreach (var o in Layer.Objects.OfType<EnemyBase>())
            {
                if (IsCollide(o))
                {
                    Dispose();
                    break;
                }
            }
        }

        protected void CollideWithBullet()
        {
            foreach (var o in Layer.Objects.OfType<EnemyBullet>())
            {
                if (IsCollide(o))
                {
                    o.Dispose();
                    Dispose();
                    break;
                }
            }
        }
    }
}
