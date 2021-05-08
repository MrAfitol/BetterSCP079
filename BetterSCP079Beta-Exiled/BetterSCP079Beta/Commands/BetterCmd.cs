﻿using CommandSystem;
using Exiled.API.Features;
using Grenades;
using MEC;
using Mirror;
using RemoteAdmin;
using System;
using System.Linq;
using UnityEngine;

namespace BetterSCP079Beta.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class BetterCmd : ICommand
    {
        public string Command { get; } = "079";

        public string[] Aliases { get; } = new string[] { "079" };

        public string Description { get; } = "Better079";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var plr = sender as PlayerCommandSender;
            Player ply = Player.Get((sender as CommandSender)?.SenderId);

            if (ply.Role != RoleType.Scp079)
            {
                response = "You are not a SCP-079! You can not use this command!";
                return false;

            }

            var args = arguments.Array;
            {
                if (ply.Role == RoleType.Scp079)
                {
                    if (args[1].ToLower().Equals("blackout"))
                    {
                        if (plr.ReferenceHub.scp079PlayerScript.NetworkcurLvl < Plugin.Instance.Config.blackout_lvl)
                        {
                            response = Plugin.Instance.Config.scp_insuflvl;
                            return true;
                        }
                        if (ply.ReferenceHub.scp079PlayerScript.NetworkcurMana >= Plugin.Instance.Config.blackout_energy)
                        {
                            ply.ReferenceHub.scp079PlayerScript.NetworkcurMana -= Plugin.Instance.Config.blackout_energy;
                        }
                        else
                        {
                            response = Plugin.Instance.Config.scp_noenergy;
                            return true;
                        }

                        Generator079.Generators[0].ServerOvercharge(15, false);
                        response = Plugin.Instance.Config.com_executed;
                        Cassie.Message(Plugin.Instance.Config.blackout_cassie, true, true);
                        return true;
                    }

                    if (args[1].ToLower().Equals("help"))
                    {
                        response = "Commands: \n.079 blackout - generator malfunction \n.079 flash - camera flash \n.079 canceled - Alpha warhead stop";
                        return true;
                    }

                    if (args[1].ToLower().Equals("canceled"))
                    {
                        if (Warhead.CanBeStarted == false)
                        {
                            if (Plugin.Instance.handlers.isCooldown == true)
                            {
                                response = "You cannot use, you need to cooldown a little";
                                return true;
                            }
                            if (plr.ReferenceHub.scp079PlayerScript.NetworkcurLvl < Plugin.Instance.Config.canceled_lvl)
                            {
                                response = Plugin.Instance.Config.scp_insuflvl;
                                return true;
                            }
                            if (ply.ReferenceHub.scp079PlayerScript.NetworkcurMana >= Plugin.Instance.Config.canceled_energy)
                            {
                                ply.ReferenceHub.scp079PlayerScript.NetworkcurMana -= Plugin.Instance.Config.canceled_energy;
                            }
                            else
                            {
                                response = Plugin.Instance.Config.scp_noenergy;
                                return true;
                            }
                            Timing.RunCoroutine(Plugin.Instance.handlers.Nuke(), "nuke");
                            response = Plugin.Instance.Config.com_executed;
                            return true;
                        }
                        if (Warhead.CanBeStarted == true)
                        {
                            response = Plugin.Instance.Config.canceled_noacitvated;
                            return true;
                        }
                    }

                    if (args[1].ToLower().Equals("flash"))
                    {
                        if (plr.ReferenceHub.scp079PlayerScript.NetworkcurLvl < Plugin.Instance.Config.flash_lvl)
                        {
                            response = Plugin.Instance.Config.scp_insuflvl;
                            return true;
                        }
                        if (ply.ReferenceHub.scp079PlayerScript.NetworkcurMana >= Plugin.Instance.Config.flash_energy)
                        {
                            ply.ReferenceHub.scp079PlayerScript.NetworkcurMana -= Plugin.Instance.Config.flash_energy;
                        }
                        else
                        {
                            response = Plugin.Instance.Config.scp_noenergy;
                            return true;
                        }
                        var pos = plr.ReferenceHub.scp079PlayerScript.currentCamera.transform.position;
                        GrenadeManager gm = plr.ReferenceHub.GetComponent<GrenadeManager>();
                        GrenadeSettings settings = gm.availableGrenades.FirstOrDefault(g => g.inventoryID == ItemType.GrenadeFlash);
                        FlashGrenade flash = GameObject.Instantiate(settings.grenadeInstance).GetComponent<FlashGrenade>();
                        flash.fuseDuration = 0.5f;
                        flash.InitData(gm, Vector3.zero, Vector3.zero, 1f);
                        flash.transform.position = pos;
                        NetworkServer.Spawn(flash.gameObject);
                        response = Plugin.Instance.Config.com_executed;
                        return true;
                    }
                }
                response = "GGMen";
                return false;
            }
        }
    }
}