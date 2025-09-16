using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Assembly_CSharp
{
    internal class Demo
    {
    }

    // this will bư replace by interface
    public class Health : MonoBehaviour
    {
        public float currentHelth;
        public void TakeDamage(float dmg)
        {
            currentHelth -= dmg;
        }
    }

    // Damage type
    public enum DamageType
    {
        Normal,
        Fire,
        Poison,
        Ice,
    }

    public class Character : MonoBehaviour
    {
        public Health health;
        public DamageCalculator DamageCalculator;
        public float critChance;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            var character = collision.GetComponent<Character>();
            if (character != null)
            {
                character.DamageCalculator.DealDamage(this, character, DamageType.Normal, 10);
            }

        }
    }

    public abstract class BaseDamageDealer : MonoBehaviour
    {
        public abstract DamageType Type { get; }
        public abstract void DealDamage(float damage, Health target);
        public void DealDamage(Character attacker, Character defender, float damage)
        {
            var rd = UnityEngine.Random.Range(0, 100);
            if (rd < attacker.critChance)
            {
                damage *= 1.5f;
            }

            defender.health.TakeDamage(damage);
        }
    }

    public class NormalDamageDealer : BaseDamageDealer
    {
        public override DamageType Type => DamageType.Normal;
        public override void DealDamage(float damage, Health target)
        {
            //
            target.TakeDamage(damage);
        }
    }

    public class FireDamageDealer : BaseDamageDealer
    {
        public override DamageType Type => DamageType.Fire;
        public override void DealDamage(float damage, Health target)
        {
            target.TakeDamage(damage * 1.2f);
        }
    }


    public class DamageCalculator : MonoBehaviour
    {
        public BaseDamageDealer[] DmaageDealer;
        public Health Health;

        public void DealDamage(Character ataacker, Character defender, DamageType type, float dmg)
        {
            foreach (var dealder in DmaageDealer)
            {
                if (dealder.Type == type)
                {

                    //dealder.DealDamage(dmg, Health);
                    dealder.DealDamage(ataacker, defender, dmg);
                }
            }
        }
    }

}
