using DSLab.Views;
using Spectre.Console;

namespace DSLab.Components;

public class ViewComposer
{
    private readonly IView _headerView;
    private readonly IView _footerView;
    private IView _currentView;

    public ViewComposer(IView headerView, IView footerView)
    {
        _footerView = footerView;
        _headerView = headerView;
    }

    public void ComposeView(IView view)
    {
        this._currentView = view;
        
        AnsiConsole.Clear();
        
        this._headerView.Render();
        this._currentView.Render();
        this._footerView.Render();
    }

    public void PassthroughInput()
    {
        if(this._headerView.HandleInput())
            return;

        if (this._currentView.HandleInput())
            return;
        
        if (this._footerView.HandleInput())
            return;
    }
}