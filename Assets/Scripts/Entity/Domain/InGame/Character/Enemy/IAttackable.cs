using UnityEngine;

namespace Entity.Domain.InGame.Character.Enemy
{
    //使用するか迷ってる
    //現在は未使用
    public interface IAttackable<T>
    {
        public void Attack(T taget);
    }
}