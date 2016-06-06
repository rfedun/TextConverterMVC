using TextConverter.Domain.Entities;

namespace TextConverter.Domain.Interfaces
{
    public interface ITextConverter
    {
        string Convert(ITextModel textModel);
    }
}