using Photon.Pun;

namespace StupidTemplate.Mods
{
    internal class ImportantMods
    {
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void Reconnect()
        {
            PhotonNetwork.Reconnect();
        }

        public static void Disconnectrightgrip()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                PhotonNetwork.Disconnect(); 
            }
        }
    }
}
