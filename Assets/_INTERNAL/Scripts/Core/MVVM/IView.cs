namespace Core.MVVM
{
    public interface IView
    {
        void BindViewModel(IViewModel viewModel);
        void Dispose();
    }
}