using System.Collections;

namespace Design.Pattern.Iterator.Interfaces
{
    public interface IIterator
    {
        object First();
        object Next();
        object Current();
        int GetIndex();
    }
}
