using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Rules;

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

        public static double getRuleOutputValue(FuzzyLogicConstant.OutputType type, Rule rule)
        {
            double rotationValue = 0.0;
            double durationValue = 0.0;
            double detergentValue = 0.0;

            switch (rule.Rotation)
            {
                case FuzzyLogicConstant.Rotation.Sensitive:
                    rotationValue = -1.15;
                    break;
                case FuzzyLogicConstant.Rotation.MediumSensitive:
                    rotationValue = 2.75;
                    break;
                case FuzzyLogicConstant.Rotation.Medium:
                    rotationValue = 5;
                    break;
                case FuzzyLogicConstant.Rotation.MediumDurable:
                    rotationValue = 7.25;
                    break;
                case FuzzyLogicConstant.Rotation.Durable:
                    rotationValue = 11.15;
                    break;
            }

            switch (rule.Duration)
            {
                case FuzzyLogicConstant.Duration.Short:
                    durationValue = 23.79;
                    break;
                case FuzzyLogicConstant.Duration.MediumShort:
                    durationValue = 39.9;
                    break;
                case FuzzyLogicConstant.Duration.Medium:
                    durationValue = 57.5;
                    break;
                case FuzzyLogicConstant.Duration.MediumLong:
                    durationValue = 75.1;
                    break;
                case FuzzyLogicConstant.Duration.Long:
                    durationValue = 102.15;
                    break;
            }

            switch (rule.Detergent)
            {
                case FuzzyLogicConstant.Detergent.Little:
                    detergentValue = 10;
                    break;
                case FuzzyLogicConstant.Detergent.MediumLittle:
                    detergentValue = 85;
                    break;
                case FuzzyLogicConstant.Detergent.Medium:
                    detergentValue = 150;
                    break;
                case FuzzyLogicConstant.Detergent.MediumMuch:
                    detergentValue = 215;
                    break;
                case FuzzyLogicConstant.Detergent.Much:
                    detergentValue = 290;
                    break;
            }

            switch (type)
            {
                case FuzzyLogicConstant.OutputType.Rotation:
                    return rotationValue;
                case FuzzyLogicConstant.OutputType.Duration:
                    return durationValue;
                case FuzzyLogicConstant.OutputType.Detergent:
                    return detergentValue;
                default:
                    return 0.0;
            }
        }
    }
}
