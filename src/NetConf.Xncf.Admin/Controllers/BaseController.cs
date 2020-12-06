
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetConf.Xncf.Admin.Models.DatabaseModel.VO;
using NetConf.Xncf.Admin.Services;
using Senparc.Ncf.Core.Cache;

namespace NetConf.Xncf.Admin.Controllers
{
    public class BaseController : ControllerBase
    {

        public IActionResult Success(object data)
        {
            var response = new BaseResult<object>(200, "请求成功", data);
            return Ok(response);
        }

        public IActionResult Fail(object data)
        {
            var response = new BaseResult<object>(201, "请求失败", data);
            return Fail(response);
        }
    }
}
