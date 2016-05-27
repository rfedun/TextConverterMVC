using System.Collections.Generic;

namespace TextConverter.Domain.Entities
{
    public interface ITextModel
    {
        List<Sentence> SentenceList { get; }
    }
}