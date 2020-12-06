using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetConf.Xncf.Admin.Services;
using Senparc.Ncf.Utility;
using Senparc.Ncf.Core.Models;
using Senparc.CO2NET.Trace;
using NetConf.Xncf.Admin.Models.DatabaseModel;
using NetConf.Xncf.Admin.Models.DatabaseModel.Dto;
using AutoMapper;

namespace NetConf.Xncf.Admin.Controllers
{
    /// <summary>
    /// 消息接口
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1")]
    public class UserController : BaseController
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 宾客登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GuestLoginAsync()
        {
            try
            {
                Random random = new Random();
                int iRan = random.Next(100000, 999999);
                UserDto dto = new UserDto()
                {
                    NickName = $"昵称{iRan}",
                    Account = $"U{iRan}",
                    Password = "123456",
                    Name = $"姓名{iRan}",
                    Gender = "男",
                    Balance = 1000
                };
                var response = await userService.CreateOrUpdateAsync(dto);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
