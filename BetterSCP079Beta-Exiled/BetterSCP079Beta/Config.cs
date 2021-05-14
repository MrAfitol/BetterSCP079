using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterSCP079Beta
{
    public class Config : IConfig
    {
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Set the required level to activate the ability [blackout]")]
        public int blackout_lvl { get; set; } = 1;

        [Description("Set the required energy to activate the ability [blackout]")]
        public int blackout_energy { get; set; } = 70;

        [Description("Set how long to turn off the light in the complex")]
        public int blackout_timeovercharge { get; set; } = 15;

        [Description("This is a cassie that will play after using the [blackout] ability")]
        public string blackout_cassie { get; set; } = "pitch_0.6 .g4... pitch_0.7 jam_020_2 Emergency . .g6 Light Off";

        [Description("Set the required level to activate the ability [canceled]")]
        public int canceled_lvl { get; set; } = 2;

        [Description("Set the required energy to activate the ability [canceled]")]
        public int canceled_energy { get; set; } = 85;

        [Description("SCP079 cooling time")]
        public float canceled_cooldown { get; set; } = 120f;

        [Description("This message will be displayed in the console if 079 needs to cool down")]
        public string canceled_cooldownmsg { get; set; } = "You cannot use, you need to cooldown a little";

        [Description("This is a cassie that will play after using the [canceled] ability")]
        public string canceled_cassie { get; set; } = "pitch_0.5 .g6.. pitch_0.7 SCP pitch_0.5 0 pitch_0.5 7 pitch_0.5 9 pitch_0.7 jam_030_5 Hack .g4.. Warhead System";
        
        [Description("This message will be displayed in the console if the warhead is not activated")]
        public string canceled_noacitvated { get; set; } = "Alpha warhead not activated";

        [Description("Set the required level to activate the ability [flash]")]
        public int flash_lvl { get; set; } = 0;

        [Description("Set the required energy to activate the ability [flash]")]
        public int flash_energy { get; set; } = 35;

        [Description("This message will be displayed in the console if there is not enough energy to activate the ability")]
        public string scp_noenergy { get; set; } = "Not enough energy to carry out the command";

        [Description("Message displayed by SCP079 when spawning")]
        public string scp_startmsg { get; set; } = "<b><color=red>You can open the console [~] and type [ .079 help] and you will have a lot of new possibilities</color></b>";

        [Description("This message will be displayed in the console if the level is not sufficient to activate the ability")]
        public string scp_insuflvl { get; set; } = "Not sufficient level";

        [Description("The message displayed in the console if the person is not SCP079")]
        public string scp_no079 { get; set; } = "You are not a SCP-079! You can not use this command!";

        [Description("Message time when SCP079 appears")]
        public int scp_timestartmsg { get; set; } = 10;

        [Description("This message will be displayed in the console if the ability is successfully used")]
        public string com_executed { get; set; } = "Ability successfully used";
    }
}
