namespace ForKazan
{
    using ForKazan.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IntermediatePoint
    {
        public string Id { get; set; }

        public int Azimut { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [StringLength(128)]
        public string BusRoute_Id { get; set; }

        public virtual BusRoute BusRoute { get; set; }
    }
}
