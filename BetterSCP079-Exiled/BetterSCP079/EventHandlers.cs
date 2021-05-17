using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace BetterSCP079
{
    public class EventHandlers
    {
        public bool isCooldownNuckOff;
        public bool isCooldownNuckOn;
        public bool isCooldownLights;
        internal void PlayerSpawn(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ShowHint(Plugin.Instance.Config.scp_startmsg, Plugin.Instance.Config.scp_timestartmsg);
            }
        }
        public IEnumerator<float> NukeOff()
        {
            Warhead.IsLocked = false;
            Warhead.Stop();
            Cassie.Message(Plugin.Instance.Config.canceled_cassie);
            isCooldownNuckOff = true;

            yield return Timing.WaitForSeconds(Plugin.Instance.Config.canceled_cooldown);

            isCooldownNuckOff = false;
        }

        public IEnumerator<float> NukeOn()
        {
            if (Plugin.Instance.Config.activate_alphalock == true)
            {
                Warhead.IsLocked = true;
            }
            Warhead.Start();
            Cassie.Message(Plugin.Instance.Config.activate_cassie);
            isCooldownNuckOn = true;

            yield return Timing.WaitForSeconds(Plugin.Instance.Config.activate_cooldown);

            isCooldownNuckOn = false;
        }

        public IEnumerator<float> LightOff()
        {
            foreach (Player D in Player.List.Where(p => p.Role == RoleType.Scp079))
            {
                if (Plugin.Instance.Config.blackout_lvlup == true)
                {
                    if (Plugin.Instance.Config.blackout_lvl < D.ReferenceHub.scp079PlayerScript.NetworkcurLvl)
                    {
                        Plugin.Instance.Config.blackout_timeovercharge += Plugin.Instance.Config.blackout_timeinc;
                    }
                }
            }
            Generator079.Generators[0].ServerOvercharge(Plugin.Instance.Config.blackout_timeovercharge, false);
            Cassie.Message(Plugin.Instance.Config.blackout_cassie, true, true);

            isCooldownLights = true;

            yield return Timing.WaitForSeconds(Plugin.Instance.Config.blackout_cooldown);

            isCooldownLights = false;
        }
    }
}
