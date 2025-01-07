using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class DrugController : Controller
    {
        private readonly ILogger<DrugController> _logger;
        private readonly IMapper _mapper;
        private readonly IDrugManager _drugManager;

        public DrugController(IMapper mapper, IDrugManager drugManager, ILogger<DrugController> logger)
        {
            _mapper = mapper;
            _drugManager = drugManager;
            _logger = logger;
        }


        // GET: DrugController
        public ActionResult Index()
        {
            _logger.LogInformation("Page d'accueil visitée");
            _logger.LogWarning("Ceci est un avertissement");
            _logger.LogError("Ceci est une erreur");
            List<DrugDto> listDrug = _drugManager.AllEntry();
            List < DrugViewModel > viewModel = _mapper.Map<List<DrugViewModel>>(listDrug);

            return View(viewModel);
        }

        // GET: DrugController/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: DrugController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrugViewModel drugViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Renvoyer la vue avec les données actuelles pour permettre la correction
                return View(drugViewModel);
            }

            try
            {
                // Mapper le ViewModel en DTO
                var drugDto = _mapper.Map<DrugDto>(drugViewModel);

                // Ajouter le medicament via le manager
                _drugManager.Create(drugDto);

                // Rediriger vers l'action Index après succès
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Gérer l'exception et loguer le message pour déboguer
                // Exemple : _logger.LogError(ex, "Error while creating company.");

                // Ajouter un message d'erreur au ModelState
                ModelState.AddModelError("", "An error occurred while processing your request.");

                // Renvoyer la vue avec les données actuelles
                return View(ex);
            }
        }

        // GET: DrugController/Edit/5
        public ActionResult Edit(int id)
        {
            return Details(id);
        }

        // POST: DrugController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest("ID is required.");
                }

                DrugViewModel drugViewModel = GetDetail(id.GetValueOrDefault());
                    if (drugViewModel is not null)

                    {
                        return View(drugViewModel);
                    }

                    return NotFound();
                

               
            }
            catch
            {
                        // Log the exception details for debugging (optional)
        // Example: _logger.LogError(ex, "Error occurred in Create action.");
        return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: DrugController/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: DrugController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Suppression de l'élément via le manager
                _drugManager.Delete(id);

                // Redirection après suppression réussie
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Loguer l'exception pour débogage (facultatif)
                // Exemple : _logger.LogError(ex, "Error while deleting drug with ID {id}", id);

                // Ajouter un message d'erreur au ModelState pour informer l'utilisateur
                ModelState.AddModelError("", "An error occurred while trying to delete the drug.");

                // Renvoyer la vue avec des informations sur l'échec
                // a cree la vue avec l'echec
                return Index();
            }
        }


        private DrugViewModel GetDetail(int? id)
        {
            DrugDto drugDto = _drugManager.GetById(id);
            DrugViewModel drugViewModel = _mapper.Map<DrugViewModel>(_drugManager.GetById(id));
            return (drugViewModel);

        }
    }
}
