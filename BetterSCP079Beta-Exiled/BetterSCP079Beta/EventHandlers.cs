using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace BetterSCP079Beta
{
    public class EventHandlers
    {
        public bool isCooldownNuck;
        public bool isCooldownLights;
        internal void PlayerSpawn(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ShowHint(Plugin.Instance.Config.scp_startmsg, Plugin.Instance.Config.scp_timestartmsg);
            }
        }
        public IEnumerator<float> Nuke()
        {
            Warhead.IsLocked = false;
            Warhead.Stop();
            Cassie.Message(Plugin.Instance.Config.canceled_cassie);
            isCooldownNuck = true;

            yield return Timing.WaitForSeconds(Plugin.Instance.Config.canceled_cooldown);

            isCooldownNuck = false;
        }

        public IEnumerator<float> LightOff()
        {
            Generator079.Generators[0].ServerOvercharge(Plugin.Instance.Config.blackout_timeovercharge, false);
            Cassie.Message(Plugin.Instance.Config.blackout_cassie, true, true);

            isCooldownLights = true;

            yield return Timing.WaitForSeconds(Plugin.Instance.Config.blackout_cooldown);

            isCooldownLights = false;
        }
    }
}
