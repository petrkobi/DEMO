﻿using UnityEngine;

namespace vrtp_demo.Scripts.DoorController
{
    [CreateAssetMenu(fileName = "MazdaData", menuName = "Data/MazdaData", order = 0)]
    public class MazdaData : ScriptableObject
    {
        public bool IsFrontLeftDoorOpen;
        public bool IsFronRightDoorOpen;
        public bool IsRearLeftDoorOpen;
        public bool IsRearRightDoorOpen;
        public bool IsTailDoorOpen;

        public Color MazdaColor;

        public bool IsCursorOnFrontLeftDoor;
        public bool IsCursorOnFrontRightDoor;
        public bool IsCursorOnRearLeftDoor;
        public bool IsCursorOnRearRightDoor;
        public bool IsCursorOnTailDoor;

    }
}