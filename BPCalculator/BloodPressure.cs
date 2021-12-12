using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name= "Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        // Lower thresholds for each of the range bands i.e. if you score above this score, you're in that category
        public const int DiastolicHighBand = 90;
        public const int DiastolicPreHighBand = 80;
        public const int DiastolicIdealBand = 60;
        public const int SystolicHighBand = 140;
        public const int SystolicPreHighBand = 120;
        public const int SystolicIdealBand = 90;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                // implement as part of project
                if ( Diastolic >= DiastolicHighBand || Systolic >= SystolicHighBand)
                {
                    return BPCategory.High;
                }
                else if (Diastolic >= DiastolicPreHighBand || Systolic >= SystolicPreHighBand)
                {
                    return BPCategory.PreHigh;
                }
                else if (Diastolic >= DiastolicIdealBand || Systolic >= SystolicIdealBand)
                {
                    return BPCategory.Ideal;
                }
                else
                {
                    return BPCategory.Low;
                }
            }
        }
    }
}
