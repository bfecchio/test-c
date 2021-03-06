﻿using System;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Domain.Entities.Impl
{
    [Serializable]
    [DataContract]
    public class Warehouse: Entity
    {
        #region Public Properties
        
        [DataMember]
        public int Sku { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Locality { get; set; }

        [DataMember]
        public string Type { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Product Product { get; set; }

        #endregion

        #region Constructors

        public Warehouse()
        { }

        public Warehouse(int sku, int quantity, string locality, string type)
        {
            Sku = sku;
            Type = type;
            Quantity = quantity;
            Locality = locality;
        }

        #endregion

        #region Overriden Methods

        public override int GetHashCode()
            => base.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            var other = (obj as Warehouse);

            return (Sku == other.Sku
                && Type == other.Type
                && Locality.Equals(other.Locality, StringComparison.OrdinalIgnoreCase)
            );
        }

        #endregion
    }
}
