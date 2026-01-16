using Entity.Domain.InGame.Character;
using UnityEngine;

namespace Entity.Domain.InGame.Core
{
    /// <summary>
    /// static‚Å’ñ‹Ÿ‚µ‚½‚¢‚à‚Ì‚ð‚±‚±‚É
    /// </summary>
    public static class CoreContext
    {
        private static ActorGroup actorGroup;
        public static IProvideCharacterable IProvideCharacter => actorGroup;
        public static IRemoveCharacterable IRemoveCharacter => actorGroup;
        public static ISetActorable ISetActor => actorGroup;
        public static void Initialize()
        {
            actorGroup = new ActorGroup();
        }
    }
}