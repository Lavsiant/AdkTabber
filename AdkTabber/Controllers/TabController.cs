using AdkTabber.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.TabModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TabController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITabService _tabService;

        public TabController(IMapper mapper, ITabService tabService)
        {
            _mapper = mapper;
            _tabService = tabService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<Tab>> GetTabById(int id)
        {
            var result = await _tabService.GetByIdAsync(id);
            if (result.Succeeded)
            {
                return result.Model;
            }
            return BadRequest("Tab not found");
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateTabs(TabsCreateViewModel model)
        {
            var tabs = model.GuitarTabs.Cast<Tab>().ToList();
            tabs.AddRange(model.DrumTabs.Cast<Tab>());
            var result = await _tabService.CreateTabs(tabs, model.SongId);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Error);
        }

    }
}
