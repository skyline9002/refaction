using AutoMapper;
using RefactionMe.Api.Infrastructure;
using RefactionMe.Api.Models;
using RefactionMe.Entity;
using RefactionMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RefactionMe.Api.Controllers
{
    [RoutePrefix("products/{productId:guid}/options")]
    public class ProductOptionsController : WebApiControllerBase
    {
        private readonly IProductOptionService _productOptionService;

        public ProductOptionsController(IProductOptionService productOptionService)
        {
            this._productOptionService = productOptionService;
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage GetOptions(HttpRequestMessage request, Guid productId)
        {
            return CreateHttpResponse(request, () =>
            {
                var entities = this._productOptionService.GetOptions(productId);

                var result = new ProductOptionsViewModel()
                {
                    Items = Mapper.Map<ProductOptionViewModel[]>(entities)
                };

                return request.CreateResponse(HttpStatusCode.OK, result);
            });
        }

        [Route("{id:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOption(HttpRequestMessage request, Guid productId, Guid id)
        {
            return CreateHttpResponse(request, () =>
            {
                var entity = this._productOptionService.GetOption(productId, id);

                var result = Mapper.Map<ProductOptionViewModel>(entity);

                return request.CreateResponse(HttpStatusCode.OK, result);
            });
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage CreateOption(HttpRequestMessage request, Guid productId, ProductOptionViewModel viewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                if (viewModel == null || !ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Parameters");
                }

                this._productOptionService.CreateOption(productId, Mapper.Map<ProductOption>(viewModel));

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [Route("{id:guid}")]
        [HttpPut]
        public HttpResponseMessage UpdateOption(HttpRequestMessage request, Guid id, ProductOptionViewModel viewModel)
        {

            return CreateHttpResponse(request, () =>
            {
                if (viewModel == null || !ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Parameters");
                }

                this._productOptionService.UpdateOption(id, Mapper.Map<ProductOption>(viewModel));

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

        [Route("{id:guid}")]
        [HttpDelete]
        public HttpResponseMessage DeleteOption(HttpRequestMessage request, Guid id)
        {
            return CreateHttpResponse(request, () =>
            {
                this._productOptionService.DeleteOption(id);
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }




    }
}
