using Api.Repositories;
using Dto.Stripe.CheckoutDto;
using Dto.Stripe.Customer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using StripeGateway;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MasterController : ControllerBase
    {
        private readonly LanguageRepository _languageRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly TypeRepository _typeRepository;
        private readonly DialectRepository _dialectRepository;
        private readonly AdvertisementRepository _advertisementRepository;
        private readonly AdvertisementTabRepository _advertisementTabRepository;

        public MasterController(
            LanguageRepository languageRepository,
            CategoryRepository categoryRepository,
            TypeRepository typeRepository,
            DialectRepository dialectRepository,
            AdvertisementRepository advertisementRepository,
            AdvertisementTabRepository advertisementTabRepository)
        {
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
            _dialectRepository = dialectRepository;
            _advertisementRepository = advertisementRepository;
            _advertisementTabRepository = advertisementTabRepository;
        }

        #region Language
        [HttpGet("languages/{code}")]
        public async Task<IActionResult> GetLanguageByCode(string code)
        {
            var language = await _languageRepository.GetByCodeAsync(code);
            if (language == null) return NotFound();
            return Ok(language);
        }

        [HttpPost("languages")]
        public async Task<IActionResult> CreateLanguage([FromBody] Language language)
        {
            var createdLanguage = await _languageRepository.CreateAsync(language);
            if (createdLanguage == null) return BadRequest();
            return CreatedAtAction(nameof(GetLanguageByCode), new { code = createdLanguage.Code }, createdLanguage);
        }
        #endregion

        #region Category
        [HttpGet("categories/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel category)
        {
            var createdCategory = await _categoryRepository.CreateAsync(category);
            if (createdCategory == null) return BadRequest();
            return CreatedAtAction(nameof(GetCategoryByName), new { name = createdCategory.Name }, createdCategory);
        }
        #endregion

        #region Type
        [HttpGet("types/{name}")]
        public async Task<IActionResult> GetTypeByName(string name)
        {
            var type = await _typeRepository.GetByNameAsync(name);
            if (type == null) return NotFound();
            return Ok(type);
        }

        [HttpGet("types/active")]
        public async Task<IActionResult> GetActiveTypes()
        {
            var types = await _typeRepository.GetActiveTypesAsync();
            return Ok(types);
        }

        [HttpPost("types")]
        public async Task<IActionResult> CreateType([FromBody] TypeModel type)
        {
            var createdType = await _typeRepository.CreateAsync(type);
            if (createdType == null) return BadRequest();
            return CreatedAtAction(nameof(GetTypeByName), new { name = createdType.Name }, createdType);
        }
        #endregion

        #region Dialect
        [HttpGet("dialects/{languageId}")]
        public async Task<IActionResult> GetDialectsByLanguage(string languageId)
        {
            var dialects = await _dialectRepository.GetDialectsByLanguageAsync(languageId);
            return Ok(dialects);
        }

        [HttpPost("dialects")]
        public async Task<IActionResult> CreateDialect([FromBody] Dialect dialect)
        {
            var createdDialect = await _dialectRepository.CreateAsync(dialect);
            if (createdDialect == null) return BadRequest();
            return CreatedAtAction(nameof(GetDialectsByLanguage), new { languageId = createdDialect.LanguageId }, createdDialect);
        }
        #endregion

        #region Advertisement
        [HttpGet("advertisements/active")]
        public async Task<IActionResult> GetActiveAdvertisements()
        {
            var ads = await _advertisementRepository.GetActiveAdvertisementsAsync();
            return Ok(ads);
        }

        [HttpPost("advertisements")]
        public async Task<IActionResult> CreateAdvertisement([FromBody] Advertisement advertisement)
        {
            var createdAdvertisement = await _advertisementRepository.CreateAsync(advertisement);
            if (createdAdvertisement == null) return BadRequest();
            return CreatedAtAction(nameof(GetActiveAdvertisements), new { id = createdAdvertisement.Id }, createdAdvertisement);
        }
        #endregion

        #region AdvertisementTab
        [HttpGet("advertisementtabs/{advertisementId}")]
        public async Task<IActionResult> GetAdvertisementTabByAdvertisementId(string advertisementId)
        {
            var advertisementTab = await _advertisementTabRepository.GetByAdvertisementIdAsync(advertisementId);
            if (advertisementTab == null) return NotFound();
            return Ok(advertisementTab);
        }

        [HttpPost("advertisementtabs")]
        public async Task<IActionResult> CreateAdvertisementTab([FromBody] AdvertisementTab advertisementTab)
        {
            var createdAdvertisementTab = await _advertisementTabRepository.CreateAsync(advertisementTab);
            if (createdAdvertisementTab == null) return BadRequest();
            return CreatedAtAction(nameof(GetAdvertisementTabByAdvertisementId), new { advertisementId = createdAdvertisementTab.AdvertisementId }, createdAdvertisementTab);
        }
        #endregion
    }
}