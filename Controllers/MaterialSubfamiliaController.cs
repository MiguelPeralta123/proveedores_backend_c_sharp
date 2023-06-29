﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_subfamilia")]
    public class MaterialSubfamiliaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialSubfamiliaModel>>> getSubfamilias()
        {
            var function = new MaterialSubfamiliaData();
            var list = await function.getSubfamilias();
            return list;
        }
    }
}