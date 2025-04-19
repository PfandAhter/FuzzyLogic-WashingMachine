using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Constants;
using static WashingMachine.Constants.FuzzyLogicConstant;

namespace WashingMachine.Rules
{
    public class Rule
    {
        private FuzzyLogicConstant.Sensitivity Sensivity { get; set; }
        private FuzzyLogicConstant.Quantity Quantity { get; set; }
        private FuzzyLogicConstant.Pollution Pollution { get; set; }

        public FuzzyLogicConstant.Rotation Rotation { get; set; }
        public FuzzyLogicConstant.Detergent Detergent { get; set; }
        public FuzzyLogicConstant.Duration Duration { get; set; }


        public Rule(FuzzyLogicConstant.Sensitivity sensivity, FuzzyLogicConstant.Quantity quantity, FuzzyLogicConstant.Pollution pollution)
        {
            this.Sensivity = sensivity;
            this.Quantity = quantity;
            this.Pollution = pollution;
        }

        private void implementRules()
        {
            if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.Sensitive;
                this.Duration = Duration.Short;
                this.Detergent = Detergent.Little;
            }
            //2
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.MediumSensitive;
                this.Duration = Duration.Short;
                this.Detergent = Detergent.Little;
            }
            //3
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.MediumShort;
                this.Detergent = Detergent.Medium;
            }
            //4
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.Sensitive;
                this.Duration = Duration.Short;
                this.Detergent = Detergent.Medium;
            }
            //5
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.MediumSensitive;
                this.Duration = Duration.MediumShort;
                this.Detergent = Detergent.Medium;
            }
            //6
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.MediumMuch;
            }
            //7
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.MediumSensitive;
                this.Duration = Duration.MediumShort;
                this.Detergent = Detergent.Medium;
            }
            //8
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.MediumSensitive;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.MediumMuch;
            }
            //9
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Sensitive && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.MediumLong;
                this.Detergent = Detergent.MediumMuch;
            }
            //10
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.MediumSensitive;
                this.Duration = Duration.MediumShort;
                this.Detergent = Detergent.Little;
            }
            //11
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.Short;
                this.Detergent = Detergent.Medium;
            }
            //12
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.MediumDurable;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.MediumMuch;
            }
            //13
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.MediumDurable;
                this.Duration = Duration.MediumShort;
                this.Detergent = Detergent.Medium;
            }
            //14
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.Medium;
            }
            //15
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Sensitive;
                this.Duration = Duration.Long;
                this.Detergent = Detergent.MediumMuch;
            }
            //16
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.Sensitive;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.Medium;
            }
            //17
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.Sensitive;
                this.Duration = Duration.MediumLong;
                this.Detergent = Detergent.MediumMuch;
            }
            //18
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Medium && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Sensitive;
                this.Duration = Duration.Long;
                this.Detergent = Detergent.Much;
            }
            //19
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.MediumLittle;
            }
            //20
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.MediumDurable;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.Medium;
            }
            //21
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Small && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Durable;
                this.Duration = Duration.MediumLong;
                this.Detergent = Detergent.MediumMuch;
            }
            //22
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.Medium;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.Medium;
            }
            //23
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.MediumDurable;
                this.Duration = Duration.MediumLong;
                this.Detergent = Detergent.Medium;
            }
            //24
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Medium && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Durable;
                this.Duration = Duration.Medium;
                this.Detergent = Detergent.Much;
            }
            //25
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Clean)
            {
                this.Rotation = Rotation.MediumDurable;
                this.Duration = Duration.MediumLong;
                this.Detergent = Detergent.MediumMuch;
            }
            //26
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Medium)
            {
                this.Rotation = Rotation.MediumDurable;
                this.Duration = Duration.Long;
                this.Detergent = Detergent.MediumMuch;
            }
            //27
            else if (Sensivity == FuzzyLogicConstant.Sensitivity.Durable && Quantity == FuzzyLogicConstant.Quantity.Large && Pollution == FuzzyLogicConstant.Pollution.Dirty)
            {
                this.Rotation = Rotation.Durable;
                this.Duration = Duration.Long;
                this.Detergent = Detergent.Much;
            }
        }
    }
}
