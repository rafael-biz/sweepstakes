using Microsoft.AspNetCore.Mvc;
using Sweepstakes.Services.SweepstakeCreate;
using Sweepstakes.Services.SweepstakeDetails;
using Sweepstakes.Services.SweepstakeEnter;
using Sweepstakes.Services.SweepstakeList;
using System.Collections.Generic;

namespace Sweepstakes.Web.Controllers
{
    [Route("api/sweepstakes")]
    [ApiController]
    public class SweepstakesController : ControllerBase
    {
        private readonly SweepstakeListService listService;
        private readonly SweepstakeCreateService createService;
        private readonly SweepstakeDetailsService detailsService;
        private readonly SweepstakeEnterService enterService;

        public SweepstakesController(
            SweepstakeListService listService,
            SweepstakeCreateService createService,
            SweepstakeDetailsService detailsService,
            SweepstakeEnterService enterService)
        {
            this.listService = listService;
            this.createService = createService;
            this.detailsService = detailsService;
            this.enterService = enterService;
        }

        /// <summary>
        /// Returns all sweepstakes.
        /// </summary>
        [HttpGet]
        public IEnumerable<SweepstakeListDTO> Get()
        {
            return listService.GetAll();
        }

        /// <summary>
        /// Creates a Sweepstake.
        /// </summary>
        [HttpPost]
        public SweepstakeDetailsDTO Create(SweepstakeCreateDTO dto)
        {
            var entity = createService.Create(dto);

            return detailsService.Get(entity.Id);
        }

        /// <summary>
        /// Returns a sweepstake details.
        /// </summary>
        [HttpGet("{sweepstakeId}")]
        public SweepstakeDetailsDTO Details(string sweepstakeId)
        {
            return detailsService.Get(sweepstakeId);
        }

        /// <summary>
        /// Enter on a sweepstake.
        /// </summary>
        [HttpPost("{sweepstakeId}/enter")]
        public ActionResult Enter(string sweepstakeId, EntrantDTO dto)
        {
            enterService.AddEntrant(sweepstakeId, dto);

            return Ok();
        }
    }
}
