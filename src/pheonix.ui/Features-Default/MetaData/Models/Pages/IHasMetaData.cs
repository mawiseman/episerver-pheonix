using Features.MetaData.Models.Blocks;

namespace Features.MetaData.Models.Pages
{
    public interface IHasMetaData
    {
        MetaDataBlock MetaData { get; set; }
    }
}