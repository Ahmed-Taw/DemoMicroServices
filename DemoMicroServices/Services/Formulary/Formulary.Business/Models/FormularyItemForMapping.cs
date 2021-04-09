using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulary.Business.Models
{
    public class FormularyItemForMapping
    {
        public int Id { get; set; }

        public string MedId { get; set; }

        public string CalculatedName { get; set; }

        public int MedClass { get; set; }

        public int DosageForm { get; set; }

        public int StrengthUOM { get; set; }

        public decimal StrengthUnitOfMeasure { get; set; }



        public int ConcentrationVolumeUOM { get; set; }

        public decimal ConcentrationVolumeUnitOfMeasure { get; set; }


        public int TotalVolumeUOM { get; set; }

        public decimal TotalVolumeUnitOfMeasure { get; set; }

    }
}
