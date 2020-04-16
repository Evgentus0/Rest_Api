using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingParadigms_BLL.Implementation;
using ProgrammingParadigms_BLL.Interfaces;
using ProgrmmingParadigms.Helpers;
using ProgrmmingParadigms.Models;

namespace ProgrmmingParadigms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private ILab1_BL _worker;
        private static Dictionary<string, string> _tempValues = new Dictionary<string, string>();

        public Lab1Controller(ILab1_BL worker)
        {
            _worker = worker;
        }

        [HttpPost]
        [Route("find1")]
        public async Task<ActionResult<string>> FindResult1([FromBody] Models.Lab1 lists)
        {
            try
            {
                var result = await _worker.GetResult_Part1Async(lists.Data1);
                var key = KeyGenerator.RandomString();

                while (_tempValues.ContainsKey(key))
                {
                    key = KeyGenerator.RandomString();
                }

                _tempValues.Add(key, result);

                return Ok("\"" + key + "\"");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get1/{key}")]
        public async Task<ActionResult<string>> GetResult1(string key)
        {
            try
            {
                if (!_tempValues.ContainsKey(key))
                    throw new Exception("Can not find value");

                var result = _tempValues[key];
                _tempValues.Remove(key);

                return Ok("\"" + result + "\"");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("find2")]
        public async Task<ActionResult<string>> FindResult2([FromBody] Models.Lab1 lists)
        {
            try
            {
                var result = await _worker.GetResult_Part2Async(lists.Data2);
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
        [Route("get2/{key}")]
        public async Task<ActionResult<string>> GetResult2(string key)
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