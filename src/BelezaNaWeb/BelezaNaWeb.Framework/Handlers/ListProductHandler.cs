﻿using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Dtos;
using BelezaNaWeb.Domain.Queries;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class ListProductHandler : GenericHandler<ListProductQuery, ListProductResult>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructrors

        public ListProductHandler(ILogger<ListProductHandler> logger
            , IMediator mediator
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<ListProductResult> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.PagedList(pageIndex: request.Page, pageSize: request.Offset,
                orderBy: x => x.OrderBy(p => p.Name),
                include: x => x.Include(p => p.Warehouses)
            );

            return new ListProductResult(page: request.Page, offset: request.Offset, total: products.Total)
            {
                Data = products.Collection.Select(x => new ProductDto
                {
                    Sku = x.Sku,
                    Name = x.Name,
                    Inventory = new InventoryDto
                    {
                        Warehouses = x.Warehouses.Select(x => new WarehouseDto(x.Locality, x.Quantity, x.Type))
                    }
                })
            };
        }

        #endregion
    }
}
