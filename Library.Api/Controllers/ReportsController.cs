using Library.Dtos;
using System.Linq;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.Infrastructure;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsRepository reportsController;
        public ReportsController(IReportsRepository reportsController)
        {
            this.reportsController = reportsController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthorId(Guid authorId)
        {
            var getbobyAuId=await reportsController.GetBooksByAuthorIdAsync(authorId);
            return Ok(getbobyAuId);
        }

        [HttpGet("average")]
        public async Task<ActionResult> Average()
        {
            var bookCount = await reportsController.GetAverage();
            return Ok(bookCount);
        }
    }
}