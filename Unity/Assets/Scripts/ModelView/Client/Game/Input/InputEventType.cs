using UnityEngine;

namespace ET.Client
{
    public struct MoveDelta
    {
        public Unit Unit;
        public float X;
        public float Y;
    }

    public struct KeyDown
    {
        public Unit Unit;
        public KeyCode KeyCode;
    }
}