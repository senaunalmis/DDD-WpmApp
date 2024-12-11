﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Management.Domain.ValueObjects
{
    public record class BreedId
    {
        private readonly IBreedService breedService;
        public Guid Value { get; init; }
        public BreedId(Guid value, IBreedService breedService)
        {
            this.breedService = breedService;
            ValidateBreed(value);
            Value = value;
        }

        private void ValidateBreed(Guid value)
        {
            if(breedService.GetBreed(value) == null)
            {
                throw new ArgumentException("Breed is not valid");
            }
        }
    }
}
