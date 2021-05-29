using DataAccess.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportDataController : ControllerBase
    {
        private readonly ILogger<ExportDataController> _logger;
        private readonly IArticleService _articleService;

        public ExportDataController(ILogger<ExportDataController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        public IEnumerable<ArticleDto> Get(string date)
        {
            DateTime datetime;
            if (DateTime.TryParse(date, out datetime))
            {
                return _articleService.GetPriceAllArticlesByDate(datetime);
            }
            return new List<ArticleDto>();
        } 
    }
}