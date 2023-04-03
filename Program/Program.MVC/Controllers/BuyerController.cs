using Program.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Program.WebApi.Controllers
{

    public class BuyerController : Controller
    {

        //DI!
        protected IBuyerService BuyerService { get; set; }
        public BuyerController(IBuyerService buyerService)
        {
            BuyerService = buyerService;
        }

        [HttpGet]
        //[Route("Buyer/Index")]
        public async Task<ActionResult> GetAllBuyersAsync()
        {
            var buyers = await BuyerService.GetAllBuyersAsync();

            if (buyers != null)
            {
                var mappedBuyers = buyers.Select(b => new BuyerViewModel
                {
                    Id = b.Id,
                    BuyerName = b.BuyerName,
                    PersonalIdentificationNumber = b.PersonalIdentificationNumber,
                    TicketId = b.TicketId
                });

                return View(mappedBuyers);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //[HttpGet]
        //[Route("Buyer/Details/{id}")]
        //public async Task<ActionResult> GetBuyerAsync(Guid Id)
        //{
        //    // BuyerService service = new BuyerService();
        //    var buyer = await BuyerService.GetBuyerAsync(Id);

        //    if (buyer != null)
        //    {
        //        var viewModel = new BuyerViewModel
        //        {
        //            Id = buyer.Id,
        //            BuyerName = buyer.BuyerName,
        //            PersonalIdentificationNumber = buyer.PersonalIdentificationNumber,
        //            TicketId = buyer.TicketId
        //        };

        //        return View(viewModel);
        //    }
        //    else
        //    {
        //        return HttpNotFound();
        //    }
        //}

        //[HttpPost]
        //[Route("api/buyer/post")]
        //public async Task<ActionResult> AddBuyerAsync(Buyer buyer)
        //{
        //    // BuyerService service = new BuyerService();
        //    var newBuyer = await BuyerService.AddBuyerAsync(buyer);

        //    if (newBuyer != false)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Accepted, "Add Buyer completed.");
        //    }
        //    else
        //    {
        //        return HttpNotFound();
        //    }
        //}

        //[HttpPut]
        //[Route("api/buyer/put")]
        //public async Task<ActionResult> UpdateBuyerAsync(Guid id, [FromBody] Buyer buyer)
        //{
        //    // BuyerService service = new BuyerService();
        //    var newBuyer = await BuyerService.AddBuyerAsync(buyer);

        //    if (newBuyer != false)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Accepted, "Add Buyer completed.");
        //    }
        //    else
        //    {
        //        return HttpNotFound();
        //    }
        //}

        //[HttpDelete]
        //[Route("Buyer/{id}")]
        //public async Task<ActionResult> DeleteBuyerAsync(Guid id)
        //{
        //    //  BuyerService service = new BuyerService();
        //    bool buyer = await BuyerService.DeleteBuyerAsync(id);

        //    if (buyer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        //[HttpGet]
        //[Route("api/buyer/getbyPSF")]
        //public async Task<ActionResult> GetPagingSortingFilteringAsync([FromUri] Paging paging, [FromUri] Sorting sorting, [FromUri] Filtering filtering)   //dodajem 
        //{
        //    List<Buyer> buyers = await BuyerService.GetPagingSortingFilteringAsync(paging, sorting, filtering);        //dodaj

        //    if (buyers != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, buyers);
        //    }
        //    else
        //    {
        //        return HttpNotFound();
        //    }
        //}

    }
}