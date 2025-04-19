using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Constants;

namespace WashingMachine.FuzzyLogicEngine
{
    public class MemberFunctionValues
    {
        public FuzzyLogicConstant.Rotation rotation { get; set; }
        public FuzzyLogicConstant.Detergent detergent { get; set; }
        public FuzzyLogicConstant.Duration duration { get; set; }




        public double getOutputFunctionValues(FuzzyLogicConstant.OutputType output)
        {
            double rotationValue = 0;
            double durationValue = 0;
            double detergentValue = 0;
            switch (rotation)
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

            switch (detergent)
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

            switch (duration)
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
            switch(output)
            {
                case FuzzyLogicConstant.OutputType.Rotation:
                    return rotationValue;
                case FuzzyLogicConstant.OutputType.Detergent:
                    return detergentValue;
                case FuzzyLogicConstant.OutputType.Duration:
                    return durationValue;
            }

            return 0;
        }
    }
}
