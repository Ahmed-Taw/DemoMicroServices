using System;
using System.Collections.Generic;
using System.Text;

namespace Formulary.Data.Entities.Models
{
    public class FormularyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Identifier { get; set; }

        public IEnumerable<FormularyItem> FormularyItems { get; set; }

        public IEnumerable<ReferenceDataItem> ReferenceDataItems { get; set; }

        public FormularyModel()
        {
            FormularyItems = new List<FormularyItem>();
            ReferenceDataItems = new List<ReferenceDataItem>();
        }


    }
}
