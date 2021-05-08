using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace BetterSCP079Beta
{
    public class EventHandlers
    {
        public bool isCooldown;
        internal void PlayerSpawn(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ShowHint(Plugin.Instance.Config.scp_message);
            }
        }
        public IEnumerator<float> Nuke()
        {
            Warhead.IsLocked = false;
            Warhead.Stop();
            Cassie.Message(Plugin.Instance.Config.canceled_cassie);
            isCooldown = true;

            yield return Timing.WaitForSeconds(Plugin.Instance.Config.canceled_cooldown);

            isCooldown = false;
        }
    }
}
