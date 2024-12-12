using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.SharedKernel;
using Wpm.Management.Domain.Entities;
using Wpm.Management.SharedKernel.ValueObjects;

namespace Wpm.Management.SharedKernel
{
    public interface IBreedService
    {
        Breed? GetBreed(Guid id);
    }
}
public class FakeBreedService : IBreedService
{
    public readonly List<Breed> breeds =
    [
        new Breed(Guid.NewGuid(), "Golden Retriever", new WeightRange(10m, 20m), new WeightRange(11m, 18m)),
        new Breed(Guid.NewGuid(), "German Shepherd", new WeightRange(28m, 40m), new WeightRange(24m, 34m)),
    ];
    public Breed? GetBreed(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Breed is not valid");
        }
        var result = breeds.Find(breeds => breeds.Id == id);
        return result ?? throw new ArgumentException("Breed not found");
    }
}
