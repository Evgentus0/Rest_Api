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
    public class Lab2Controller : ControllerBase
    {
        private ILab2_BL _worker;
        private static Dictionary<string, string> _tempValues = new Dictionary<string, string>();

        public Lab2Controller(ILab2_BL worker)
        {
            _worker = worker;
        }

        [HttpPost]
        [Route("find")]
        public async Task<ActionResult<string>> FindResult([FromBody] Lab2 list)
        {
            try
            {
                var result = await _worker.GetResultAsync(list.Data);
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

                var result = await Task.Run(() => _tempValues[key]);
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