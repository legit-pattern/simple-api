using Microsoft.AspNetCore.Mvc;
using simple_api.Engine;

namespace simple_api.Controllers
{
    [Route("/")]
    public class TravellerController : ControllerBase
    {
        public BoardingCardsHelper _boardingCardsHelper { get; set; }

        public TravellerController(BoardingCardsHelper boardingCardsHelper)
        {
            _boardingCardsHelper = boardingCardsHelper;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] List<string> collection)
        {
            return _boardingCardsHelper.OrganizeBoardingCards(collection);
        }
    }
}
