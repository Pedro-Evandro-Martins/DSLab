namespace DSLab.Views;

public interface IView
{
    void Render();
    bool HandleInput();
}