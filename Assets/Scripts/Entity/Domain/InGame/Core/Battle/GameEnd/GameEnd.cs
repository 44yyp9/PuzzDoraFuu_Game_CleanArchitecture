using UnityEngine;

namespace Entity.Domain.InGame.Battle.Wave
{
    public class GameEnd
    {
        public bool CanGameEnd {  get; private set; }
        public IGameEndable GameEndable { get; private set; }
        public GameEnd(bool canGameEnd, IGameEndable gameEndable)
        {
            CanGameEnd = canGameEnd;
            GameEndable = gameEndable;
        }
    }
}