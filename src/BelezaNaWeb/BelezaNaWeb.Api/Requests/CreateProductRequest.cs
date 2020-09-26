﻿using MediatR;
using Newtonsoft.Json;
using BelezaNaWeb.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Requests
{
    public sealed class CreateProductRequest : IBaseRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("sku")]
        public long Sku { get; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; }

        [Required]
        [JsonProperty("inventory")]
        public CreateProductInventoryRequest Inventory { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public CreateProductRequest(long sku, string name, CreateProductInventoryRequest inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }

        #endregion
    }

    public sealed class CreateProductInventoryRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("warehouses")]
        public IEnumerable<CreateProductWarehouseRequest> Warehouses { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public CreateProductInventoryRequest(IEnumerable<CreateProductWarehouseRequest> warehouses)
        {
            Warehouses = warehouses;
        }

        #endregion
    }

    public sealed class CreateProductWarehouseRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("quantity")]
        public int Quantity { get; }

        [Required]
        [JsonProperty("locality")]
        public string Locality { get; }

        [Required]
        [JsonProperty("type")]
        public WarehouseTypes Type { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public CreateProductWarehouseRequest(int quantity, string locality, WarehouseTypes warehouseTypes)
        {
            Type = Type;
            Quantity = quantity;
            Locality = locality;
        }

        #endregion
    }
}
