﻿using Newtonsoft.Json;
using BelezaNaWeb.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Domain.Queries
{
    public sealed class GetProductQuery : QueryBase<GetProductResult>
    {
        #region Public Properties

        [Required]
        [JsonProperty("sku")]
        public long Sku { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public GetProductQuery(long sku)
            => Sku = sku;

        #endregion
    }

    public sealed class GetProductResult : ProductDto
    { }
}
