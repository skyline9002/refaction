using AutoMapper;
using RefactionMe.Api.Infrastructure;
using RefactionMe.Api.Models;
using RefactionMe.Entity;
using RefactionMe.Service;
using RefactionMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RefactionMe.Api.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : WebApiControllerBase
    {
        private readonly IProducService _productService;

        public ProductsController(IProducService productService)
        {
            this._productService = productService;
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var entities = this._productService.GetAll();

                var result = new ProductsViewModel()
                {
                    Items = Mapper.Map<ProductViewModel[]>(entities),
                };

                return request.CreateResponse(HttpStatusCode.OK, result);
            });
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage SearchByName(HttpRequestMessage request, string name)
        {
            return CreateHttpResponse(request, () =>
            {
                var entities = this._productService.SearchByName(name);

                var result = new ProductsViewModel()
                {
                    Items = Mapper.Map<ProductViewModel[]>(entities)
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            });
        }

        [Route("{id:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(HttpRequestMessage request, Guid id)
        {
            return CreateHttpResponse(request, () =>
            {
                var entity = this._productService.GetProduct(id);

                var result = Mapper.Map<ProductViewModel>(entity);

                return request.CreateResponse(HttpStatusCode.OK, result);
            });
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel viewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                if (viewModel == null || !ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Parameters Invalid.");
                }

                this._productService.Create(Mapper.Map<Product>(viewModel));

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }


        [Route("{id:guid}")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, Guid id, ProductViewModel viewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                if (viewModel == null || !ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, "Parameters Invalid");
                }

                this._productService.Update(id, Mapper.Map<Product>(viewModel));

                return request.CreateResponse(HttpStatusCode.OK);
            });
        }


        [Route("{id:guid}")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, Guid id)
        {
            return CreateHttpResponse(request, () =>
            {
                this._productService.Delete(id);
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}
