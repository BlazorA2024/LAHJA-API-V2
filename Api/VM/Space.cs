using System.ComponentModel.DataAnnotations;

namespace VM
{

        // ViewModel لإنشاء Space
        public class CreateSpaceVM
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int? Ram { get; set; }
            public int? CpuCores { get; set; }
            public float? DiskSpace { get; set; }
            public bool? IsGpu { get; set; }
            public bool? IsGlobal { get; set; }
            public float? Bandwidth { get; set; }
            public string Token { get; set; }
            public string SubscriptionId { get; set; }
        }

        // ViewModel لتحديث Space
        public class UpdateSpaceVM
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int? Ram { get; set; }
            public int? CpuCores { get; set; }
            public float? DiskSpace { get; set; }
            public bool? IsGpu { get; set; }
            public bool? IsGlobal { get; set; }
            public float? Bandwidth { get; set; }
            public string Token { get; set; }
            public string SubscriptionId { get; set; }
        }

        // ViewModel لعرض Space
        public class SpaceVM
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int? Ram { get; set; }
            public int? CpuCores { get; set; }
            public float? DiskSpace { get; set; }
            public bool? IsGpu { get; set; }
            public bool? IsGlobal { get; set; }
            public float? Bandwidth { get; set; }
            public string Token { get; set; }
            public string SubscriptionId { get; set; }
            public SubscriptionVM Subscription { get; set; }
            public List<RequestVM> Requests { get; set; }
        }

    public class CreateSpaceRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ram { get; set; }
        public int CpuCores { get; set; }
        public float DiskSpace { get; set; }
        public bool IsGpu { get; set; }
        public bool IsGlobal { get; set; }
        public float Bandwidth { get; set; }
        public string Token { get; set; }
        public string SubscriptionId { get; set; }
    }

    public class UpdateSpaceRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ram { get; set; }
        public int CpuCores { get; set; }
        public float DiskSpace { get; set; }
        public bool IsGpu { get; set; }
        public bool IsGlobal { get; set; }
        public float Bandwidth { get; set; }
    }

    public class SpaceResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ram { get; set; }
        public int CpuCores { get; set; }
        public float DiskSpace { get; set; }
        public bool IsGpu { get; set; }
        public bool IsGlobal { get; set; }
        public float Bandwidth { get; set; }
    }

    // ViewModel لعرض Subscription
    public class SubscriptionVM
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        // ViewModel لعرض Request
        public class RequestVM
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        // ViewModel للبحث عن Spaces
        public class SearchSpaceVM
        {
            public string Name { get; set; }
            public int? Ram { get; set; }
            public float? Bandwidth { get; set; }
        }
    }

