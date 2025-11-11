using Entity.Domain.InGame.Core;
using UnityEngine;

namespace Entity.Domain.InGame.Puzzle 
{
    public class Combo
    {
        public DropType Drop {  get;private set; }
        public int DropCount {  get;private set; }
        public Combo(DropType drop, int dropCount)
        {
            Drop = drop;
            DropCount = dropCount;
        }
    }
}