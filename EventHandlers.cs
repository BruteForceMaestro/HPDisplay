using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.Collections.Generic;
using MEC;
using System;

namespace HPDisplay
{
    class EventHandlers
    {
        public void OnPlayerChangingRoles(ChangingRoleEventArgs ev)
        {
            Timing.RunCoroutine(HPInfo(ev.Player));
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            Timing.RunCoroutine(HPInfo(ev.Target));
        }
        public void OnWaitingForPlayers()
        {
            Timing.RunCoroutine(HPLoop());
        }
        private IEnumerator<float> HPLoop() // this is ugly af, but i have to do this, i haven't found an event that gets called when hp or ahp increases. (adrenaline, medkit, etc.)
        {
            while (true)
            {
                foreach (Player player in Player.List)
                {
                    Timing.RunCoroutine(HPInfo(player));
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }

        private IEnumerator<float> HPInfo(Player player)
        {
            yield return Timing.WaitForOneFrame; // The information about the HP is not fully processed on the call of these events, so we need to wait a frame for things to make sense. 
            if (player == null || !player.IsAlive)
            {
                yield break;
            }
            string info = string.Empty;
            if (Main.Instance.Config.DisplayAHP && player.ArtificialHealth > 0)
            {
                info = $"{Math.Round(player.ArtificialHealth)}/{player.MaxArtificialHealth} AHP\n";
            }
            info += $"{Math.Round(player.Health)}/{player.MaxHealth} HP";
            player.CustomInfo = info;
        }
    }
}
