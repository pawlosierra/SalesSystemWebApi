using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Repositories.Implements
{
    public class ConceptRepository : GenericRepository<Concept>, IConceptRepository
    {
        private readonly LESAContext lESAContext;

        public ConceptRepository(LESAContext lESAContext) : base(lESAContext)
        {
            this.lESAContext = lESAContext;
        }
    }
}
