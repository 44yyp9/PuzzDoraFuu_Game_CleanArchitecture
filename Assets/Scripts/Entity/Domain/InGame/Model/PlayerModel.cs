using UnityEngine;
using Entity.Domain.InGame.Character.Player;

namespace Entity.Domain.InGame.Model
{
    public class PlayerModel
    {
        public PlayerHPModel PlayerHpModel { get; private set; }
        public PlayerStatusModel PlayerStatusModel { get; private set; }
        public PlayerModel()
        {
            PlayerHpModel=new PlayerHPModel();
            PlayerStatusModel=new PlayerStatusModel();
        }
    }
}