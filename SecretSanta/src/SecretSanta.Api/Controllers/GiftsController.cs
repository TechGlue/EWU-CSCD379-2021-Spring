using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private IGiftRepository Repository { get; }

        public GiftsController(IGiftRepository repository)
        {
            Repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IEnumerable<Dto.Gift> Get()
        {
            Serilog.Log.Information("Gathering Gifts.");
            return Repository.List().Select(x => Dto.Gift.ToDto(x)!);
        }

        [HttpGet("{id}")]
        public ActionResult<Dto.Gift?> Get(int id)
        {
            Serilog.Log.Information($"Gathering gifts at id: {id}");
            Dto.Gift? gift = Dto.Gift.ToDto(Repository.GetItem(id));
            if (gift is null) return NotFound();
            return gift;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult Delete(int id)
        {
            Serilog.Log.Information("Deleting gift at id: " + id);
            if (Repository.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Dto.Gift), (int)HttpStatusCode.OK)]
        public ActionResult<Dto.Gift?> Post([FromBody] Dto.Gift gift)
        {
            Serilog.Log.Information("Creating gift...");
            return Dto.Gift.ToDto(Repository.Create(Dto.Gift.FromDto(gift)!));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult Put(int id, [FromBody] Dto.UpdateGift? gift)
        {
            Serilog.Log.Information("Putting gift invoked..." + id);
            Data.Gift? foundGift = Repository.GetItem(id);
            if (foundGift is not null)
            {
                foundGift.Title = gift?.Title ?? "";
                foundGift.Id = gift!.Id;
                foundGift.Description = gift?.Description ?? "";
                foundGift.URL = gift?.Url ?? "";
                foundGift.Priority = gift!.Priority;
                foundGift.UserId = gift.UserId;

                Repository.Save(foundGift);
                return Ok();
            }
            return NotFound();
        }
    }
} 
