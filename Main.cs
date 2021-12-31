using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace HPDisplay
{
    public class Main : Plugin<Config>
    {
        EventHandlers handlers = new();
        public static Main Instance { get; set; }

        public override void OnEnabled()
        {
            Instance = this;
            handlers = new();
            Player.ChangingRole += handlers.OnPlayerChangingRoles;
            Player.Hurting += handlers.OnHurting;
            Server.WaitingForPlayers += handlers.OnWaitingForPlayers;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            handlers = null;
            Player.ChangingRole -= handlers.OnPlayerChangingRoles;
            Player.Hurting -= handlers.OnHurting;
            Server.WaitingForPlayers -= handlers.OnWaitingForPlayers;
            base.OnDisabled();
        }
    }
}