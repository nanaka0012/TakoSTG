using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    abstract class EnemyBase : CollidableObject
    {
        protected Player player;

        protected int score = 0;
        GameScene scene;

        public EnemyBase(Player player, GameScene scene)
        {
            this.player = player;

            this.scene = scene;
        }

        protected void CollideWithBullet()
        {
            foreach (var o in Layer.Objects.OfType<PlayerBullet>())
            {
                if (IsCollide(o))
                {
                    scene.AddScore(score);
                    o.Dispose();
                    Dispose();
                    break;
                }
            }
        }

        protected override void OnDispose()
        {

        }

    }
}
