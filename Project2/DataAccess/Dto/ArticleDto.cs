namespace DataAccess.Dto
{
    public class ArticleDto
    {
        /// <summary>
        /// Name of article
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Slogan of article
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        /// Price of article after apply discount
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Net price of article
        /// </summary>
        public decimal NetPrice { get; set; }
    }
}
