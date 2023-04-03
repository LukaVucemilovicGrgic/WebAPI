using Microsoft.Ajax.Utilities;
using Program.Common;
using Program.Model;
using Program.Service;
using Program.Service.Common;
using Program.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;


namespace Program.WebApi.Controllers
{

    public class BuyerController : ApiController
    {

        //DI!
        protected IBuyerService BuyerService { get; set; }
        public BuyerController(IBuyerService buyerService)
        {
            BuyerService = buyerService;
        }

        [HttpGet]
        [Route("api/buyer/getall")]
        public async Task<HttpResponseMessage> GetAllBuyersAsync()
        {
            //BuyerService service = new BuyerService();
            var buyers = await BuyerService.GetAllBuyersAsync();
            
            if(buyers != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, buyers);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("api/buyer/get")]
        public async Task<HttpResponseMessage> GetBuyerAsync(Guid Id)
        {
           // BuyerService service = new BuyerService();
            var buyer = await BuyerService.GetBuyerAsync(Id);

            if (buyer != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, buyer);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }            
        }

        [HttpPost]
        [Route("api/buyer/post")]
        public async Task<HttpResponseMessage> AddBuyerAsync(Buyer buyer)
        {
           // BuyerService service = new BuyerService();
            var newBuyer = await BuyerService.AddBuyerAsync(buyer);

            if (newBuyer != false)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Add Buyer completed.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Failed to add Buyer.");
            }
        }

        [HttpPut]
        [Route("api/buyer/put")]
        public async Task<HttpResponseMessage> UpdateBuyerAsync(Guid id, [FromBody] Buyer buyer)
        {
           // BuyerService service = new BuyerService();
            var newBuyer = await BuyerService.AddBuyerAsync(buyer);

            if (newBuyer != false)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Add Buyer completed.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Failed to add Buyer.");
            }
        }

        [HttpDelete]
        [Route("api/buyer/delete")]
        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
          //  BuyerService service = new BuyerService();
            var newBuyer = await BuyerService.DeleteBuyerAsync(id);

            if (newBuyer != false)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Delete Buyer completed.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Failed to add Buyer.");
            }
        }

        [HttpGet]
        [Route("api/buyer/getbyPSF")]
        public async Task<HttpResponseMessage> GetPagingSortingFilteringAsync([FromUri] Paging paging, [FromUri] Sorting sorting, [FromUri] Filtering filtering)   //dodajem 
        {
            List<Buyer> buyers = await BuyerService.GetPagingSortingFilteringAsync(paging, sorting, filtering);        //dodaj

            if (buyers != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, buyers);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}