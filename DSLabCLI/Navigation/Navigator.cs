using System;
using DSLab.Views;
using System.Collections.Generic;
using DSLab.Components;

namespace DSLab.Navigation;

public class Navigator
{
    private readonly Stack<IView> _viewStack; 
    private readonly ViewComposer _composer;
    
    public Navigator(ViewComposer composer)
    {
        this._composer = composer ?? throw new ArgumentNullException(nameof(composer)); 
        this._viewStack = new Stack<IView>();
    }
    
    public void Start(IView mainMenuView)
    {
        NavigateTo(mainMenuView);
        while (true)
        {
            RenderView();
            HandleInput();
        }
    }
    
    private void RenderView()
    {
        _composer.ComposeView(_viewStack.Peek());
    }

    private void HandleInput()
    {
        throw new NotImplementedException();
    }

    public void NavigateTo(IView view)
    {
        this._viewStack.Push(view);
    }

    public void NavigateBack()
    {
        if (this._viewStack.Count > 1)
        {  
            this._viewStack.Pop();
        }
    }
}
