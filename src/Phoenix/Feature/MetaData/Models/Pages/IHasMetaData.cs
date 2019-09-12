using Feature.MetaData.Models.Blocks;

namespace Feature.MetaData.Models.Pages
{
    public interface IHasMetaData
    {
        MetaDataBlock MetaData { get; set; }
    }
}