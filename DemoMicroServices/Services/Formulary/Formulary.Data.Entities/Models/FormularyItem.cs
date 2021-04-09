using System.Collections.Generic;

namespace Formulary.Data.Entities.Models
{
    public class FormularyItem
    {
        public int Id { get; set; }

        public int FormularyId { get; set; }

        public string MedId { get; set; }

        public string CalculatedName { get; set; }

        public int MedClasskey { get; set; }

        public int DosageFormKey { get; set; }

        public int StrengthUOMKey { get; set; }

        public decimal StrengthUnitOfMeasure { get; set; }



        public int ConcentrationVolumeUOMKey { get; set; }

        public decimal ConcentrationVolumeUnitOfMeasure { get; set; }


        public int TotalVolumeUOMKey { get; set; }

        public decimal TotalVolumeUnitOfMeasure { get; set; }


        public IEnumerable<FormularyItemNDC> FormularyItemNDCs { get; set; }

        public FormularyItem()
        {
            FormularyItemNDCs = new List<FormularyItemNDC>();
        }
    }
}
