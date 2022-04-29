﻿using System;

namespace Festival.BL.Models.ListModels
{
    public record BandMemberListModel : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }



    }
}
