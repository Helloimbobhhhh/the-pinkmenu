using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTemplate.Mods
{
    class RoomMods
    {
        public static void MuteAllMusic()
        {
            foreach (SoundPostMuteButton muteButton in UnityEngine.Object.FindObjectsOfType<SoundPostMuteButton>())
            {
                muteButton.ButtonActivation();
            }
        }

        public static void MuteallPlayers()
        {
            GorillaPlayerScoreboardLine[] ScoreBoardLine = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>();
            foreach (GorillaPlayerScoreboardLine MuteLine in ScoreBoardLine)
            {
                if (MuteLine.linePlayer != null)
                {
                    MuteLine.PressButton(true, GorillaPlayerLineButton.ButtonType.Mute);
                    MuteLine.muteButton.isOn = true;
                    MuteLine.muteButton.UpdateColor();
                }
            }
        }
    }
}
