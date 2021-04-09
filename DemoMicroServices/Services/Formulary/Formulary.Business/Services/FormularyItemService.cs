using AutoMapper;
using BaseEventBus.Abstractions;
using Formulary.Business.IServices;
using Formulary.Business.Models;
using Formulary.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formulary.Business.Services
{
    public class FormularyItemService : IFormularyItemService
    {
        private readonly IMapper _mapper;

        public FormularyItemService(IEventBus eventBus)
        {
             _mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FormularyItem, FormularyItemForMapping>();
            }).CreateMapper();
        }
        public void Add(FormularyItem formularyItem)
        {
            throw new NotImplementedException();
        }

        public void AddFormularyItems(IEnumerable<FormularyItem> formularyItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormularyItem> GetFormularyItems(int formularyKey)
        {
            throw new NotImplementedException();
        }
    }
}
