﻿using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery= new() { PageRequest = pageRequest };
            ModelListModel modelListModel = await Mediator.Send(getListModelQuery);
            return Ok(modelListModel);
        }
        [HttpPost]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,Dynamic dynamic)
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery= new() { PageRequest = pageRequest, Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}
