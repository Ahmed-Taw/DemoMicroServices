using Formulary.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formulary.Business.IServices
{
    public interface IFormularyItemService
    {
        public void AddFormularyItems(IEnumerable<FormularyItem> formularyItem);

        public void Add(FormularyItem formularyItem);

        public IEnumerable<FormularyItem> GetFormularyItems(int formularyKey);


    }
}
