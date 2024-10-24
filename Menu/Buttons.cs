using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Join The Discord", method =() => JoinTheDiscord.JoinTheDiscordLol(), isTogglable = false, toolTip = "Joins my discord server."},
                new ButtonInfo { buttonText = "Disconnect", method =() => DisconnectButton.Disconnect(), isTogglable = false, toolTip = "Joins my discord server."},
                new ButtonInfo { buttonText = "Panic(BROKEN)", method =() => Panic.PanicMod(), isTogglable = false, toolTip = "Disables Every Mod That You Have Enabled."},
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Safety Mods", method =() => SettingsMods.SafetyMods(), isTogglable = false, toolTip = "Opens the Safety Mods page for the menu."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => SettingsMods.MovementMods(), isTogglable = false, toolTip = "Opens the Movement Mods page for the menu."},
                new ButtonInfo { buttonText = "Fun Mods", method =() => SettingsMods.FunMods(), isTogglable = false, toolTip = "Opens the Fun Mods page for the menu."},
                new ButtonInfo { buttonText = "Overpowered Mods", method =() => SettingsMods.OverpoweredMods(), isTogglable = false, toolTip = "Opens the Overpowered Mods page for the menu."},
                new ButtonInfo { buttonText = "Important Mods", method =() => SettingsMods.ImportantMods(), isTogglable = false, toolTip = "Opens the Important Mods page for the menu."},
                new ButtonInfo { buttonText = "Experiments", method =() => SettingsMods.Experiments(), isTogglable = false, toolTip = "Opens the Experiments page for the menu. (not all mods work, once again they are experiments.)"},
                new ButtonInfo { buttonText = "Sound Mods", method =() => SettingsMods.SoundMods(), isTogglable = false, toolTip = "Opens the Sound Mods page for the menu."},
                new ButtonInfo { buttonText = "Rig Mods", method =() => SettingsMods.RigMods(), isTogglable = false, toolTip = "Opens the Rig Mods page for the menu."},
                new ButtonInfo { buttonText = "Visual Mods", method =() => SettingsMods.VisualMods(), isTogglable = false, toolTip = "Opens the Visual Mods page for the menu."},
                new ButtonInfo { buttonText = "All Flys Lol", method =() => SettingsMods.AllFlysLol(), isTogglable = false, toolTip = "Opens the All Flys Lol page for the menu."},
                new ButtonInfo { buttonText = "Advantages", method =() => SettingsMods.Advantages(), isTogglable = false, toolTip = "Opens the Advantages page for the menu."},
                new ButtonInfo { buttonText = "Projectiles", method =() => SettingsMods.ProjectileMods(), isTogglable = false, toolTip = "Opens the Projectiles page for the menu."},
                new ButtonInfo { buttonText = "Room Mods", method =() => SettingsMods.RoomMods(), isTogglable = false, toolTip = "Opens the Room mods page for the menu."},

            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Freeze Player In Menu", enableMethod =() => SettingsMods.FreezePlayerInMenu(), disableMethod =() => SettingsMods.FreezePlayerInMenuEnabled(), enabled = disconnectButton, toolTip = "Freezes your entire body when in the menu."},
                new ButtonInfo { buttonText = "Disable Menu Buttons", method =() => SettingsMods.DisablePageButtons(), isTogglable = false, toolTip = "Disables Page Buttons."},
                new ButtonInfo { buttonText = "Enable Page Buttons", method =() => SettingsMods.EnablePageButtons(), isTogglable = false, toolTip = "Enables Page Buttons."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },

            new ButtonInfo[] { // Safety Mods
                new ButtonInfo { buttonText = "Return to main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => SafetyMods.NoFingerMovement(), isTogglable = true, toolTip = "Disables Finger Movement."},
                new ButtonInfo { buttonText = "Anti Report", method =() => SafetyMods.Antireport(), isTogglable = true, toolTip = "Kicks you out if people come close to your report button."},
                new ButtonInfo { buttonText = "Disable Gamemode Buttons", method =() => SafetyMods.DisableGamemodeButtons(), isTogglable = true, toolTip = "Disables gamemode buttons in stump."},
                new ButtonInfo { buttonText = "Enable Gamemode Buttons", method =() => SafetyMods.EnableGamemodeButtons(), isTogglable = true, toolTip = "Enables gamemode buttons in stump."},
            },

            new ButtonInfo[] { // Movement Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Speedboost", method =() => MovementMods.Speedboost(), isTogglable = true, toolTip = "Gives you a speedboost."},
                new ButtonInfo { buttonText = "Speedboost[G]", method =() => MovementMods.RightgripSpeedboost(), isTogglable = true, toolTip = "Same as speedboost but you have to hold your right grip!"},
                new ButtonInfo { buttonText = "Speedboost[LG]", method =() => MovementMods.LeftgripSpeedboost(), isTogglable = true, toolTip = "Same as speedboost but you have to hold your left grip!"},
                new ButtonInfo { buttonText = "Fly", method =() => MovementMods.Fly(), isTogglable = true, toolTip = "Lets you fly!"},
                new ButtonInfo { buttonText = "Faster Fly", method =() => MovementMods.FasterFly(), isTogglable = true, toolTip = "Lets you fly again but faster."},
                new ButtonInfo { buttonText = "Grip Fly[G]", method =() => MovementMods.RightGripFly(), isTogglable = true, toolTip = "Lets you fly with right grip."},
                new ButtonInfo { buttonText = "Grip Fly[LG]", method =() => MovementMods.LeftGripFly(), isTogglable = true, toolTip = "Lets you fly with left grip."},
                new ButtonInfo { buttonText = "Ghost Monke", method =() => MovementMods.GhostMonke(), isTogglable = true, toolTip = "Makes you stand still untill you let go."},
                new ButtonInfo { buttonText = "No Clip", method =() => MovementMods.NoClip(), isTogglable = true, toolTip = "Lets you noclip through stuff, pair with platforms."},
                new ButtonInfo { buttonText = "Platforms", method =() => MovementMods.Platforms(), isTogglable = true, toolTip = "Gives you platforms."},
                new ButtonInfo { buttonText = "Invis Platforms", method =() => MovementMods.InvisiblePlatforms(), isTogglable = true, toolTip = "Gives you Invisible platforms."},
                new ButtonInfo { buttonText = "Sticky Platforms", method =() => MovementMods.StickyPlatforms(), isTogglable = true, toolTip = "Gives you Sticky platforms."},
                new ButtonInfo { buttonText = "Invis Sticky Platforms", method =() => MovementMods.invisStickyPlatforms(), isTogglable = true, toolTip = "Gives you invis sticky platforms."},
                new ButtonInfo { buttonText = "Random TP", method =() => MovementMods.RandomTP(), isTogglable = true, toolTip = "Teleports you to a random spot."},
                new ButtonInfo { buttonText = "Invis Monke", method =() => MovementMods.InvisMonke(), isTogglable = true, toolTip = "Makes you invisible."},
                new ButtonInfo { buttonText = "Auto Funny Run", method =() => MovementMods.AutoFunnyRun(), isTogglable = true, toolTip = "Makes you automatically funny run."},
            },

             new ButtonInfo[] { // Fun Mods
                new ButtonInfo { buttonText = "Return to main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Spin Head", method =() => FunMods.SpinHead(), isTogglable = true, toolTip = "Spins your head."},
                new ButtonInfo { buttonText = "Spin Head 2", method =() => FunMods.SpinHead2(), isTogglable = true, toolTip = "Spins your head num. 2."},
                new ButtonInfo { buttonText = "Spin Head 3", method =() => FunMods.SpinHead3(), isTogglable = true, toolTip = "Spins your head num. 3."},
                new ButtonInfo { buttonText = "Upside Down Head", method =() => FunMods.UpsideDownHead(), isTogglable = false, toolTip = "Makes your head upside down."},
                new ButtonInfo { buttonText = "Broken Neck", method =() => FunMods.BrokenNeck(), isTogglable = false, toolTip = "Literally breaks your neck lol"},
                new ButtonInfo { buttonText = "Backwards Head", method =() => FunMods.BackwardsHead(), isTogglable = false, toolTip = "Makes your head look backwards, but you see normally."},
                new ButtonInfo { buttonText = "Fix Head", method =() => FunMods.FixHead(), isTogglable = false, toolTip = "Fixs your head."},
                new ButtonInfo { buttonText = "Day Time", method =() => FunMods.Daytime(), isTogglable = false, toolTip = "Makes it day time outside."},
                new ButtonInfo { buttonText = "Night Time", method =() => FunMods.NightTime(), isTogglable = false, toolTip = "Makes it night time outside."},
                new ButtonInfo { buttonText = "Morning Time", method =() => FunMods.MorningTime(), isTogglable = false, toolTip = "Makes it morning time outside."},
                new ButtonInfo { buttonText = "Instant Hand Taps", method =() => FunMods.InstantHandTaps(), isTogglable = false, toolTip = "Enables instant hand taps."},
                new ButtonInfo { buttonText = "Disable Instant Hand Taps", method =() => FunMods.DisableInstantHandTaps(), isTogglable = false, toolTip = "Disbables instant hand taps mod."},
                new ButtonInfo { buttonText = "Instant Hand Taps[RG]", method =() => FunMods.RightGripInstantHandTaps(), isTogglable = true, toolTip = "When you press right grip, it enables instant hand taps."},
                new ButtonInfo { buttonText = "Fast Ropes", method =() => FunMods.FastRopes(), isTogglable = false, toolTip = "Makes ropes fast."},
                new ButtonInfo { buttonText = "Regular Ropes", method =() => FunMods.RegularRopes(), isTogglable = true, toolTip = "Makes ropes regular again."},
                new ButtonInfo { buttonText = "Backwards Brooms", method =() => FunMods.BackwardBrooms(), isTogglable = false, toolTip = "Makes all brooms go backwards."},
                new ButtonInfo { buttonText = "Forwards Broom", method =() => FunMods.ForwardBrooms(), isTogglable = true, toolTip = "Makes all brooms go forwards."},
                new ButtonInfo { buttonText = "White Sky", method =() => FunMods.WhiteSky(), isTogglable = false, toolTip = "Makes the sky white."},
                new ButtonInfo { buttonText = "Clear Sky", method =() => FunMods.ClearSky(), isTogglable = false, toolTip = "Makes the sky clear."},
                new ButtonInfo { buttonText = "Black Sky", method =() => FunMods.BlackSky(), isTogglable = false, toolTip = "Makes the sky black."},
                new ButtonInfo { buttonText = "Yellow Sky", method =() => FunMods.YellowSky(), isTogglable = false, toolTip = "Makes the sky yellow."},
                new ButtonInfo { buttonText = "Blue Sky", method =() => FunMods.BlueSky(), isTogglable = false, toolTip = "Makes the sky blue."},
                new ButtonInfo { buttonText = "Red Sky", method =() => FunMods.RedSky(), isTogglable = false, toolTip = "Makes the sky red."},
                new ButtonInfo { buttonText = "Gray Sky", method =() => FunMods.GraySky(), isTogglable = false, toolTip = "Makes the sky gray."},
                new ButtonInfo { buttonText = "Pink Sky", method =() => FunMods.PinkSky(), isTogglable = false, toolTip = "Makes the sky pink."},
                new ButtonInfo { buttonText = "Green Sky", method =() => FunMods.GreenSky(), isTogglable = false, toolTip = "Makes the sky green."},
                new ButtonInfo { buttonText = "Tag Gun", method =() => FunMods.TagGun(), isTogglable = true, toolTip = "Gives you a gun that tags people."},
                new ButtonInfo { buttonText = "TP Gun", method =() => FunMods.TPGun(), isTogglable = true, toolTip = "TPs you where ever you want to."},
                new ButtonInfo { buttonText = "Tag Self", method =() => FunMods.TagSelf(), isTogglable = false, toolTip = "Tags yourself."},
                new ButtonInfo { buttonText = "Remove All Trees", method =() => FunMods.RemoveAllTrees(), isTogglable = false, toolTip = "Removes all trees."},
            },

             new ButtonInfo[] { // Overpowered Mods
                new ButtonInfo { buttonText = "Return to Main", method =() =>   Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Master Check", method =() => OverpoweredMods.MasterCheck(), isTogglable = false, toolTip = "Checks if you are master client."},
                new ButtonInfo { buttonText = "Spawn Red Lucy", method =() => OverpoweredMods.SpawnRedLucy(), isTogglable = false, toolTip = "Spawns Red Lucy."},
                new ButtonInfo { buttonText = "Spawn Blue Lucy", method =() => OverpoweredMods.SpawnBlueLucy(), isTogglable = true, toolTip = "Spawns Blue Lucy."},
                new ButtonInfo { buttonText = "Spawn Both Lucys[LG & G]", method =() => OverpoweredMods.SpawnBlueAndRedLucyGrips(), isTogglable = false, toolTip = "Spawns Both Red & Blue Lucys with grip."},
                new ButtonInfo { buttonText = "Play Monster Eye Event", method =() => OverpoweredMods.PlayEyeMonsterMoonEvent(), isTogglable = true, toolTip = "PLAYS THE NEW EVENT!"},
                new ButtonInfo { buttonText = "Play Monster Eye Event[G]", method =() => OverpoweredMods.Rightgripplayevent(), isTogglable = true, toolTip = "PLAYS THE NEW EVENT (with right grip."},
                new ButtonInfo { buttonText = "Tag All", method =() => OverpoweredMods.TagAll(), isTogglable = true, toolTip = "Tags everybody in the lobby."},
            },

              new ButtonInfo[] { // Important Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Disconnect", method =() => ImportantMods.Disconnect(), isTogglable = false, toolTip = "Disconnects you from the lobby."},
                new ButtonInfo { buttonText = "Disconnect[G]", method =() => ImportantMods.Disconnectrightgrip(), isTogglable = false, toolTip = "Disconnects you from the lobby with right grip."},
                new ButtonInfo { buttonText = "Reconnect", method =() => ImportantMods.Reconnect(), isTogglable = false, toolTip = "Reconnects you to the last lobby you were in."},
            },

              new ButtonInfo[] { // Experiments
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Every Car Monke Speed", method =() => Experiments.CarMonkey(), isTogglable = true, toolTip = "Every car monke speed in one mod!"},
            },

               new ButtonInfo[] { // Sound Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Nothing Here Yet", method =() => FunMods.FixHead(), isTogglable = true, toolTip = "Nothing Here Yet"},
            },

               new ButtonInfo[] { // Rig Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Iron Monke", method =() => RigMods.IronMonke(), isTogglable = true, toolTip = "Lets you fly but better."},
            },

               new ButtonInfo[] { // Visual Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Green Screen", method =() => VisualMods.GreenScreen(), isTogglable = true, toolTip = "Green Screen replacement for yizzis cam mod."},
                new ButtonInfo { buttonText = "Tracers", method =() => VisualMods.Tracers(), isTogglable = true, toolTip = "Lets you see where people are at all times"},
                new ButtonInfo { buttonText = "Play Monster Eye Event", method =() => OverpoweredMods.PlayEyeMonsterMoonEvent(), isTogglable = true, toolTip = "Plays the new live event."},
                new ButtonInfo { buttonText = "Beacons", method =() => VisualMods.Beacons(), isTogglable = false, toolTip = "Enables beacons on players."},
            },

                new ButtonInfo[] { // All Flys
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Fly", method =() => MovementMods.Fly(), isTogglable = true, toolTip = "Lets you fly!"},
                new ButtonInfo { buttonText = "Faster Fly", method =() => MovementMods.FasterFly(), isTogglable = true, toolTip = "Lets you fly again but faster."},
                new ButtonInfo { buttonText = "Right Grip Fly", method =() => MovementMods.RightGripFly(), isTogglable = true, toolTip = "Lets you fly with right grip."},
                new ButtonInfo { buttonText = "Left Grip Fly", method =() => MovementMods.LeftGripFly(), isTogglable = true, toolTip = "Lets you fly with left grip."},
            },

                new ButtonInfo[] { // Advantages
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "No Tag On join", method =() => Advantages.NoTagOnJoin(), isTogglable = true, toolTip = "Makes it so you don't get tagged when you join a lobby."},
                new ButtonInfo { buttonText = "Tag On Join", method =() => Advantages.TagOnJoin(), isTogglable = true, toolTip = "Makes it so you do get tagged when you join a lobby."},
            },

               new ButtonInfo[] { // Projectiles
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Snowball Spammer", method =() => Projectiles.SnowballSpammer(), isTogglable = true, toolTip = "Spams snowballs."},
                new ButtonInfo { buttonText = "Water Spammer", method =() => Projectiles.WaterSpammer(), isTogglable = true, toolTip = "Spams Water."},
                new ButtonInfo { buttonText = "Lava Spammer", method =() => Projectiles.LavaSpammer(), isTogglable = true, toolTip = "Spams Lava."},
                new ButtonInfo { buttonText = "Gift Spammer", method =() => Projectiles.GiftSpammer(), isTogglable = true, toolTip = "Spams Gifts."},
                new ButtonInfo { buttonText = "Candy Spammer", method =() => Projectiles.CandySpammer(), isTogglable = true, toolTip = "Spams Candy."},
                new ButtonInfo { buttonText = "Fish Spammer", method =() => Projectiles.FishSpammer(), isTogglable = true, toolTip = "Spams Fish."},
            },

                new ButtonInfo[] { // Room Mods
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the mod menu."},
                new ButtonInfo { buttonText = "Mute All Players", method =() => RoomMods.MuteallPlayers(), isTogglable = true, toolTip = "Mutes Everybody."},
                new ButtonInfo { buttonText = "Mute Music", method =() => RoomMods.MuteAllMusic(), isTogglable = true, toolTip = "Mutes Music In Every Map."},
            },
        };
    }
}
