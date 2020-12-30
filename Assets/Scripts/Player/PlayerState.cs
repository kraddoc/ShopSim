using UnityEngine;

namespace SimTask.Player
{
    public static class PlayerState
    {
        public enum State
        {
            Trading,
            Free
        }

        public static State CurrentState = State.Free;
    }
}