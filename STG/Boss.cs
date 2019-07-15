using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public class Boss : EnemyBase
    {
        public Boss(asd.Vector2DF pos, Player player)
            : base(pos, player)
        {
            //Bossのテクスチャ
            Texture = asd.Engine.Graphics.CreateTexture2D("Boss.png");

            //CenterPositionの上書き
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
        }

        protected override void OnUpdate()
        {
            //カウンタの増加機能を使いまわすために基底クラス(EnemyBase)クラスのOnUpdateを呼び出す
            base.OnUpdate();
        }
    }
}
