﻿using BelezaNaWeb.Domain.Enums;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class EditProductCommand : CommandBase<bool>
    {
        #region Public Properties
        
        public long Sku { get; set; }
        public string Name { get; set; }
        public EditProductInventoryCommand Inventory { get; set; }

        #endregion
    }

    public sealed class EditProductInventoryCommand
    {
        #region Public Properties

        public IEnumerable<EditProductWarehouseCommand> Warehouses { get; set; }

        #endregion
    }

    public sealed class EditProductWarehouseCommand
    {
        #region Public Properties

        public int Quantity { get; set; }
        public string Locality { get; set; }
        public WarehouseTypes Type { get; set; }

        #endregion
    }
}
