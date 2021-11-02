using SalesSystem.Models;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services.Implements
{
    public class ConceptService : GenericService<Concept>, IConceptService
    {
        private readonly IConceptRepository conceptRepository;

        public ConceptService(IConceptRepository conceptRepository) : base(conceptRepository)
        {
            this.conceptRepository = conceptRepository;
        }
    }
}
