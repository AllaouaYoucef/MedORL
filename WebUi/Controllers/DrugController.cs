

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
            try
            {
                List<DrugDto> listDrug = _drugManager.AllEntry();
                List<DrugViewModel> viewModel = _mapper.Map<List<DrugViewModel>>(listDrug);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the drug list.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: DrugController/Details/5
        public ActionResult Details(int? id)
        {
            _logger.LogInformation("Details action called with id: {Id}", id);

            if (id.HasValue)
            {
                try
                {
                    DrugViewModel drugViewModel = GetDetail(id.GetValueOrDefault());
                    if (drugViewModel is not null)
                    {
                        _logger.LogInformation("Drug found with id: {Id}", id);
                        return View(drugViewModel);
                    }
                    _logger.LogWarning("Drug not found with id: {Id}", id);
                    return NotFound();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while retrieving the drug details for id: {Id}", id);
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }

            _logger.LogWarning("Details action called without id");
            return NotFound();
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
            _logger.LogInformation("Create action called with DrugViewModel: {@DrugViewModel}", drugViewModel);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid. Errors: {@ModelStateErrors}", ModelState.Values.SelectMany(v => v.Errors));
                return View(drugViewModel);
            }

            try
            {
                var drugDto = _mapper.Map<DrugDto>(drugViewModel);
                _logger.LogInformation("Mapped DrugViewModel to DrugDto: {@DrugDto}", drugDto);

                _drugManager.Create(drugDto);
                _logger.LogInformation("Drug created successfully with ID: {Id}", drugDto.Id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the drug.");
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View(drugViewModel);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the drug details for id: {Id}", id);
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
                _logger.LogInformation("Delete action called with id: {Id}", id);

                // Suppression de l'élément via le manager
                _drugManager.Delete(id);
                _logger.LogInformation("Drug deleted successfully with id: {Id}", id);

                // Redirection après suppression réussie
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the drug with id: {Id}", id);

                // Ajouter un message d'erreur au ModelState pour informer l'utilisateur
                ModelState.AddModelError("", "An error occurred while trying to delete the drug.");

                // Renvoyer la vue avec des informations sur l'échec
                return Index();
            }
        }


        private DrugViewModel GetDetail(int? id)
        {
            _logger.LogInformation("GetDetail method called with id: {Id}", id);

            try
            {
                DrugDto drugDto = _drugManager.GetById(id);
                if (drugDto == null)
                {
                    _logger.LogWarning("No drug found with id: {Id}", id);
                    return null;
                }

                DrugViewModel drugViewModel = _mapper.Map<DrugViewModel>(drugDto);
                _logger.LogInformation("Drug details retrieved successfully for id: {Id}", id);
                return drugViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the drug details for id: {Id}", id);
                throw;
            }
        }
    }
}
