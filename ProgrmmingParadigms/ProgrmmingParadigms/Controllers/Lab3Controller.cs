using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingParadigms_BLL.Interfaces;
using ProgrmmingParadigms.Helpers;
using ProgrmmingParadigms.Models;

namespace ProgrmmingParadigms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab3Controller : ControllerBase
    {
        private ILab3_BL _worker;
        private static Dictionary<string, string> _tempValues = new Dictionary<string, string>();
        private Mapper _mapper;

        public Lab3Controller(ILab3_BL worker)
        {
            _worker = worker;
            _mapper = new Mapper();
        }

        [HttpPost]
        [Route("find")]
        public async Task<ActionResult<string>> FindResult([FromBody] Lab3 model)
        {
            try
            {
                var automat = _mapper.GetAutomatDTO(model.Automat);

                var result = await _worker.GetResultAsync(automat, model.Length);
                var key = KeyGenerator.RandomString();

                while (_tempValues.ContainsKey(key))
                {
                    key = KeyGenerator.RandomString();
                }

                _tempValues.Add(key, result);

                return Ok("\"" + key + "\"");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{key}")]
        public async Task<ActionResult<string>> GetResult(string key)
        {
            try
            {
                if (!_tempValues.ContainsKey(key))
                    throw new Exception("Can not find value");

                var result = _tempValues[key];
                _tempValues.Remove(key);

                return Ok("\"" + result + "\"");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}