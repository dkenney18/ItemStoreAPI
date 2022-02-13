using System.Collections.Generic;
using System.Linq;
using ItemStoreForSimpleAdventureGame.Models;
using ItemStoreForSimpleAdventureGame.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemStoreForSimpleAdventureGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackpackController : ControllerBase
    {
        private readonly BackpackService _backpackService;

        public BackpackController(BackpackService backpackService)
        {
            _backpackService = backpackService;
        }

        [HttpGet]
        public ActionResult<List<Backpack>> Get() =>
            _backpackService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBackpack")]
        public ActionResult<List<Backpack>> Get(string id)
        {
            var backpack = _backpackService.Get(id);

            if (backpack == null)
            {
                return NotFound();
            }

            return backpack;
        }

        [HttpPost]
        public ActionResult<Backpack> Create(Backpack backpack)
        {
            _backpackService.Create(backpack);
            return CreatedAtRoute("GetBackpack", new { id = backpack.OwnerID }, backpack);
        }

        [HttpPut]
        public IActionResult Update(Backpack backpack)
        {
            if (backpack == null)
            {
                return NotFound();
            }

            _backpackService.Update(backpack);

            return NoContent();
        }

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string ownerID)
        //{
        //    var backpacks = _backpackService.Get(ownerID);

        //    if (backpacks == null)
        //    {
        //        return NotFound();
        //    }

        //    _backpackService.Remove(ownerID);

        //    return NoContent();
        //}

        [HttpDelete]
        public IActionResult DeleteItem(Backpack backpack)
        {
            var backpacks = _backpackService.Get(backpack.OwnerID);

            if (backpacks == null)
            {
                return NotFound();
            }

            _backpackService.RemoveItem(backpack);

            return NoContent();
        }
    }
}
