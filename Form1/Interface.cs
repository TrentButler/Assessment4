using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{
    public interface IDamageable
    {   
        float EntitySpeed
        {
            get; set;
        }
        float Attack
        {
            get;
        }
        string Name
        {
            get;
        }
        bool Dead
        {
            get;
            set;
        }
        int MaxHealth
        {
            get; set;
        }

        void TakeDamage(float damageDelt);
       
    }

    public interface IDamager
    {
        void DealDamage(IDamageable damageable);
    }

    public interface ILeveler
    {
        void AddExp(int howMuch);
    }

}
