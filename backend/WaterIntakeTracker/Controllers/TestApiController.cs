using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WaterIntakeTracker.DataLayer;
using WaterIntakeTracker.Models;
using WaterIntakeTracker.Models.DbHelper;

namespace WaterIntakeTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestApiController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        public TestApiController(ApplicationDbContext _DbContext){
            _dbHelper = new DbHelper(_DbContext);
        }

        [HttpGet]
        [Route("GetTestData")]
        public IActionResult Get()
        {
            ApiResponseType responseType = ApiResponseType.Success;
            try{
                IEnumerable<TestModel> datas = _dbHelper.GetTestModels();
                
                if(!datas.Any()){
                    responseType = ApiResponseType.NotFound;
                }
                return Ok(ApiResponseHandler.GetAppResponse(responseType, datas));
            }
            catch(Exception ex){
                return BadRequest(ApiResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("GetTestData/{id}")]
        public IActionResult Get(int id)
        {
            ApiResponseType responseType = ApiResponseType.Success;
            try{
                TestModel data = _dbHelper.GetTestModelsById(id);
                
                if(data == null){
                    responseType = ApiResponseType.NotFound;
                }
                return Ok(ApiResponseHandler.GetAppResponse(responseType, data));
            }
            catch(Exception ex){
                return BadRequest(ApiResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("SaveData")]
        public IActionResult Post([FromBody] TestModel testModel)
        {
            ApiResponseType responseType = ApiResponseType.Success;
            try{
                _dbHelper.SaveData(testModel);
                return Ok(ApiResponseHandler.GetAppResponse(responseType, testModel));
            }
            catch(Exception ex){
                return BadRequest(ApiResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("UpdateData")]
        public IActionResult Update([FromBody] TestModel testModel)
        {
            ApiResponseType responseType = ApiResponseType.Success;
            try{
                _dbHelper.SaveData(testModel);
                return Ok(ApiResponseHandler.GetAppResponse(responseType, testModel));
            }
            catch(Exception ex){
                return BadRequest(ApiResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("DeleteData/{id}")]
        public IActionResult Delete(int id)
        {
            ApiResponseType responseType = ApiResponseType.Success;
            try{
                 _dbHelper.DeleteData(id);
                 return Ok(ApiResponseHandler.GetAppResponse<object>(responseType, null));
            }
            catch(Exception ex){
                return BadRequest(ApiResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
