using System.ComponentModel.DataAnnotations;

namespace VM
{

    public class VMPlanOnes
    {
        public string? Id { set; get; }
        public string? Lg { set; get; }
    }


    public class FAQItemCreate
    {
        public Dictionary<string, string>? Question { get; set; } // الأسئلة باللغتين
        public Dictionary<string, string>? Answer { get; set; }  // الإجابات باللغتين

        public string? Tag { get; set; }


    }
    public class FAQItemView
    {
        public string? Question { get; set; } // الأسئلة باللغتين
        public string? Answer { get; set; }  // الإجابات باللغتين
        public string? Tag { get; set; }

    }

    class CategoryCreate
    {
        public string Id { get; set; }
        public Dictionary<string, string> Name { get; set; }
        public Dictionary<string, string> Description { get; set; }

        public bool Active { get; set; }

        public string Image { get; set; }
        public string? UrlUsed { get; set; }

        public int CountFalvet { get; set; }

        public int Rateing { get; set; }
    }

    class CategoryView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }

        public bool Active { get; set; }

        public string Image { get; set; }
        public string? UrlUsed { get; set; }

        public int CountFalvet { get; set; }

        public int Rateing { get; set; }
    }


    public class LanguageCreate
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public Dictionary<string, string> Name { get; set; }
    }

    public class CategoryModelCreate
    {
        [Required]
        public Dictionary<string, string> Name { get; set; }

        public Dictionary<string, string> Description { get; set; }
    }

    public class TypeModelCreate
    {
        [Required]
        public Dictionary<string, string> Name { get; set; }

        public Dictionary<string, string> Description { get; set; }

        public bool Active { get; set; }

        public string? Image { get; set; }
    }

    public class DialectCreate
    {
        [Required]
        public Dictionary<string, string> Name { get; set; }

        public Dictionary<string, string> Description { get; set; }

        [Required]
        public string LanguageId { get; set; }
    }

    public class AdvertisementCreate
    {
        [Required]
        public Dictionary<string, string> Title { get; set; }

        public Dictionary<string, string> Description { get; set; }

        public string? Image { get; set; }

        public bool Active { get; set; } = true;

        public string? Url { get; set; }

        public ICollection<AdvertisementTabCreate>? AdvertisementTabs { get; set; }
    }

    public class AdvertisementTabCreate
    {
        [Required]
        public string AdvertisementId { get; set; }

        public Dictionary<string, string> Title { get; set; }

        public Dictionary<string, string> Description { get; set; }

        public string? ImageAlt { get; set; }


    }
}
