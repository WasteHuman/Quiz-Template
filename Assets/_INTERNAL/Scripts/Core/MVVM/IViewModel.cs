namespace Core.MVVM
{
    public interface IViewModel
    {
        void BindModel(IModel model);
        void Dispose();
    }
}