
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Managers
{
    
    public class DrugManager : IDrugManager
    {

        private readonly IMapper _mapper;

        public DrugManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<DrugDto> AllEntry()
        {
          
            throw new NotImplementedException();
        }

        public void Create(DrugDto drugDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DrugDto GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(DrugDto drugDto)
        {
            throw new NotImplementedException();
        }
    }
}
