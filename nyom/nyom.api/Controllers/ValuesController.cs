using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nyom.domain.Message;
using nyom.infra.CrossCutting.Helper;

namespace nyom.api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
	    private readonly IMessageService _messageService;

	    public ValuesController(IMessageService messageService)
	    {
		    _messageService = messageService;
	    }

	    // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
           
			for (var i = 0; i <= 10; i++)
			{
				var message = new Message
				{
					CampanhaId = i.ToString(),
					DataEntregaMensagens = DateTime.Now,
					DataCriacao = DateTime.Now,
					Id = i.ToString(),
					Mensagem = "teste",
					Status = WorkflowStatus.Finished,
					TemplateId = i.ToString()
				};
				_messageService.SaveOneAsync(message);
			}
	        return new string[] { "value1", "value2" };
		}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
