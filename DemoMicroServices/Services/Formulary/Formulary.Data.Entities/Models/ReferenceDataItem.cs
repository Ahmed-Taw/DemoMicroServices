namespace Formulary.Data.Entities.Models
{
    public class ReferenceDataItem
    {
        public int ReferenceDataItemKey { get; set; }

        public int FormularyKey { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int IsStrength { get; set; }

        public int IsVolume { get; set; }

    }
}
