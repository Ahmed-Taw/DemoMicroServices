using BaseEventBus.Abstractions;
using Formulary.MessagebusEvents;
using Formulary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulary.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormularyItemController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public FormularyItemController(IEventBus eventBus)
        {
            this._eventBus = eventBus;
        }
        [Route("Items")]
        [HttpGet]
        public IEnumerable<FormularyItem> GetFormularyItems()
        {
            return new List<FormularyItem>();
        }

        [HttpPost]
        public void CreateFormularyItems([FromBody] IEnumerable<FormularyItem> formularyItems)
        {
            var messageEvent = new FormularyItemCreatedIntegrationEvent()
            {
                FormularyItems = formularyItems.ToList()
            };
            _eventBus.Publish(messageEvent);
        }

        [HttpPut]
        public void EditFormularyItem([FromBody] FormularyItem formularyItem)
        {

        }
    }
}
