using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterSCP079
{
    public class Config : IConfig
    {
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Indicates whether the plugin is enabled or not")]
        public bool blackout_enabled { get; set; } = true;

        [Description("Set the required level to activate the ability [blackout]")]
        public int blackout_lvl { get; set; } = 1;

        [Description("Set the required energy to activate the ability [blackout]")]
        public int blackout_energy { get; set; } = 70;

        [Description("Set how long to turn off the light in the complex")]
        public int blackout_timeovercharge { get; set; } = 8;

        [Description("SCP079 cooling time")]
        public float blackout_cooldown { get; set; } = 120f;

        [Description("This is a cassie that will play after using the [blackout] ability")]
        public string blackout_cassie { get; set; } = "pitch_0.6 .g4... pitch_0.7 jam_020_2 Emergency . .g6 Light Off";

        [Description("Add extra time to blackout when 079 is leveling up")]
        public bool blackout_lvlup { get; set; } = true;
        
        [Description("How much to increase the blackout time")]
        public int blackout_timeinc { get; set; } = 2;

        [Description("Indicates whether the plugin is enabled or not")]
        public bool canceled_enabled { get; set; } = true;

        [Description("Set the required level to activate the ability [canceled]")]
        public int canceled_lvl { get; set; } = 2;

        [Description("Set the required energy to activate the ability [canceled]")]
        public int canceled_energy { get; set; } = 85;

        [Description("SCP079 cooling time")]
        public float canceled_cooldown { get; set; } = 120f;

        [Description("This is a cassie that will play after using the [canceled] ability")]
        public string canceled_cassie { get; set; } = "pitch_0.5 .g6.. pitch_0.7 SCP pitch_0.5 0 pitch_0.5 7 pitch_0.5 9 pitch_0.7 jam_030_5 Hack .g4.. Warhead System";

        [Description("This message will be displayed in the console if the warhead is not activated")]
        public string canceled_noacitvated { get; set; } = "Alpha warhead not activated";

        [Description("Indicates whether the plugin is enabled or not")]
        public bool flash_enabled { get; set; } = true;

        [Description("Set the required level to activate the ability [flash]")]
        public int flash_lvl { get; set; } = 0;

        [Description("Set the required energy to activate the ability [flash]")]
        public int flash_energy { get; set; } = 25;

        [Description("Indicates whether the plugin is enabled or not")]
        public bool activate_enabled { get; set; } = true;

        [Description("Set the required level to activate the ability [activate]")]
        public int activate_lvl { get; set; } = 3;

        [Description("Set the required energy to activate the ability [activate]")]
        public int activate_energy { get; set; } = 150;

        [Description("This message will be displayed in the console if the warhead is activated")]
        public string activate_warheadactive { get; set; } = "Alpha warhead already activated";

        [Description("SCP079 cooling time")]
        public float activate_cooldown { get; set; } = 180f;

        [Description("After activating the ability, block the warhead")]
        public bool activate_alphalock { get; set; } = true;

        [Description("This is a cassie that will play after using the [activate] ability")]
        public string activate_cassie { get; set; } = "pitch_0.5 .g6.. pitch_0.7 SCP pitch_0.5 0 pitch_0.5 7 pitch_0.5 9 pitch_0.7 jam_030_5 Hack .g4.. Warhead System";

        [Description("This message will be displayed in the console if there is not enough energy to activate the ability")]
        public string scp_noenergy { get; set; } = "Not enough energy to carry out the command";

        [Description("This message will be displayed in the console if the ability is disabled")]
        public string scp_abilitydis { get; set; } = "This ability is disabled on this server";

        [Description("This message will be displayed in the console if 079 needs to cool down")]
        public string scp_cooldownmsg { get; set; } = "You cannot use, you need to cooldown a little";

        [Description("Message displayed by SCP079 when spawning")]
        public string scp_startmsg { get; set; } = "<b><color=red>You can open the console [~] and type [ .079 help] and you will have a lot of new possibilities</color></b>";

        [Description("Message time when SCP079 appears")]
        public int scp_timestartmsg { get; set; } = 10;

        [Description("This message will be displayed in the console if the level is not sufficient to activate the ability")]
        public string scp_insuflvl { get; set; } = "Not sufficient level";

        [Description("The message displayed in the console if the person is not SCP079")]
        public string scp_no079 { get; set; } = "You are not a SCP-079! You can not use this command!";

        [Description("This message will be displayed in the console if the ability is successfully used")]
        public string com_executed { get; set; } = "Ability successfully used";
    }
}
