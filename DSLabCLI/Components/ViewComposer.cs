using DSLab.Views;
using Spectre.Console;

namespace DSLab.Components;

public class ViewComposer
{
    private readonly IView _headerView;
    private readonly IView _footerView;
    private IView CurrentView { get; set; }

    ViewComposer(IView headerView, IView footerView)
    {
        _footerView = footerView;
        _headerView = headerView;
    }

    public void ComposeView(IView view)
    {
        this.CurrentView = view;
        
        AnsiConsole.Clear();
        
        this._headerView.Render();
        this.CurrentView.Render();
        this._footerView.Render();
    }
}