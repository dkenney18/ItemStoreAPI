using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ItemStoreForSimpleAdventureGame.Models;
using ItemStoreForSimpleAdventureGame.Services;

namespace ItemStoreForSimpleAdventureGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemStoreService _itemService;

        public ItemController(ItemStoreService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() =>
            _itemService.Get();

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        public ActionResult<Item> Get(string id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            _itemService.Create(item);

            return CreatedAtRoute("GetItem", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Item itemIn)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Remove(item.Id);

            return NoContent();
        }
    }
}
