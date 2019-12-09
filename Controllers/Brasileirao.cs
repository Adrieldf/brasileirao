using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brasileirao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Brasileirao : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            //DbTime db = new DbTime();
            //db.GetTimes();
            DbJogo j = new DbJogo();
            string json = /*JsonConvert.SerializeObject(j.GetJogos())*/"";
            return json;
        }

        // GET api/values/5
        [HttpGet("{semResultado}")]
        public ActionResult<string> Get(bool semResultado)
        {
            DbJogo j = new DbJogo();
            string json = JsonConvert.SerializeObject(j.GetJogos(semResultado));
            return json;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            DbJogo j = new DbJogo();
            string[] param = value.Split("|");//idjogo | gols casa | gols visitante
            j.SaveJogo(int.Parse(param[0]), $"{param[1]}x{param[2]}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
