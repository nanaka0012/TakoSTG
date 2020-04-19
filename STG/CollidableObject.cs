using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class CollidableObject : asd.TextureObject2D
    {
        public float radius;
        readonly float offset = 300f;

        protected void SetRadius()
        {
            radius = Texture.Size.Y / 2.0f;
        }

        protected bool OutOfWindow()
        {
            var ws = asd.Engine.WindowSize.To2DF();
            var size = Texture.Size.To2DF();

            var outX = (Position.X < size.X / 2.0f - offset) || (ws.X - size.X / 2.0f + offset < Position.X);
            var outY = (Position.Y < size.Y / 2.0f - offset) || (ws.Y - size.Y / 2.0f + offset < Position.Y);

            return (outX || outY);
        }

        protected bool IsCollide(CollidableObject o)
        {
            var distance = (Position - o.Position).SquaredLength;
            
            return ((radius + o.radius) * (radius + o.radius) > distance);
        }
    }
}
