using System;
using System.Collections.Generic;

public class CompositeDisposeable : IDisposable
{
    private readonly List<IDisposable> _disposables = new List<IDisposable>();

    public void Retain(IDisposable disposable)
    {
        _disposables.Add(disposable);
    }

    public void Dispose()
    {
        foreach(var disposable in _disposables)
        {
            disposable.Dispose();
        }

        _disposables?.Clear();
    }
}
