using System;
using System.Collections.Generic;
using System.Text;

namespace Drive.Cardgame.Core.Cards
{
    public class CardType
    {
        public enum Distance
        {
            TwentyFiveKilometers,
            FiftyKilometers,
            SeventyFiveKilometers,
            OneHundredKilometers,
            TwoHundredKilometers,
        }

        public enum Safety
        {
            DrivingAce,
            ExtraTank,
            PunctureProof,
            RightOfWay,
        }

        public enum Remedy
        {
            Repairs,
            Gasoline,
            Spare,
            EndOfLimit,
            Roll,
        }

        public enum Hazard
        {
            Accident,
            OutOfGas,
            FlatTire,
            SpeedLimit,
            Stop,
        }
    }
}
