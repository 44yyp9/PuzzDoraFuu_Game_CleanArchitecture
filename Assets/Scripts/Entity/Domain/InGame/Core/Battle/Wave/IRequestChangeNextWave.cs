using System.Collections.Generic;
using Entity.Domain.InGame.Character.Enemy;
using UnityEngine;

namespace Entity.Domain.InGame.Battle.Wave
{
    public interface IRequestChangeNextWave
    {
        public void RequestChangeNextWave(List<Enemy> enemies);
    }
}