using Services.Interfaces;

namespace ItemsManager
{
    internal class Player
    {
        public static void PlayItem(IPlayable playable)
        {
            playable.Play();
            playable.Pause();
        }
    }
}
