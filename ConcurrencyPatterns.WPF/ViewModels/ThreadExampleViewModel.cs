using Common.WPF.Commands;
using Common.WPF.ViewModels;
using ConcurrencyPatterns.WPF.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ConcurrencyPatterns.WPF.ViewModels;

public class ThreadExampleViewModel : ViewModel
{
    private readonly Dispatcher? _dispatcher;

    private int _threadsAmount = 2;

    private List<Thread> _threads = new();

    private List<TextBox> _textBoxes = new();

    private bool _randomThreadSleepEnabled = false;

    private bool _useBadExample = true;

    public ThreadExampleViewModel(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        UpdateThreads();
        UpdateTextBoxes();
    }
    
    public RelayedCommand ExecuteCommand => new(Execute, CanExecute);

    public List<Thread> Threads
    {
        get => _threads;
        set 
        { 
            _threads = value; 
            OnPropertyChanged();
        }
    }

    public List<TextBox> TextBoxes
    {
        get => _textBoxes;
        set
        {
            _textBoxes = value;
            OnPropertyChanged();
        }
    }


    public int ThreadsAmount
    {
        get => _threadsAmount;
        set
        {
            _threadsAmount = value;
            UpdateThreads();
            UpdateTextBoxes();
            OnPropertyChanged();
        }
    }

    public bool RandomThreadSleepEnabled
    {
        get => _randomThreadSleepEnabled;
        set
        {
            _randomThreadSleepEnabled = value;
            OnPropertyChanged();
        }
    }

    public bool UseBadExample
    {
        get => _useBadExample;
        set
        {
            _useBadExample = value;
            OnPropertyChanged();
        }
    }

    protected void RandomThreadSleepIfEnabled()
    {
        if (_randomThreadSleepEnabled == false)
            return;

        var time = 1 + (Random.Shared.NextInt64() % 2 == 1 
            ? Math.Round(Random.Shared.NextDouble(), 3) 
            : -Math.Round(Random.Shared.NextDouble(), 3));
        UpdateText($"Will sleep for {time:0.###}s");
        Thread.Sleep(TimeSpan.FromSeconds(time));
    }

    protected virtual void ThreadTask() { }

    protected virtual void Execute(object? parameter)
    {
        UpdateThreads();
        UpdateTextBoxes();
        _threads.ForEach(t => t.Start());
    }

    protected virtual bool CanExecute(object? parameter)
        => _threads.All(t => t.IsAlive == false);

    protected void UpdateTextBoxes() 
        => TextBoxes = Enumerable.Range(0, ThreadsAmount)
                                 .Select(_ => new TextBox() { Style = Application.Current.FindResource(Constants.ThreadTextBoxStyleKey) as Style })
                                 .ToList();

    protected void UpdateText(string text, TextBox? target = null)
    {
        if (TryGetIndex(out var index) == false && target is null)
            return;

        var textBox = target ?? _textBoxes[index];

        _dispatcher?.Invoke(() =>
        {
            textBox.Text += $"{text}\n";
        });
    }

    protected bool TryGetIndex(out int index)
    {
        index = 0;
        var thread = Threads.FirstOrDefault(t => t.ManagedThreadId == Environment.CurrentManagedThreadId);
        if (thread is null)
            return false;

        index = Threads.IndexOf(thread);
        return true;
    }

    private void UpdateThreads() 
        => Threads = Enumerable.Range(0, _threadsAmount)
                               .Select(_ => new Thread(ThreadTask))
                               .ToList();
}
