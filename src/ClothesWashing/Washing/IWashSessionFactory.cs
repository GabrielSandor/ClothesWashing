using System.Collections.Generic;

namespace ClothesWashing.Washing
{
    public interface IWashSessionFactory
    {
        WashSession BuildWashSession(ISet<string> clothingArticleIds);
    }
}
