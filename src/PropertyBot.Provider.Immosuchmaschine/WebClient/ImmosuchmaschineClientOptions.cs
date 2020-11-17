using System.Collections.Generic;

namespace PropertyBot.Provider.OhneMakler.WebClient
{
    internal record ImmosuchmaschineClientOptions
    {
        public IEnumerable<string> DistrictIds { get; set; } = new List<string>();

        public IEnumerable<string> MuncipalIds { get; set; } = new List<string>();

        public IEnumerable<string> ProvinceIds { get; set; } = new List<string>();

        public string Type { get; set; }

        public int PriceFrom { get; set; }

        public int PriceTo { get; set; }

        public int SizeFrom { get; set; }

        public int SizeTo { get; set; }
    }
}
