using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Constants
{
    public static class FuzzyLogicConstant
    {
        public enum InputType
        {
            Sensivity,
            Quantity,
            Pollution
        }

        public enum OutputType
        {
            Rotation,
            Detergent,
            Duration
        }

        public enum Sensitivity
        {
            Durable,
            Medium,
            Sensitive
        }

        public enum Quantity
        {
            Small,
            Medium,
            Large
        }

        public enum Pollution
        {
            Clean,
            Medium,
            Dirty
        }

        public enum Rotation
        {
            Sensitive,
            MediumSensitive,
            Medium,
            MediumDurable,
            Durable
        }

        public enum Detergent
        {
            Little,
            MediumLittle,
            Medium,
            MediumMuch,
            Much
        }

        public enum Duration
        {
            Short,
            MediumShort,
            Medium,
            MediumLong,
            Long
        }
    }
}
