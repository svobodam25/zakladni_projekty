using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame_1
{
    internal class Nepritel_trida
    {
        public float x;
        public float y;
        private float nepritel_rychlost;

        public void Nepritel(float x, float y, float nepritel_rychlost)
        {
            this.x = x;
            this.y = y;
            this.nepritel_rychlost = nepritel_rychlost;
        }

        public void pohnise(float hrac_x, float hrac_y)
        {
            float vzd_x = System.Math.Abs(hrac_x - this.x);
            float vzd_y = System.Math.Abs(hrac_y - this.y);
            float total_vzd = vzd_x + vzd_y;
            float rychlost_x = vzd_x / total_vzd * this.nepritel_rychlost;
            float rychlost_y = vzd_y / total_vzd * this.nepritel_rychlost;
            if (hrac_x >= this.x)
            {
                this.x += rychlost_x;
                if (!(hrac_x >= this.x))
                {
                    this.x = hrac_x;
                }
            }
            else
            {
                this.x -= rychlost_x;
                if (hrac_x >= this.x)
                {
                    this.x = hrac_x;
                }
            }
            if (hrac_y >= this.y)
            {
                this.y += rychlost_y;
                if (!(hrac_y >= this.y))
                {
                    this.y = hrac_y;
                }
            }
            else
            {
                this.y -= rychlost_y;
                if (hrac_y >= this.y)
                {
                    this.y = hrac_y;
                }
            }
        }
    }
}
