using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDrugManager
    {
        /// <summary>
        /// Creates a new drug entry in the system
        /// </summary>
        /// <param name="drugDto">An DTO containing the details of the drug to create.</param>
        void Create(DrugDto drugDto);


        /// <summary>
        /// Updates an existing drug entry in the system.
        /// </summary>
        /// <param name="drugDto">An object containing the updated details of the drug.</param>
        void Update(DrugDto drugDto);


        /// <summary>
        /// Deletes a drug entry from the system based on its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the drug to delete.</param>

        void Delete(int id);

        /// <summary>
        /// Retrieves a drug entry by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the drug to retrieve.</param>
        /// <returns>
        /// A <see cref="DrugDto"/> object representing the drug if found; otherwise, null.
        /// </returns>
        DrugDto GetById(int? id);


        /// <summary>
        /// Retrieves all drug entries from the system.
        /// </summary>
        /// <returns>A list of <see cref="DrugDto"/> objects representing all drugs.</returns>
        List<DrugDto> AllEntry();

    }
}
