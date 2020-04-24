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
    public class Lab4Controller : ControllerBase
    {
        private ILab4_BL _worker;
        private static Dictionary<string, bool> _tempValues = new Dictionary<string, bool>();
        private static Dictionary<string, Lab4> _tempValuesWithDetails = new Dictionary<string, Lab4>();
        private Mapper _mapper;

        public Lab4Controller(ILab4_BL worker)
        {
            _worker = worker;
            _mapper = new Mapper();
        }

        [HttpPost]
        [Route("find")]
        public async Task<ActionResult<string>> FindResult([FromBody] Grammar model)
        {
            try
            {
                var grammar = _mapper.GetGrammarDTO(model);

                var result = await _worker.CheckForLL1Async(grammar);
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

        [HttpPost]
        [Route("findWithDetails")]
        public async Task<ActionResult<string>> FindResultWithDetails([FromBody] Grammar model)
        {
            try
            {
                var grammar = _mapper.GetGrammarDTO(model);

                var data = await _worker.CheckForLL1WithDetailsAsync(grammar);

                Lab4 result = _mapper.GetLab4(data);

                var key = KeyGenerator.RandomString();

                while (_tempValues.ContainsKey(key))
                {
                    key = KeyGenerator.RandomString();
                }

                _tempValuesWithDetails.Add(key, result);

                return Ok("\"" + key + "\"");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getWithDetails/{key}")]
        public async Task<ActionResult<Lab4>> GetResultWithDetails(string key)
        {
            try
            {
                if (!_tempValuesWithDetails.ContainsKey(key))
                    throw new Exception("Can not find value");

                var result = _tempValuesWithDetails[key];
                _tempValuesWithDetails.Remove(key);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}